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

namespace WpfApp_DB_8_Lab
{
    /// <summary>
    /// Логика взаимодействия для ViewPostavleno.xaml
    /// </summary>
    public partial class ViewPostavleno : Window
    {
        public ViewPostavleno()
        {
            InitializeComponent();
            InitializeComponent();
            db_icv3Entities context = new db_icv3Entities();
            List<Поставлено> postav = context.Поставлено.ToList();
            _DataGrid.ItemsSource = postav;
        }
    }
}
