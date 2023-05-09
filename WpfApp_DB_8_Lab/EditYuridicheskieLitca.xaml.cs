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
    /// Логика взаимодействия для EditYuridicheskieLitca.xaml
    /// </summary>
    public partial class EditYuridicheskieLitca : Window
    {
        db_icv3Entities context;
        public EditYuridicheskieLitca()
        {
            InitializeComponent();
            context = new db_icv3Entities();
            KodPostavBox.ItemsSource = context.ЮридическиеЛица.ToList();
        }

        private void ChangeKodPostav(object sender, EventArgs e)
        {
            if (KodPostavBox.SelectedIndex == -1) return;
            ЮридическиеЛица post = KodPostavBox.SelectedItem as ЮридическиеЛица;
            NameBox.Text = post.Названия.ToString();
            NalogNomBox.Text = post.НалоговыйНомер.ToString();
            NomSvidBox.Text = post.НомерСвидетельства.ToString();
            Status.Content = "";
        }

        private void EditYriLitca(object sender, RoutedEventArgs e)
        {
            try
            {
                ЮридическиеЛица post = KodPostavBox.SelectedItem as ЮридическиеЛица;
                context.ЮридическиеЛица.Find(post.КодПоставщика).Названия = NameBox.Text;
                context.ЮридическиеЛица.Find(post.КодПоставщика).НалоговыйНомер = NalogNomBox.Text;
                context.ЮридическиеЛица.Find(post.КодПоставщика).НомерСвидетельства = NomSvidBox.Text;
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
