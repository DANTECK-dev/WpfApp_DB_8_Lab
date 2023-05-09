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
    /// Логика взаимодействия для Query3Window.xaml
    /// </summary>
    public partial class Query3Window : Window
    {
        db_icv3Entities context;
        public Query3Window()
        {
            InitializeComponent();

            context = new db_icv3Entities();

            var postList =
                from postavshiki in context.Поставщики

                join dogovori in context.Договоры on postavshiki.КодПоставщика equals dogovori.КодПоставщика
                join postavleno in context.Поставлено on dogovori.НомерДоговора equals postavleno.НомерДоговора
                join urilitsa in context.ЮридическиеЛица on dogovori.КодПоставщика equals urilitsa.КодПоставщика

                select new
                {
                    КодПоставщика = urilitsa.КодПоставщика,
                    НомерДоговора = dogovori.НомерДоговора,
                    Товар = postavleno.Товар,
                    Количество = postavleno.Количество,
                    Цена = postavleno.Цена
                };

            DataGrid_1.ItemsSource = postList.ToList();
        }
    }
}
