﻿using CommunicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendModel;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Backend.Hub
{
    public partial class CornellGoHub
    {
        public async Task<UserData> GetUserData()
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = session.User;
            return new UserData(user.Username, user.Score, user.GroupMember.Group.Id.ToString(), user.Id.ToString());
        }

        public IAsyncEnumerable<LeaderboardData> GetTopPlayers(int index, int count)
        {
            if (count > 100) count = 100;
            return Database.Users
                .OrderBy(User => User.Score)
                .Skip(index).Take(count)
                .Select((u, i) => new LeaderboardData(u.Id.ToString(), u.Username, i + index, u.Score))
                .AsAsyncEnumerable();
        }

        public async IAsyncEnumerable<ChallengeHistoryEntryData> GetHistoryData()
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = session.User;
            IEnumerable<PrevChallenge> query = user.PrevChallenges;
            foreach (PrevChallenge prev in query)
            {
                Challenge chal = prev.Challenge;
                yield return new ChallengeHistoryEntryData(chal.Id.ToString(), chal.ImageJPG.ToString(), chal.Name, chal.Description, chal.Points.ToString(), prev.Timestamp);
            }

            
        }

        public async Task<string> GetPrevChallengeName()
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = session.User;
            return user.PrevChallenges.LastOrDefault().ToString();
        }

    }
}
