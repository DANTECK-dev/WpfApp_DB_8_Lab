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
    /// Логика взаимодействия для DeleteDogovory.xaml
    /// </summary>
    public partial class DeleteDogovory : Window
    {
        db_icv3Entities context;
        public DeleteDogovory()
        {
            InitializeComponent();
            context = new db_icv3Entities();
            NomDogovBox.ItemsSource = context.Договоры.ToList();
        }
        private void ChangePostav(object sender, EventArgs e)
        {
            if (NomDogovBox.SelectedIndex == -1) return;
            Договоры post = NomDogovBox.SelectedItem as Договоры;
            DataDogovBox.Text = post.ДатаДоговора.ToString();
            KodPostavBox.Text = post.ДатаДоговора.ToString();
            CommentBox.Text = post.Комментарий;
            Status.Content = "";
        }

        private void DeletePostav(object sender, RoutedEventArgs e)
        {
            try
            {
                Договоры post = NomDogovBox.SelectedItem as Договоры;
                context.Договоры.Remove(post);
                context.SaveChanges();
                Status.Content = "Запись успешно удалена";
                NomDogovBox.SelectedItem = -1;
                NomDogovBox.Text = "";
                DataDogovBox.Clear();
                KodPostavBox.Clear();
                CommentBox.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
