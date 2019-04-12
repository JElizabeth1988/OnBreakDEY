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

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para ListarContrato.xaml
    /// </summary>
    public partial class ListarContrato : MetroWindow
    {
        public ListarContrato()
        {
            InitializeComponent();
            button1.Visibility = Visibility.Hidden;
        }

        public ListarContrato(MainWindow origen)
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            if (button1.Visibility == Visibility.Hidden)
            {
                button1.Visibility = Visibility.Visible;
            }
            else {
                button1.Visibility = Visibility.Hidden;
            }
            
        }
    }
}