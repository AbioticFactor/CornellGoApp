//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.2.0
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using NetTopologySuite.Geometries;

namespace BackendModel
{
   /// <summary>
   /// A challenge with a place associated
   /// </summary>
   [System.ComponentModel.Description("A challenge with a place associated")]
   public partial class Challenge
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected Challenge()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static Challenge CreateChallengeUnsafe()
      {
         return new Challenge();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="name">Name of the challenge up to 60 chars</param>
      /// <param name="description">Longer description of a challenge up to 100 chars</param>
      /// <param name="points">Point value of the challenge</param>
      /// <param name="longlat">Position of the challenge</param>
      /// <param name="radius">Furthest radius at which the user is considered far</param>
      /// <param name="imagejpg">JPEG Binary of the image for this challenge</param>
      public Challenge(string name, string description, int points, Point longlat, double radius, byte[] imagejpg)
      {
         if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
         this.Name = name;

         if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
         this.Description = description;

         this.Points = points;

         this.LongLat = longlat;

         this.Radius = radius;

         this.ImageJPG = imagejpg;


         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="name">Name of the challenge up to 60 chars</param>
      /// <param name="description">Longer description of a challenge up to 100 chars</param>
      /// <param name="points">Point value of the challenge</param>
      /// <param name="longlat">Position of the challenge</param>
      /// <param name="radius">Furthest radius at which the user is considered far</param>
      /// <param name="imagejpg">JPEG Binary of the image for this challenge</param>
      public static Challenge Create(string name, string description, int points, Point longlat, double radius, byte[] imagejpg)
      {
         return new Challenge(name, description, points, longlat, radius, imagejpg);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Indexed, Required
      /// Unique identifier
      /// </summary>
      [Key]
      [Required]
      [System.ComponentModel.Description("Unique identifier")]
      public long Id { get; set; }

      /// <summary>
      /// Required, Min length = 1, Max length = 60
      /// Name of the challenge up to 60 chars
      /// </summary>
      [Required]
      [MinLength(1)]
      [MaxLength(60)]
      [StringLength(60)]
      [System.ComponentModel.Description("Name of the challenge up to 60 chars")]
      public string Name { get; set; }

      /// <summary>
      /// Required, Min length = 1, Max length = 100
      /// Longer description of a challenge up to 100 chars
      /// </summary>
      [Required]
      [MinLength(1)]
      [MaxLength(100)]
      [StringLength(100)]
      [System.ComponentModel.Description("Longer description of a challenge up to 100 chars")]
      public string Description { get; set; }

      /// <summary>
      /// Required
      /// Point value of the challenge
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Point value of the challenge")]
      public int Points { get; set; }

      /// <summary>
      /// Required
      /// Position of the challenge
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Position of the challenge")]
      public Point LongLat { get; set; }

      /// <summary>
      /// Required
      /// Furthest radius at which the user is considered far
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Furthest radius at which the user is considered far")]
      public double Radius { get; set; }

      /// <summary>
      /// Required
      /// JPEG Binary of the image for this challenge
      /// </summary>
      [Required]
      [System.ComponentModel.Description("JPEG Binary of the image for this challenge")]
      public byte[] ImageJPG { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

   }
}

