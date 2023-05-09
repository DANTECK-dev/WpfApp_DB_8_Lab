using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Query2Window.xaml
    /// </summary>
    public partial class Query2Window : Window
    {
        db_icv3Entities context;
        public Query2Window()
        {
            InitializeComponent();

            context = new db_icv3Entities();

            var postList =
                from postavshiki in context.Поставщики

                join dogovori in context.Договоры on postavshiki.КодПоставщика equals dogovori.КодПоставщика 
                join postavleno in context.Поставлено on dogovori.НомерДоговора equals postavleno.НомерДоговора

                where postavshiki.КодПоставщика == 3 
                orderby postavleno.Товар descending

                select new
                {
                    КодПоставщика = postavshiki.КодПоставщика,
                    НомерДоговора = dogovori.НомерДоговора,
                    Товар = postavleno.Товар,
                    Количество = postavleno.Количество,
                    Цена = postavleno.Цена
                };

            DataGrid_1.ItemsSource = postList.ToList();
        }
    }
}
