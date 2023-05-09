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
    /// Логика взаимодействия для AddPostavshiki.xaml
    /// </summary>
    public partial class AddPostavshiki : Window
    {
        public AddPostavshiki()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                db_icv3Entities context = new db_icv3Entities();
                Поставщики postav = new Поставщики();
                postav.КодПоставщика = Convert.ToInt32(KodPostavBox.Text);
                postav.Адрес = AdresBox.Text;
                postav.Примечание = CommentBox.Text;
                context.Поставщики.Add(postav);
                context.SaveChanges();
                Status.Content = "Запись успешно добавлена";

            }
            catch (Exception ex) {
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
