﻿using CommunicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendModel;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Backend.Hub
{
    public partial class CornellGoHub
    {
        public async Task<bool> Kick(string userId)
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            if (session == null) return false;
            
            User query = Database.Users.Single(b => b.Id == long.Parse(userId));
            GroupMember gmem = query.GroupMember;
            Group grp = query.GroupMember.Group;
            grp.GroupMembers.Remove(gmem);
            Database.GroupMembers.Remove(gmem);
            grp.SyncPlacesWithUsers();
            await Database.SaveChangesAsync();

            /*
            List<GroupMemberData> list = new List<GroupMemberData>();
            foreach (GroupMember gmember in grp.GroupMembers)
            {
                GroupMemberData gmd = new GroupMemberData(gmember.User.Id.ToString(), gmember.User.Username, gmember.IsHost, gmember.IsDone, gmember.User.Score);
                list.Add(gmd);
                
            }
            */

            await Clients.Group(query.GroupMember.Group.SignalRId).UpdateGroupData(grp.GetFriendlyId(), await GetGroupMembers());
            

            //edge case if kicked get points and update challeng
            if (query.GroupMember.IsDone)
            {
                query.Score += grp.Challenge.Points;  
            }
            //edge case if kicked and last one then move group on
            if (grp.GroupMembers.All(b => b.IsDone))
            {
                await grp.GetNewChallenge(Database.Challenges);
            }
            

            await query.NewGroup(Database.Challenges);

            await Clients.Group(query.GroupMember.Group.SignalRId).UpdateGroupData(grp.GetFriendlyId(), await GetGroupMembers());

            await Database.SaveChangesAsync();
            return true;
            
        }

        public async Task<ChallengeData> GetChallengeData()
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = session.User;
            Challenge chal = user.GroupMember.Group.Challenge;
            return new ChallengeData(chal.Id.ToString(), chal.Description, chal.Points, chal.ImageJPG.ToString());
        }

        public async Task<GroupMemberData[]> GetGroupMembers()
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = session.User;
            Group grp = user.GroupMember.Group;
            List<GroupMemberData> list = new List<GroupMemberData>();
            foreach (GroupMember gmem in grp.GroupMembers)
            {
                GroupMemberData res = await GetGroupMember(gmem.User.Id.ToString());
                list.Add(res);
            }
            return list.ToArray();
   
        }

        public async Task<GroupMemberData> GetGroupMember(string userId)
        {

            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = Database.Users.Single(b => b.Id == long.Parse(userId));
            return new GroupMemberData(user.Id.ToString(), user.Username, user.GroupMember.IsHost, user.GroupMember.IsDone, user.Score);
        }

        public async Task<string> GetFriendlyGroupId()
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = session.User;
            return user.GroupMember.Group.GetFriendlyId();
        }

        public async Task<bool> JoinGroup(string groupId)
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = session.User;
            Group grp = Database.Groups.Single(b => b.Id == long.Parse(groupId));

            if (grp == null)
                return false;
            grp.GroupMembers.Add(user.GroupMember);
            Database.GroupMembers.Add(user.GroupMember);
            await Database.SaveChangesAsync();
            return true;
        }

        public async Task<ChallengeProgressData> CheckProgress(double lat, double @long)
        {
            UserSession session = await Database.UserSessions.FromSignalRId(Context.UserIdentifier);
            User user = session.User;
            Challenge chal = user.GroupMember.Group.Challenge;
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory();

            var nPoint = geometryFactory.CreatePoint(new Coordinate(lat, @long));
            var fPoint = geometryFactory.CreatePoint(chal.LongLat.Coordinates.FirstOrDefault());

            double dist = nPoint.Distance(fPoint);
            double scaled = dist / chal.Radius;
            if(dist <= 10)
            {
                user.GroupMember.IsDone = true;
                await Clients.Caller.FinishChallenge();
                if(user.GroupMember.Group.GroupMembers.All(b => b.IsDone))
                {
                    Challenge newChal = await user.GroupMember.Group.GetNewChallenge(Database.Challenges);
                    ChallengeData cData = new ChallengeData(newChal.Id.ToString(), newChal.Description, newChal.Points, newChal.ImageJPG.ToString());
                    await Clients.Group(user.GroupMember.Group.SignalRId).UpdateChallenge(cData);  
                }

            }

            return new ChallengeProgressData(nPoint.Distance(fPoint).ToString(), scaled);
        }
    }
}
