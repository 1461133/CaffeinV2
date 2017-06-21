using MvvmFoundation.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class _GAME_3BBurstViewModel : ObservableObject
    {
        #region Constructor

        public _GAME_3BBurstViewModel()
        {
            this.BubbleMatrix = new _GAME_3BMatrixViewModel();
            this.BubbleMatrix.GameEnded += delegate
            {
                this.GameOver = new _GAME_3BGameOver(this.BubbleMatrix);
                this.GameOver.RequestClose += this.HandleGameOverRequestClose;
            };
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Returns the ViewModel responsible for managing the matrix of bubbles.
        /// </summary>
        public _GAME_3BMatrixViewModel BubbleMatrix { get; private set; }

        /// <summary>
        /// Returns true if the application can currently perform an undo operation.
        /// </summary>
        public bool CanUndo
        {
            get { return this.GameOver == null && this.BubbleMatrix.CanUndo; }
        }

        /// <summary>
        /// Returns the ViewModel used by the game-over dialog.
        /// </summary>
        public _GAME_3BGameOver GameOver
        {
            get { return _gameOver; }
            private set
            {
                if (value == _gameOver)
                    return;

                _gameOver = value;

                base.RaisePropertyChanged("GameOver");
            }
        }

        /// <summary>
        /// Returns the command that starts a new game of BubbleBurst.
        /// </summary>
        public ICommand RestartCommand
        {
            get { return new RelayCommand(this.BubbleMatrix.StartNewGame); }
        }

        /// <summary>
        /// Returns the command that un-bursts the previously burst bubble group.
        /// </summary>
        public ICommand UndoCommand
        {
            get { return new RelayCommand(this.BubbleMatrix.Undo, () => this.CanUndo); }
        }

        #endregion // Properties

        #region Methods

        void HandleGameOverRequestClose(object sender, EventArgs e)
        {
            this.GameOver.RequestClose -= this.HandleGameOverRequestClose;
            this.GameOver = null;
        }

        #endregion // Methods

        #region Fields

        _GAME_3BGameOver _gameOver;

        #endregion // Fields
    }
}
