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
    /// Логика взаимодействия для DeleteYuridicheskieLitca.xaml
    /// </summary>
    public partial class DeleteYuridicheskieLitca : Window
    {
        db_icv3Entities context;
        public DeleteYuridicheskieLitca()
        {
            InitializeComponent();
            context = new db_icv3Entities();
            KodPostavBox.ItemsSource = context.ЮридическиеЛица.ToList();
        }
        private void ChangePostav(object sender, EventArgs e)
        {
            if (KodPostavBox.SelectedIndex == -1) return;
            ЮридическиеЛица post = KodPostavBox.SelectedItem as ЮридическиеЛица;
            NameBox.Text = post.Названия;
            NalogNomBox.Text = post.НалоговыйНомер;
            NomSvidBox.Text = post.НомерСвидетельства;
            Status.Content = "";
        }

        private void DeletePostav(object sender, RoutedEventArgs e)
        {
            try
            {
                ЮридическиеЛица post = KodPostavBox.SelectedItem as ЮридическиеЛица;
                context.ЮридическиеЛица.Remove(post);
                context.SaveChanges();
                Status.Content = "Запись успешно удалена";
                KodPostavBox.SelectedItem = -1;
                KodPostavBox.Text = "";
                NameBox.Clear();
                NalogNomBox.Clear();
                NomSvidBox.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
