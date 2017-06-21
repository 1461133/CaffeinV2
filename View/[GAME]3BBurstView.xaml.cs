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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;
using View;
namespace View
{
    /// <summary>
    /// Interaction logic for _GAME_3BBurstView.xaml
    /// </summary>
    public partial class _GAME_3BBurstView : UserControl
    {
        #region Constructor

        public _GAME_3BBurstView()
        {
            LoadBubbleViewResources();

            InitializeComponent();

            _bubbleBurst = base.DataContext as _GAME_3BBurstViewModel;
            _bubbleMatrixView.MatrixDimensionsAvailable += this.HandleMatrixDimensionsAvailable;
        }

        static void LoadBubbleViewResources()
        {
            // Insert the BubbleView resources at the App level to avoid resource duplication.
            // If we insert the resources into this control's Resources collection, every time
            // a BubbleView is removed from the UI some ugly debug warning messages are spewed out.
            string path = "pack://application:,,,/View;component/BubbleViewResources.xaml";
            var bubbleViewResources = new ResourceDictionary
            {
                Source = new Uri(path)
            };
            Application.Current.Resources.MergedDictionaries.Add(bubbleViewResources);
        }

        #endregion // Constructor

        #region Methods

        void HandleMatrixDimensionsAvailable(object sender, EventArgs e)
        {
            // Hook the keyboard event on the Window because this
            // control does not receive keystrokes.
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.PreviewKeyDown += this.HandleWindowPreviewKeyDown;
            }

            this.StartNewGame();
        }

        void HandleWindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool undo =
                Keyboard.Modifiers == ModifierKeys.Control &&
                e.Key == Key.Z;

            if (undo && _bubbleBurst.CanUndo)
            {
                _bubbleBurst.BubbleMatrix.Undo();
                e.Handled = true;
            }
        }

        void StartNewGame()
        {
            int rows = _bubbleMatrixView.RowCount;
            int cols = _bubbleMatrixView.ColumnCount;
            _bubbleBurst.BubbleMatrix.SetDimensions(rows, cols);
            _bubbleBurst.BubbleMatrix.StartNewGame();
        }

        #endregion // Methods

        #region Fields

        readonly _GAME_3BBurstViewModel _bubbleBurst;

        #endregion // Fields
    }
}
