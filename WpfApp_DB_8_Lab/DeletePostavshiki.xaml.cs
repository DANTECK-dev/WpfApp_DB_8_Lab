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
    /// Логика взаимодействия для DeletePostavshiki.xaml
    /// </summary>
    public partial class DeletePostavshiki : Window
    {
        db_icv3Entities context;

        public DeletePostavshiki()
        {
            InitializeComponent();
            context = new db_icv3Entities();
            KodPostavBox.ItemsSource = context.Поставщики.ToList();
        }
        private void ChangePostav(object sender, EventArgs e)
        {
            if (KodPostavBox.SelectedIndex == -1) return;
            Поставщики post = KodPostavBox.SelectedItem as Поставщики;
            AdresBox.Text = post.Адрес;
            CommentBox.Text = post.Примечание;
            Status.Content = "";
        }

        private void DeletePostav(object sender, RoutedEventArgs e)
        {
            try
            {
                Поставщики post = KodPostavBox.SelectedItem as Поставщики;
                context.Поставщики.Remove(post);
                context.SaveChanges();
                Status.Content = "Запись успешно удалена";
                KodPostavBox.SelectedItem = -1;
                KodPostavBox.Text = "";
                AdresBox.Clear();
                CommentBox.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
