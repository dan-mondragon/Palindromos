using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Palíndromo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                IEnumerable<string> palabras = File.ReadLines(openFileDialog.FileName);
                string resultado = "";
                
                foreach(string palabra in palabras)
                {
                    if(palabra.ToUpper().Equals(invertir(palabra.ToUpper())))
                    {
                        resultado += palabra + "\t\t\t Es palíndromo \n";
                    }
                    else
                    {
                        resultado += palabra + "\t\t\t No es palíndromo \n";
                    }
                }

                txtPalabras.Text = resultado;
            }
        }

        private static string invertir(string frase)
        {
            string invertido = "";
            for (int i = frase.Length - 1; i >= 0; i--)
                invertido = invertido + frase.Substring(i, 1);
            return invertido;
        }
    }
}
