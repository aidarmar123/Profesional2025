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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AbrovedDelete.xaml
    /// </summary>
    public partial class AbrovedDelete : Window
    {
        public AbrovedDelete()
        {
            InitializeComponent();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult =true;
        }
    }
}
