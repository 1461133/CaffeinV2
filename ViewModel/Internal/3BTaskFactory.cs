using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Internal
{
    internal class _3BTaskFactory
    {
        #region Constructor

        internal _3BTaskFactory(_GAME_3BMatrixViewModel bubbleMatrix)
        {
            if (bubbleMatrix == null)
                throw new ArgumentNullException("bubbleMatrix");

            _bubbleMatrix = bubbleMatrix;
        }

        #endregion // Constructor

        #region Methods

        #region Internal

        /// <summary>
        /// Creates a sequence of tasks that must be performed for the 
        /// specified collection of bubbles.
        /// </summary>
        /// <param name="bubblesInGroup">The bubbles for which tasks are created.</param>
        internal IEnumerable<_GAME_3BTask> CreateTasks(_GAME_3BViewModel[] bubblesInGroup)
        {
            var taskTypes = new _GAME_3BTaskType[]
            {
                _GAME_3BTaskType.Burst,
                _GAME_3BTaskType.MoveDown,
                _GAME_3BTaskType.MoveRight
            };

            // Dump the tasks into an array so that the query is not executed twice.
            return
                (from taskType in taskTypes
                 select this.CreateTask(taskType, bubblesInGroup))
                .ToArray();
        }

        /// <summary>
        /// Creates tasks used to undo the effects of the specified tasks.
        /// </summary>
        /// <param name="originalTasks">
        /// The tasks used to perform the bubble burst about to be undone.
        /// </param>
        internal IEnumerable<_GAME_3BTask> CreateUndoTasks(IEnumerable<_GAME_3BTask> originalTasks)
        {
            // Dump the tasks into an array so that the query is not executed twice.
            return
                (from originalTask in originalTasks.Reverse()
                 select this.CreateUndoTask(originalTask))
                .ToArray();
        }

        #endregion // Internal

        #region Private

        _GAME_3BTask CreateUndoTask(_GAME_3BTask originalTask)
        {
            var bubbles = originalTask.Bubbles.ToList();
            Func<IEnumerable<_GAME_3BViewModel>> getBubbles;
            Action complete;
            switch (originalTask.TaskType)
            {
                case _GAME_3BTaskType.MoveRight:
                    getBubbles = delegate
                    {
                        _bubbleMatrix.IsIdle = false;
                        _bubbleMatrix.ResetBubbleGroup();
                        bubbles.ForEach(b => b.BeginUndo());
                        return bubbles;
                    };
                    complete = delegate
                    {
                        bubbles.ForEach(b => b.EndUndo());
                    };
                    break;

                case _GAME_3BTaskType.MoveDown:
                    getBubbles = delegate
                    {
                        bubbles.ForEach(b => b.BeginUndo());
                        return bubbles;
                    };
                    complete = delegate
                    {
                        bubbles.ForEach(b => b.EndUndo());
                    };
                    break;

                case _GAME_3BTaskType.Burst:
                    getBubbles = delegate
                    {
                        bubbles.ForEach(b => _bubbleMatrix.AddBubble(b));
                        return bubbles;
                    };
                    complete = delegate
                    {
                        _bubbleMatrix.IsIdle = true;
                    };
                    break;

                default:
                    throw new ArgumentException("Unrecognized task type: " + originalTask.TaskType);
            }
            return new _GAME_3BTask(originalTask.TaskType, true, getBubbles, complete);
        }

        _GAME_3BTask CreateTask(_GAME_3BTaskType taskType, _GAME_3BViewModel[] bubblesInGroup)
        {
            Func<IEnumerable<_GAME_3BViewModel>> getBubbles;
            Action complete;
            switch (taskType)
            {
                case _GAME_3BTaskType.Burst:
                    getBubbles = delegate
                    {
                        _bubbleMatrix.IsIdle = false;
                        return bubblesInGroup;
                    };
                    complete = delegate
                    {
                        foreach (_GAME_3BViewModel bubble in bubblesInGroup)
                        {
                            _bubbleMatrix.RemoveBubble(bubble);
                        }
                    };
                    break;

                case _GAME_3BTaskType.MoveDown:
                    getBubbles = delegate
                    {
                        return this.MoveNeighboringBubblesDown(bubblesInGroup);
                    };
                    complete = delegate
                    {
                        /* Nothing to do here. */
                    };
                    break;

                case _GAME_3BTaskType.MoveRight:
                    getBubbles = delegate
                    {
                        return this.MoveBubblesRight();
                    };
                    complete = delegate
                    {
                        _bubbleMatrix.IsIdle = true;
                        _bubbleMatrix.TryToEndGame();
                    };
                    break;

                default:
                    throw new ArgumentException("Unrecognized task type: " + taskType);
            }
            return new _GAME_3BTask(taskType, false, getBubbles, complete);
        }

        IEnumerable<_GAME_3BViewModel> MoveBubblesRight()
        {
            var movedBubbles = new List<_GAME_3BViewModel>();

            for (int rowIndex = 0; rowIndex < _bubbleMatrix.RowCount; ++rowIndex)
            {
                var bubblesInRow =
                    _bubbleMatrix.Bubbles.Where(b => b.Row == rowIndex).ToArray();

                // Skip empty rows and full rows.
                if (bubblesInRow.Length == 0 ||
                    bubblesInRow.Length == _bubbleMatrix.ColumnCount)
                    continue;

                for (int colIndex = _bubbleMatrix.ColumnCount - 1; colIndex > -1; --colIndex)
                {
                    var bubble = bubblesInRow.SingleOrDefault(b => b.Column == colIndex);
                    if (bubble != null)
                    {
                        // Find out how many cells between the bubble 
                        // and the last column have bubbles in them.
                        int occupied = bubblesInRow.Where(b => bubble.Column < b.Column).Count();

                        // Now determine how many of the cells do not have a bubble in them.
                        int empty = _bubbleMatrix.ColumnCount - 1 - bubble.Column - occupied;
                        if (empty != 0)
                        {
                            bubble.MoveTo(bubble.Row, bubble.Column + empty);
                            movedBubbles.Add(bubble);
                        }
                    }
                }
            }
            return movedBubbles;
        }

        IEnumerable<_GAME_3BViewModel> MoveNeighboringBubblesDown(_GAME_3BViewModel[] bubblesInGroup)
        {
            var movedBubbles = new List<_GAME_3BViewModel>();

            int[] affectedColumns = bubblesInGroup.Select(b => b.Column).Distinct().ToArray();

            foreach (int affectedColumn in affectedColumns)
            {
                var bubblesInColumn = _bubbleMatrix.Bubbles.Where(b => b.Column == affectedColumn).ToArray();
                if (bubblesInColumn.Length == 0)
                    continue;

                while (true)
                {
                    var bubbleRowIndexes = bubblesInColumn.Select(b => b.Row).ToArray();

                    var emptyIndexes =
                        (from rowIndex in Enumerable.Range(0, _bubbleMatrix.RowCount)
                         where !bubbleRowIndexes.Contains(rowIndex)
                         select rowIndex)
                        .ToArray();

                    int emptyIndexCount = emptyIndexes.Count();
                    if (emptyIndexCount == 0 || emptyIndexCount == _bubbleMatrix.RowCount)
                        break;

                    var occupiedIndexes = bubblesInColumn.Select(b => b.Row).ToArray();
                    int occupiedIndexCount = occupiedIndexes.Count();
                    if (occupiedIndexCount == 0 || occupiedIndexCount == _bubbleMatrix.RowCount)
                        break;

                    int bottomEmptyIndex = emptyIndexes.Max();
                    int topOccupiedIndex = occupiedIndexes.Min();
                    if (bottomEmptyIndex < topOccupiedIndex)
                        break;

                    var closestBubbleIndex = bubblesInColumn.Where(b => b.Row < bottomEmptyIndex).Max(b => b.Row);
                    var closestBubble = bubblesInColumn.Single(b => b.Row == closestBubbleIndex);
                    closestBubble.MoveTo(bottomEmptyIndex, closestBubble.Column);

                    movedBubbles.Add(closestBubble);
                }
            }
            return movedBubbles;
        }

        #endregion // Private

        #endregion // Methods

        #region Fields

        readonly _GAME_3BMatrixViewModel _bubbleMatrix;

        #endregion // Fields
    }
}
