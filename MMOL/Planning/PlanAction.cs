using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMOLBot.Planning
{
    /// <summary>
    /// Interface of methods that have to be implemented by a plan action.
    /// </summary>
    public interface PlanAction
    {
        bool CheckEvent(EventArgs e);
    }
}
