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
