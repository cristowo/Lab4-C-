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
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private DobbleGame tablero;
        public Register(DobbleGame tablero)
        {
            InitializeComponent();
            this.tablero = tablero;
            this.nprest.Text = tablero.getNumPlayers().ToString();
        }

        private void confirmReg_Click(object sender, RoutedEventArgs e)
        {
            string newname = newP.Text;
            if (tablero.registUser(newname) == 1)
            {
                if (0 == tablero.getNumPlayers())
                {
                    MessageBox.Show("Este modo consiste en que debe ingresar el elemento en común entre 2 cartas para poder ganas puntos mientras compites contra el otro jugador.", "REGLAS");
                    Window window = new gameTablero(tablero);
                    window.Show();
                    this.Close();
                }
                else
                {
                    Window window = new Register(tablero);
                    window.Show();
                    this.Close();
                }
            }
            else if(tablero.registUser(newname) == 2)
            {
                if (0 == tablero.getNumPlayers())
                {
                    MessageBox.Show("Este modo consiste en que debe ingresar el elemento en común entre 2 cartas para poder ganas puntos mientras compites contra el otro jugador.", "REGLAS");
                    Window window = new gameTablero(tablero);
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Jugador ya registrado!!!");
                    Window window = new Register(tablero);
                    window.Show();
                    this.Close();
                }
            }
        }
    }
}
