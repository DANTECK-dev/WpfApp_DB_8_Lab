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
    /// Логика взаимодействия для DeleteFizicheskiLitca.xaml
    /// </summary>
    public partial class DeleteFizicheskiLitca : Window
    {
        db_icv3Entities context;
        public DeleteFizicheskiLitca()
        {
            InitializeComponent();
            context = new db_icv3Entities();
            KodPostavBox.ItemsSource = context.ФизическиеЛица.ToList();
        }
        private void ChangePostav(object sender, EventArgs e)
        {
            if (KodPostavBox.SelectedIndex == -1) return;
            ФизическиеЛица post = KodPostavBox.SelectedItem as ФизическиеЛица;
            SurnameBox.Text = post.Фамилия;
            NameBox.Text = post.Имя;
            PatnomicBox.Text = post.Отчество;
            NomSvidBox.Text = post.НомерСвидетельства;
            Status.Content = "";
        }

        private void DeletePostav(object sender, RoutedEventArgs e)
        {
            try
            {
                ФизическиеЛица post = KodPostavBox.SelectedItem as ФизическиеЛица;
                context.ФизическиеЛица.Remove(post);
                context.SaveChanges();
                Status.Content = "Запись успешно удалена";
                KodPostavBox.SelectedItem = -1;
                KodPostavBox.Text = "";
                SurnameBox.Clear();
                NameBox.Clear();
                PatnomicBox.Clear();
                NomSvidBox.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
