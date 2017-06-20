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
namespace View
{
    /// <summary>
    /// Interaction logic for _GAME_3BView.xaml
    /// </summary>
    public partial class _GAME_3BView : Button
    {
        #region Constructor

        public _GAME_3BView()
        {
            InitializeComponent();

            base.DataContextChanged += this.HandleDataContextChanged;
            base.MouseEnter += this.HandleMouseEnter;
            base.MouseLeave += this.HandleMouseLeave;
        }

        #endregion // Constructor

        #region Methods

        void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _bubble = e.NewValue as _GAME_3BViewModel;
        }

        void HandleMouseEnter(object sender, MouseEventArgs e)
        {
            if (_bubble != null)
            {
                _bubble.VerifyGroupMembership(true);
            }
        }

        void HandleMouseLeave(object sender, MouseEventArgs e)
        {
            if (_bubble != null)
            {
                _bubble.VerifyGroupMembership(false);
            }
        }

        #endregion // Methods

        #region Fields

        _GAME_3BViewModel _bubble;

        #endregion // Fields
    }
}
