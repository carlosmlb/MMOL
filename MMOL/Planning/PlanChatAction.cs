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
