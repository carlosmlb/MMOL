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

namespace MMOLBot.Planning
{
    /// <summary>
    /// Plan of actions to be completed by an user.
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// List of actions that has to be completed
        /// </summary>
        public List<PlanAction> Actions
        {
            get;
            internal set;
        }

        /// <summary>
        /// Current action in process.
        /// </summary>
        public PlanAction CurrentAction { get; internal set; }

        private int currentActionIndex = 0;

        /// <summary>
        /// Is the planning ready to be used?
        /// </summary>
        public bool IsReady
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        /// <summary>
        /// Has the planning been completed?
        /// </summary>
        public bool IsFinished
        {
            get
            {
                return currentActionIndex > Actions.Count;
            }
        }

        /// <summary>
        /// Process an event in order to see if the current action has been made.
        /// </summary>
        /// <param name="e">Event to process</param>
        public void ProcessEvent(EventArgs e)
        {
            if (!IsReady) return;

            if (CurrentAction.CheckEvent(e))
            {
                currentActionIndex++;

                CurrentAction = IsFinished ? null : Actions[currentActionIndex];
            }
        }

        /// <summary>
        /// Initializes the planning using a list of actions
        /// </summary>
        /// <param name="actions">Actions to add to the planning</param>
        public void Initialize(List<PlanAction> actions)
        {
            if (actions.Count < 0) throw new Exception("No actions in the plan.");

            Actions = actions;
            CurrentAction = actions[0];
        }
    }
}
