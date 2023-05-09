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
    /// Логика взаимодействия для EditFizicheskiLitca.xaml
    /// </summary>
    public partial class EditFizicheskiLitca : Window
    {
        db_icv3Entities context;
        public EditFizicheskiLitca()
        {
            InitializeComponent();
            context = new db_icv3Entities();
            KodPostavBox.ItemsSource = context.ФизическиеЛица.ToList();
        }

        private void ChangeKodPostav(object sender, EventArgs e)
        {
            if (KodPostavBox.SelectedIndex == -1) return;
            ФизическиеЛица post = KodPostavBox.SelectedItem as ФизическиеЛица;
            SurnameBox.Text = post.Фамилия.ToString();
            NameBox.Text = post.Имя.ToString();
            PatnomicBox.Text = post.Отчество.ToString();
            NomSvidBox.Text = post.НомерСвидетельства.ToString();
            Status.Content = "";
        }

        private void EditFizLitca(object sender, RoutedEventArgs e)
        {
            try
            {
                ФизическиеЛица post = KodPostavBox.SelectedItem as ФизическиеЛица;
                context.ФизическиеЛица.Find(post.КодПоставщика).Фамилия = SurnameBox.Text;
                context.ФизическиеЛица.Find(post.КодПоставщика).Имя = NameBox.Text;
                context.ФизическиеЛица.Find(post.КодПоставщика).Отчество = PatnomicBox.Text;
                context.ФизическиеЛица.Find(post.КодПоставщика).НомерСвидетельства = NomSvidBox.Text;
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
