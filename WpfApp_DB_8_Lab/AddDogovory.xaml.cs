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
    /// Логика взаимодействия для AddDogovory.xaml
    /// </summary>
    public partial class AddDogovory : Window
    {
        public AddDogovory()
        {
            InitializeComponent();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {

                db_icv3Entities context = new db_icv3Entities();
                Договоры post = new Договоры();
                post.ДатаДоговора = DateTime.Parse(DataDogovBox.Text);
                post.КодПоставщика = int.Parse(KodPostBox.Text);
                post.Комментарий = CommentBox.Text;
                context.Договоры.Add(post);
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
