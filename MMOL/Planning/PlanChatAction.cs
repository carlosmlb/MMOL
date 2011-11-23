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
using MMOL.Events;

namespace MMOLBot.Planning
{
    /// <summary>
    /// Plan action that controls whether the user says something specific or not.
    /// </summary>
    public class PlanChatAction : PlanAction
    {
        /// <summary>
        /// Message that is expected to be said by the user
        /// </summary>
        public string ExpectedMessage { get; set; }

        /// <summary>
        /// Checks given event's message is the expected message.
        /// </summary>
        /// <param name="e">Chat event</param>
        /// <returns>true if the event was the expected, false if not</returns>
        public bool CheckEvent(EventArgs e)
        {
            ChatActionEventArgs args = e as ChatActionEventArgs;

            if (args == null) return false;

            return args.Message.Equals(ExpectedMessage);
        }
    }
}
