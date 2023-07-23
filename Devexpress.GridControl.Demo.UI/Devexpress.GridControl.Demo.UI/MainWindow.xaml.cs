﻿using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
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

namespace Devexpress.GridControl.Demo.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<bool>(this, OnMessage);
        }

        private void OnMessage(bool contentAlignment)
        {
            this.FlowDirection = !contentAlignment ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }
    }
}