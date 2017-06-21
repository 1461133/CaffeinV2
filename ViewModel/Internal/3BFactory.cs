using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ViewModel.Internal
{
    internal class _3BFactory
    {
        #region Constructor

        internal _3BFactory(_GAME_3BMatrixViewModel bubbleMatrix)
        {
            if (bubbleMatrix == null)
                throw new ArgumentNullException("bubbleMatrix");

            _bubbleMatrix = bubbleMatrix;

            _bubbleStagingArea = new List<_GAME_3BViewModel>();

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(10) };
            _timer.Tick += this.HandleTimerTick;
        }

        #endregion // Constructor

        #region Methods

        /// <summary>
        /// Populates the bubble matrix with new bubbles over time.
        /// </summary>
        internal void CreateBubblesAsync()
        {
            _timer.Stop();

            _bubbleStagingArea.Clear();
            _bubbleStagingArea.AddRange(
                from row in Enumerable.Range(0, _bubbleMatrix.RowCount)
                from col in Enumerable.Range(0, _bubbleMatrix.ColumnCount)
                select new _GAME_3BViewModel(_bubbleMatrix, row, col));

            _bubbleMatrix.IsIdle = false;

            _timer.Start();
        }

        void HandleTimerTick(object sender, EventArgs e)
        {
            if (!_timer.IsEnabled)
                return;

            for (int i = 0; i < 4 && _bubbleStagingArea.Any(); ++i)
            {
                // Get a random bubble from the staging area.
                int index = _random.Next(0, _bubbleStagingArea.Count);
                var bubble = _bubbleStagingArea[index];
                _bubbleStagingArea.RemoveAt(index);

                // Add the bubble to the bubble matrix.
                _bubbleMatrix.AddBubble(bubble);

                if (!_bubbleStagingArea.Any())
                {
                    _timer.Stop();
                    _bubbleMatrix.IsIdle = true;
                }
            }
        }

        #endregion // Methods

        #region Fields

        readonly _GAME_3BMatrixViewModel _bubbleMatrix;
        readonly List<_GAME_3BViewModel> _bubbleStagingArea;
        readonly Random _random = new Random(DateTime.Now.Millisecond);
        readonly DispatcherTimer _timer;

        #endregion // Fields
    }
}
