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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void NumE_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void NumP_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Continuar1_Click(object sender, RoutedEventArgs e)
        {
            int numE;
            numE = int.Parse(NumE.Text);
            int numP;
            numP = int.Parse(NumP.Text);
            DobbleGame tablero = new DobbleGame(numP,numE,"Stack");
            Window window = new Register(tablero);
            window.Show();
            this.Close();
        }
    }
}
