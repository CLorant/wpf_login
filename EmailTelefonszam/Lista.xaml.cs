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

namespace EmailTelefonszam
{
    public partial class Lista : Window
    {
        public Lista()
        {
            InitializeComponent();
            BejelentkezesListaGrid.ItemsSource = Felhasznalo.felhasznaloLista;
        }
        

        private void BejelentkezesGomb_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
