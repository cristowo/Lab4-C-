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
    /// Lógica de interacción para datosdemo.xaml
    /// </summary>
    public partial class datosdemo : Window
    {
        public datosdemo()
        {
            InitializeComponent();
        }

        private void Continuar1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numE;
                numE = int.Parse(NumE.Text);
                Dobble aux = new Dobble(numE, -1, false);
                if (aux.isDobble())
                {
                    DobbleGame tablero = new DobbleGame(2, numE, "CPU");
                    tablero.registUser("EVA01");
                    tablero.registUser("EVA02");
                    Window window = new playdemo(tablero);
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Recuerde que solo se admiten mazos validos. Ej: 3, 4, 6, 8");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Formato incorrecto, por favor solo usar números");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
