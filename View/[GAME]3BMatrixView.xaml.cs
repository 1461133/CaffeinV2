using BubbleBurst.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;
namespace View
{
    /// <summary>
    /// Interaction logic for _GAME_3BMatrixView.xaml
    /// </summary>
    public partial class _GAME_3BMatrixView : ItemsControl
    {
        #region Constructor

        public _GAME_3BMatrixView()
        {
            InitializeComponent();

            base.DataContextChanged += this.HandleDataContextChanged;
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Returns the number of columns in the bubble matrix.
        /// </summary>
        internal int ColumnCount
        {
            get { return _bubbleCanvas != null ? _bubbleCanvas.ColumnCount : -1; }
        }

        /// <summary>
        /// Returns the number of rows in the bubble matrix.
        /// </summary>
        internal int RowCount
        {
            get { return _bubbleCanvas != null ? _bubbleCanvas.RowCount : -1; }
        }

        #endregion // Properties

        #region Events

        /// <summary>
        /// Raised when the RowCount and ColumnCount properties have meaningful values.
        /// </summary>
        internal event EventHandler MatrixDimensionsAvailable;

        #endregion // Events

        #region Methods

        void HandleBubbleCanvasLoaded(object sender, RoutedEventArgs e)
        {
            // Store a reference to the panel that contains the bubbles.
            _bubbleCanvas = sender as BubbleCanvas;

            // Create the factory that makes Storyboards used after a bubble group bursts.
            _storyboardFactory = new BubblesTaskStoryboardFactory(_bubbleCanvas);

            // Let the world know that the size of the bubble matrix is known.
            this.RaiseMatrixDimensionsAvailable();
        }

        void RaiseMatrixDimensionsAvailable()
        {
            var handler = this.MatrixDimensionsAvailable;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #region Task Processing Logic

        void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Store a reference to the ViewModel.
            _bubbleMatrix = base.DataContext as _GAME_3BMatrixViewModel;

            if (_bubbleMatrix != null)
            {
                // Hook the event raised after a bubble group bursts and a series
                // of animations need to run to advance the game state.
                _bubbleMatrix.TaskManager.PendingTasksAvailable += delegate
                {
                    this.ProcessNextTask();
                };
            }
        }

        void ProcessNextTask()
        {
            var task = _bubbleMatrix.TaskManager.GetPendingTask();
            if (task != null)
            {
                var storyboard = _storyboardFactory.CreateStoryboard(task);
                this.PerformTask(task, storyboard);
            }
        }

        void PerformTask(_GAME_3BTask task, Storyboard storyboard)
        {
            if (storyboard != null)
            {
                // There are some bubbles that need to be animated, so we must
                // wait until the Storyboard finishs before completing the task.
                storyboard.Completed += delegate { this.CompleteTask(task); };

                // Freeze the Storyboard to improve perf.
                storyboard.Freeze();

                // Start animating the bubbles associated with the task.
                storyboard.Begin(this);
            }
            else
            {
                // There are no bubbles associated with this task,
                // so immediately move to the task completion phase.
                this.CompleteTask(task);
            }
        }

        void CompleteTask(_GAME_3BTask task)
        {
            task.Complete();
            this.ProcessNextTask();
        }

        #endregion // Task Processing Logic

        #endregion // Methods

        #region Fields

        BubbleCanvas _bubbleCanvas;
        _GAME_3BMatrixViewModel _bubbleMatrix;
        BubblesTaskStoryboardFactory _storyboardFactory;

        #endregion // Fields
    }
}