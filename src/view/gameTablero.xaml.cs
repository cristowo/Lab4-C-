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
    /// Lógica de interacción para gameTablero.xaml
    /// </summary>
    /// 
    public partial class gameTablero : Window
    {
        private DobbleGame tablero;
        public gameTablero(DobbleGame tablero)
        {
            InitializeComponent();
            this.tablero = tablero;
            this.turn.Text = tablero.whoseTurnIs().ToString();
            this.turnN.Text = tablero.getTurnForName(tablero.whoseTurnIs().ToString()).ToString();
            this.Points.Text = tablero.getScoreForName(tablero.whoseTurnIs().ToString()).ToString();
            this.c1.Text = tablero.getMazoDobblegame().getMazo()[0].ToString();
            this.c2.Text = tablero.getMazoDobblegame().getMazo()[1].ToString();
        }

        private void spotit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                num = int.Parse(element.Text);
                if(num >= 1)
                {
                    string name;
                    name = tablero.whoseTurnIs().ToString();
                    tablero.play(num, tablero.getMazoDobblegame(), tablero.getPosicionForName(name));

                    if (1 < tablero.getMazoDobblegame().getMazo().Count())
                    {
                        Window window = new gameTablero(tablero);
                        window.Show();
                        this.Close();
                    }
                    else
                    {
                        tablero.setEstado("Finalizado");
                        Window window = new resultado(tablero);
                        window.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Intente jugar con los números que estan en la mesa");
                }
            
            }
            catch
            {
                MessageBox.Show("Por favor solo ingresar números");
            }
        }

        private void pass_Click(object sender, RoutedEventArgs e)
        {
            string name;
            name = tablero.whoseTurnIs().ToString();
            tablero.play(0, tablero.getMazoDobblegame(), tablero.getPosicionForName(name));
            Window window = new gameTablero(tablero);
            window.Show();
            this.Close();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            tablero.setEstado("Finalizado");
            Window window = new resultado(tablero);
            window.Show();
            this.Close();
        }
    }
}
