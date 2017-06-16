﻿using System;
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
using System.Windows.Shapes;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for TKSanPham.xaml
    /// </summary>
    public partial class TKSanPham : Window
    {
        public TKSanPham()
        {
            SanPham sp = new SanPham();
            InitializeComponent();
            var db = this.FindResource("Caffein") as ViewModel.Caffein;
            db.SanPham = sp.LayViewSP();


        }
    }
}