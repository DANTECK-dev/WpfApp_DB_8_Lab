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
    /// Логика взаимодействия для EditPostavleno.xaml
    /// </summary>
    public partial class EditPostavleno : Window
    {
        db_icv3Entities context;
        public EditPostavleno()
        {
            InitializeComponent();
            context = new db_icv3Entities();
            NomDogovBox.ItemsSource = context.Поставлено.GroupBy(x => x.НомерДоговора).Select(y => y.FirstOrDefault()).ToList();
            TovarBox.ItemsSource = context.Поставлено.GroupBy(x => x.Товар).Select(y => y.FirstOrDefault()).ToList();
        }

        private void ChangeNomDogov(object sender, EventArgs e)
        {
            Status.Content = "";
            if (NomDogovBox.SelectedIndex == -1) return;
            try
            {
                if (TovarBox.SelectedIndex == -1) return;

                Поставлено post = NomDogovBox.SelectedItem as Поставлено;
                post = context.Поставлено.ToList().First(x => x.НомерДоговора.ToString() == NomDogovBox.Text
                    && x.Товар == TovarBox.Text);
                CountBox.Text = post.Количество.ToString();
                SummBox.Text = post.Цена.ToString();

            }
            catch (Exception ex)
            {
                TovarBox.Text = "";
                TovarBox.SelectedIndex = -1;
                CountBox.Text = "";
                SummBox.Text = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ChangeTovar(object sender, EventArgs e)
        {
            Status.Content = "";
            if (TovarBox.SelectedIndex == -1) return;
            try
            {
                if (NomDogovBox.SelectedIndex == -1) return;

                Поставлено post = NomDogovBox.SelectedItem as Поставлено;
                post = context.Поставлено.ToList().First(x => x.НомерДоговора.ToString() == NomDogovBox.Text
                    && x.Товар == TovarBox.Text);
                CountBox.Text = post.Количество.ToString();
                SummBox.Text = post.Цена.ToString();

            }
            catch (Exception ex)
            {
                TovarBox.Text = "";
                TovarBox.SelectedIndex = -1;
                CountBox.Text = "";
                SummBox.Text = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditPostav(object sender, RoutedEventArgs e)
        {
            try
            {
                Поставлено post = NomDogovBox.SelectedItem as Поставлено;
                post = context.Поставлено.ToList().First(x => x.НомерДоговора.ToString() == NomDogovBox.Text
                    && x.Товар == TovarBox.Text);
                context.Поставлено.Find(post.НомерДоговора, post.Товар).Количество = int.Parse(CountBox.Text);
                context.Поставлено.Find(post.НомерДоговора, post.Товар).Цена = (decimal)double.Parse(SummBox.Text);
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
