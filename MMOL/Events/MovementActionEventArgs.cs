using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenMetaverse;

namespace MMOLBot.Events
{
    /// <summary>
    /// Data about a movement action.
    /// </summary>
    public class MovementActionEventArgs : EventArgs
    {
        /// <summary>
        /// Original position.
        /// </summary>
        public Vector3 FromPosition { get; set; }

        /// <summary>
        /// Final position.
        /// </summary>
        public Vector3 ToPosition { get; set; }
    }
}
