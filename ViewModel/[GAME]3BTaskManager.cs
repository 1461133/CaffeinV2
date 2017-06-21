using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Internal;

namespace ViewModel
{
    public class _GAME_3BTaskManager
    {
        #region Constructor

        internal _GAME_3BTaskManager(_GAME_3BMatrixViewModel bubbleMatrix)
        {
            _bubblesTaskFactory = new _3BTaskFactory(bubbleMatrix);
            _pendingTasks = new Queue<_GAME_3BTask>();
            _undoStack = new Stack<IEnumerable<_GAME_3BTask>>();
        }

        #endregion // Constructor

        #region Events

        /// <summary>
        /// Raised when tasks are available to be performed.
        /// </summary>
        public event EventHandler PendingTasksAvailable;

        #endregion // Events

        #region Properties

        /// <summary>
        /// Returns true if an undo operation can be performed at this time.
        /// </summary>
        internal bool CanUndo
        {
            get { return _undoStack.Any(); }
        }

        #endregion // Properties

        #region Methods

        #region Public

        /// <summary>
        /// Returns the next pending task if one exists, or null.
        /// </summary>
        public _GAME_3BTask GetPendingTask()
        {
            return _pendingTasks.Any() ? _pendingTasks.Dequeue() : null;
        }

        #endregion // Public

        #region Internal

        /// <summary>
        /// Publishs a set of tasks that will burst a bubble group.
        /// </summary>
        /// <param name="bubblesInGroup">The bubbles to burst.</param>
        internal void PublishTasks(_GAME_3BViewModel[] bubblesInGroup)
        {
            var tasks = _bubblesTaskFactory.CreateTasks(bubblesInGroup);
            this.ArchiveTasks(tasks);
            this.PublishTasks(tasks);
        }

        /// <summary>
        /// Publishs a set of tasks that will undo the previous bubble burst.
        /// </summary>
        internal void Undo()
        {
            var originalTasks = _undoStack.Pop();
            var undoTasks = _bubblesTaskFactory.CreateUndoTasks(originalTasks);
            this.PublishTasks(undoTasks);
        }

        /// <summary>
        /// Initializes this object back to its original state.
        /// </summary>
        internal void Reset()
        {
            _pendingTasks.Clear();
            _undoStack.Clear();
        }

        #endregion // Internal

        #region Private

        void ArchiveTasks(IEnumerable<_GAME_3BTask> tasks)
        {
            _undoStack.Push(tasks);
        }

        void PublishTasks(IEnumerable<_GAME_3BTask> tasks)
        {
            foreach (_GAME_3BTask task in tasks)
            {
                _pendingTasks.Enqueue(task);
            }

            this.RaisePendingTasksAvailable();
        }

        void RaisePendingTasksAvailable()
        {
            var handler = this.PendingTasksAvailable;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion // Private

        #endregion // Methods

        #region Fields

        readonly _3BTaskFactory _bubblesTaskFactory;
        readonly Queue<_GAME_3BTask> _pendingTasks;
        readonly Stack<IEnumerable<_GAME_3BTask>> _undoStack;

        #endregion // Fields
    }
}
