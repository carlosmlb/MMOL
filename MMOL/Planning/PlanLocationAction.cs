using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MMOLBot.Events;
using OpenMetaverse;

namespace MMOLBot.Planning
{
    /// <summary>
    /// Defines an action that controls the avatar position (whether the user enters a room or a zone or not)
    /// </summary>
    public class PlanLocationAction : PlanAction
    {
        /// <summary>
        /// Expected zone origin
        /// </summary>
        public Vector3 ExpectedZoneOrigin { get; set; }

        /// <summary>
        /// Expected zone dimensions
        /// </summary>
        public Vector3 ExpectedZoneDimensions { get; set; }

        /// <summary>
        /// Checks that the given event is a movement event and the avatar is located in the expected zone.
        /// </summary>
        /// <param name="e">Event to process</param>
        /// <returns>true if the avatar is in the expected zone, false if not</returns>
        public bool CheckEvent(EventArgs e)
        {
            MovementActionEventArgs args = e as MovementActionEventArgs;

            if (args == null) return false;

            return args.ToPosition.X >= ExpectedZoneOrigin.X && args.ToPosition.X <= ExpectedZoneOrigin.X + ExpectedZoneDimensions.X
                && args.ToPosition.Y >= ExpectedZoneOrigin.Y && args.ToPosition.Y <= ExpectedZoneOrigin.Y + ExpectedZoneDimensions.Y
                && args.ToPosition.Z >= ExpectedZoneOrigin.Z && args.ToPosition.Z <= ExpectedZoneOrigin.Z + ExpectedZoneDimensions.Z;
        }
    }
}
