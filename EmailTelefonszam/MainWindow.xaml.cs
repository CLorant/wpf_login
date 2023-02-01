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
using System.Text.RegularExpressions;

namespace EmailTelefonszam
{
    public partial class MainWindow : Window
    {
        const string emailPattern = @"[^@]+\@[^\.]+\..+";
        const string telefonPattern = @"\d{2}[-]\d{2}[-]\d{7}";

        public MainWindow()
        {
            InitializeComponent();
        }

        void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            string gif;
            TextBox param;
            if (sender.Equals(EmailTextBox))
            {
                gif = "email.gif";
                param = EmailTextBox;
            }
            else
            {
                gif = "telefonszam.gif";
                param = TelefonszamTextBox;
            }

            if (param.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource = new BitmapImage(new Uri(gif, UriKind.Relative));
                param.Background = textImageBrush;
            }
            else
            {
                var bc = new BrushConverter();
                param.Background = (Brush)bc.ConvertFrom("#FF666772");
            }
        }

        private void BejelentkezesGomb_Click(object sender, RoutedEventArgs e)
        {
            var email = new Regex(emailPattern, RegexOptions.Compiled);
            var telefon = new Regex(telefonPattern, RegexOptions.Compiled);
            if (!email.IsMatch(EmailTextBox.Text) && !telefon.IsMatch(TelefonszamTextBox.Text))
            {
                EmailTextBox.Text = "";
                TelefonszamTextBox.Text = "";
                MessageBox.Show("Helytelen formátumú email és telefonszám!");
            }
            else if (!email.IsMatch(EmailTextBox.Text))
            {
                EmailTextBox.Text = "";
                MessageBox.Show("Helytelen formátumú email!");
            }
            else if (!telefon.IsMatch(TelefonszamTextBox.Text))
            {
                TelefonszamTextBox.Text = "";
                MessageBox.Show("Helytelen formátumú telefonszám!");
            }
            else
            {
                Felhasznalo f = new Felhasznalo(EmailTextBox.Text, TelefonszamTextBox.Text);
                bool talalt = false;
                for (int i = 0; i < Felhasznalo.felhasznaloLista.Count; i++)
                {
                    if (f.Email == Felhasznalo.felhasznaloLista[i].Email && f.Telefonszam == Felhasznalo.felhasznaloLista[i].Telefonszam)
                    {
                        talalt = true;
                    }
                }
                if (talalt)
                {
                    Lista lista = new Lista();
                    lista.Show();
                    Close();
                }
                else
                {
                    EmailTextBox.Text = "";
                    TelefonszamTextBox.Text = "";
                    MessageBox.Show("Helytelen bejelentkezési adat(ok)!");
                }
            }
        }
    }
}
