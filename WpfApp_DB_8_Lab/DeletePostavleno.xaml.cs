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
    /// Логика взаимодействия для DeletePostavleno.xaml
    /// </summary>
    public partial class DeletePostavleno : Window
    {
        db_icv3Entities context;
        public DeletePostavleno()
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
                SumBox.Text = post.Цена.ToString();
            }
            catch (Exception ex)
            {
                TovarBox.SelectedItem = -1;
                TovarBox.Text = "";
                CountBox.Clear();
                SumBox.Clear();
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
                SumBox.Text = post.Цена.ToString();
            }
            catch (Exception ex)
            {
                TovarBox.SelectedItem = -1;
                TovarBox.Text = "";
                CountBox.Clear();
                SumBox.Clear();
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeletePostav(object sender, RoutedEventArgs e)
        {
            try
            {
                Поставлено post = NomDogovBox.SelectedItem as Поставлено;
                post = context.Поставлено.ToList().First(x => x.НомерДоговора.ToString() == NomDogovBox.Text
                    && x.Товар == TovarBox.Text);
                context.Поставлено.Remove(post);
                context.SaveChanges();
                Status.Content = "Запись успешно удалена";
                NomDogovBox.SelectedItem = -1;
                NomDogovBox.Text = "";
                TovarBox.SelectedItem = -1;
                TovarBox.Text = "";
                CountBox.Clear();
                SumBox.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
