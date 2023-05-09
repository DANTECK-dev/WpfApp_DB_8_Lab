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
using System.Windows.Shapes;

namespace WpfApp_DB_8_Lab
{
    /// <summary>
    /// Логика взаимодействия для Query1Window.xaml
    /// </summary>
    public partial class Query1Window : Window
    {
        db_icv3Entities context;
        public Query1Window()
        {
            InitializeComponent();

            context = new db_icv3Entities();

            var postList =
                from postavleno in context.Поставлено
                where postavleno.Цена > 500
                orderby postavleno.Товар
                select new
                {
                    НомерДоговора = postavleno.НомерДоговора,
                    Товар = postavleno.Товар,
                    Количество = postavleno.Количество,
                    Цена = postavleno.Цена
                };

            DataGrid_1.ItemsSource = postList.ToList();
        }
    }
}
