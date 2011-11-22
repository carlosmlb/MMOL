using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMOL.Events
{
    /// <summary>
    /// Data of a chat event.
    /// </summary>
    public class ChatActionEventArgs : EventArgs
    {
        /// <summary>
        /// User that sent the chat message.
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// Message sent by the user.
        /// </summary>
        public string Message { get; set; }
    }
}
