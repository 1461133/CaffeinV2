using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public enum _GAME_3BTaskType
    {
        /// <summary>
        /// Represents the task of removing the bubbles in a group that was burst by the user.
        /// </summary>
        Burst,

        /// <summary>
        /// Represents the task of moving bubbles down to fill the empty bubble matrix cells
        /// created after a group of bubbles was burst by the user.
        /// </summary>
        MoveDown,

        /// <summary>
        /// Represents the task of moving all bubbles in the bubble matrix as far
        /// to the right as possible, after the user bursts a bubble group.
        /// </summary>
        MoveRight
    }
}
