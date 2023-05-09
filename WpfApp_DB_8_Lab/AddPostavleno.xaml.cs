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
    /// Логика взаимодействия для AddPostavleno.xaml
    /// </summary>
    public partial class AddPostavleno : Window
    {
        public AddPostavleno()
        {
            InitializeComponent();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                db_icv3Entities context = new db_icv3Entities();
                Поставлено postav = new Поставлено();
                postav.НомерДоговора = Convert.ToInt32(NomDogovBox.Text);
                postav.Товар = TovarBox.Text;
                postav.Количество = decimal.Parse(CountBox.Text);
                postav.Цена = decimal.Parse(SumBox.Text);
                context.Поставлено.Add(postav);
                context.SaveChanges();
                Status.Content = "Запись успешно добавлена";

            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Change(object sender, TextChangedEventArgs e)
        {
            Status.Content = "";
        }
    }
}
