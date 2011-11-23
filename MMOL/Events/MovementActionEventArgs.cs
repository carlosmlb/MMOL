/**
 *  MMOL Project: API Tool for increase client functionalities of
 *  realXtend technologies.
 *  Copyright (C) 2010 Information Engineering Research Unit
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>
 * */
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
