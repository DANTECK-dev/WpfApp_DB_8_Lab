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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_DB_8_Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window _window;
        public MainWindow()
        {
            InitializeComponent();
        }


        ////////////////////    Просмотр        ////////////////////////////////////////////////////////////

        private void OpenViewPostavshiki(object sender, RoutedEventArgs e)
        {
            ViewPostavshiki form = new ViewPostavshiki();
            form.Show();
        }
        private void OpenViewDogovory(object sender, RoutedEventArgs e)
        {
            ViewDogovory form = new ViewDogovory();
            form.Show();
        }
        private void OpenViewFizicheskiLitca(object sender, RoutedEventArgs e)
        {
            ViewFizicheskiLitca form = new ViewFizicheskiLitca();
            form.Show();
        }
        private void OpenViewYuridicheskieLitca(object sender, RoutedEventArgs e)
        {
            ViewYuridicheskieLitca form = new ViewYuridicheskieLitca();
            form.Show();
        }
        private void OpenViewPostavleno(object sender, RoutedEventArgs e)
        {
            ViewPostavleno form = new ViewPostavleno();
            form.Show();
        }

        ////////////////////    Редактирование    /////////////////////////////////////////////////////////

        private void OpenEditPostavshiki(object sender, RoutedEventArgs e)
        {
            EditPostavshiki form = new EditPostavshiki();
            form.Show();
        }
        private void OpenEditDogovory(object sender, RoutedEventArgs e)
        {
            EditDogovory form = new EditDogovory();
            form.Show();
        }
        private void OpenEditFizicheskiLitca(object sender, RoutedEventArgs e)
        {
            EditFizicheskiLitca form = new EditFizicheskiLitca();
            form.Show();
        }
        private void OpenEditYuridicheskieLitca(object sender, RoutedEventArgs e)
        {
            EditYuridicheskieLitca form = new EditYuridicheskieLitca();
            form.Show();
        }
        private void OpenEditPostavleno(object sender, RoutedEventArgs e)
        {
            EditPostavleno form = new EditPostavleno();
            form.Show();
        }

        ////////////////////    Просмотр       ////////////////////////////////////////////////////////////

        private void OpenAddPostavshiki(object sender, RoutedEventArgs e)
        {
            AddPostavshiki form = new AddPostavshiki();
            form.Show();
        }
        private void OpenAddDogovory(object sender, RoutedEventArgs e)
        {
            AddDogovory form = new AddDogovory();
            form.Show();
        }
        private void OpenAddFizicheskiLitca(object sender, RoutedEventArgs e)
        {
            AddFizicheskiLitca form = new AddFizicheskiLitca();
            form.Show();
        }
        private void OpenAddYuridicheskieLitca(object sender, RoutedEventArgs e)
        {
            AddYuridicheskieLitca form = new AddYuridicheskieLitca();
            form.Show();
        }
        private void OpenAddPostavleno(object sender, RoutedEventArgs e)
        {
            AddPostavleno form = new AddPostavleno();
            form.Show();
        }

        ////////////////////    Удаление      ////////////////////////////////////////////////////////////

        private void OpenDeletePostavshiki(object sender, RoutedEventArgs e)
        {
            DeletePostavshiki form = new DeletePostavshiki();
            form.Show();
        }
        private void OpenDeleteDogovory(object sender, RoutedEventArgs e)
        {
            DeleteDogovory form = new DeleteDogovory();
            form.Show();
        }
        private void OpenDeleteFizicheskiLitca(object sender, RoutedEventArgs e)
        {
            DeleteFizicheskiLitca form = new DeleteFizicheskiLitca();
            form.Show();
        }
        private void OpenDeleteYuridicheskieLitca(object sender, RoutedEventArgs e)
        {
            DeleteYuridicheskieLitca form = new DeleteYuridicheskieLitca();
            form.Show();
        }
        private void OpenDeletePostavleno(object sender, RoutedEventArgs e)
        {
            DeletePostavleno form = new DeletePostavleno();
            form.Show();
        }

        ////////////////////    Запросы       ////////////////////////////////////////////////////////////

        private void OpenQuery1Window(object sender, RoutedEventArgs e)
        {
            var form = new Query1Window();
            form.Show();
        }
        private void OpenQuery2Window(object sender, RoutedEventArgs e)
        {
            var form = new Query2Window();
            form.Show();
        }
        private void OpenQuery3Window(object sender, RoutedEventArgs e)
        {
            var form = new Query3Window();
            form.Show();
        }
    }
}
