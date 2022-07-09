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
using model;

namespace view
{
    /// <summary>
    /// Lógica de interacción para resultado.xaml
    /// </summary>
    public partial class resultado : Window
    {
        private DobbleGame tablero;
        public resultado(DobbleGame tablero)
        {
            InitializeComponent();
            this.tablero = tablero;
            this.resultado1.Text = tablero.resultado();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window1();
            window.Show();
            this.Close();
        }
    }
}
