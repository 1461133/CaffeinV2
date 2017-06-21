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
    /// Interaction logic for _GAME_USGameOver.xaml
    /// </summary>
    public partial class _GAME_USGameOver : UserControl
    {
        #region Constructor

        public _GAME_USGameOver()
        {
            InitializeComponent();

            _outroStoryboard = _contentBorder.Resources["OutroStoryboard"] as Storyboard;

            base.DataContextChanged += this.HandleDataContextChanged;
        }

        #endregion // Constructor

        #region Methods

        void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _gameOver = base.DataContext as _GAME_3BGameOver;
        }

        void HandlePlayAgainHyperlinkClick(object sender, RoutedEventArgs e)
        {
            _gameOver.StartNewGame();
            _outroStoryboard.Begin(this);
        }

        void HandleOutroCompleted(object sender, EventArgs e)
        {
            _gameOver.Close();
        }

        #endregion // Methods

        #region Fields

        _GAME_3BGameOver _gameOver;
        readonly Storyboard _outroStoryboard;

        #endregion // Fields
    }
}
