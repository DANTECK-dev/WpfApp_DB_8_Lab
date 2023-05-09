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
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace WpfApp_DB_8_Lab
{
    /// <summary>
    /// Логика взаимодействия для EditDogovory.xaml
    /// </summary>
    public partial class EditDogovory : Window
    {
        db_icv3Entities context;
        DateTime? temp_time;
        public EditDogovory()
        {
            InitializeComponent();
            context = new db_icv3Entities();
            NomDogovBox.ItemsSource = context.Поставщики.ToList();
        }

        private void ChangeNomDogov(object sender, EventArgs e)
        {
            if (NomDogovBox.SelectedIndex == -1) return;
            Договоры post = NomDogovBox.SelectedItem as Договоры;
            DataDogovBox.Text = post.ДатаДоговора.ToString();
            temp_time = post.ДатаДоговора;
            KodPostavBox.Text = post.КодПоставщика.ToString();
            KommentBox.Text = post.Комментарий.ToString();
            Status.Content = "";
        }

        private void EditDogov(object sender, RoutedEventArgs e)
        {
            try
            {
                Договоры post = NomDogovBox.SelectedItem as Договоры;
                context.Договоры.Find(post.КодПоставщика).ДатаДоговора = temp_time;
                context.Договоры.Find(post.КодПоставщика).КодПоставщика = int.Parse(KodPostavBox.Text);
                context.Договоры.Find(post.КодПоставщика).Комментарий = KommentBox.Text;
                context.SaveChanges();
                Status.Content = "Запись успешно измененна";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void Changed(object sender, TextChangedEventArgs e)
        {
            Status.Content = "";
        }
    }
}
