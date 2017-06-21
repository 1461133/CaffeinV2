using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class _GAME_3BTask
    {
        #region Constructor

        internal _GAME_3BTask(_GAME_3BTaskType taskType, bool isUndo, Func<IEnumerable<_GAME_3BViewModel>> getBubbles, Action complete)
        {
            this.TaskType = taskType;
            this.IsUndo = isUndo;
            _getBubbles = getBubbles;
            this.Complete = complete;
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Returns the bubbles associated with this task.
        /// </summary>
        public IEnumerable<_GAME_3BViewModel> Bubbles
        {
            get
            {
                if (_bubbles == null)
                {
                    // The list of bubbles associated with this task is
                    // retrieved once, on demand, because retrieving the 
                    // list can have side effects.
                    _bubbles = _getBubbles().ToArray();
                }
                return _bubbles;
            }
        }

        /// <summary>
        /// Invoked immediately after the task has been performed.
        /// </summary>
        public Action Complete { get; private set; }

        /// <summary>
        /// Returns true if this task is undoing the effects of a previously performed task.
        /// </summary>
        public bool IsUndo { get; private set; }

        /// <summary>
        /// Returns the kind of task this object represents.
        /// </summary>
        public _GAME_3BTaskType TaskType { get; private set; }

        #endregion // Properties

        #region Fields

        _GAME_3BViewModel[] _bubbles;
        readonly Func<IEnumerable<_GAME_3BViewModel>> _getBubbles;

        #endregion // Fields
    }
}
