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
    /// Lógica de interacción para playdemo.xaml
    /// </summary>
    public partial class playdemo : Window
    {
        private DobbleGame tablero;
        public playdemo(DobbleGame tablero)
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
            string name;
            name = tablero.whoseTurnIs().ToString();

            Random random = new Random();
            int num;
            int numRandom = random.Next(3);
            if (numRandom <= 1) //entrega el resultado correcto en un 66% de posibilidad
            {
                num = tablero.getMazoDobblegame().getMazo()[0].EleComun(tablero.getMazoDobblegame().getMazo()[1])[0];
            }
            else //entrega solo el primero numero (puede ganar o perder)
            {
                num = tablero.getMazoDobblegame().getMazo()[0].getCarta()[0];
            }
            if (tablero.getMazoDobblegame().getMazo()[0].EleComun(tablero.getMazoDobblegame().getMazo()[1])[0] == num)
            {
                MessageBox.Show("El CPU ha acertado!!!");
            }
            else
            {
                MessageBox.Show("El CPU ha fallado:c");
            }
            tablero.play(num, tablero.getMazoDobblegame(), tablero.getPosicionForName(name));

            if (1 < tablero.getMazoDobblegame().getMazo().Count())
            {
                Window window = new playdemo(tablero);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Demostración Terminada");
                tablero.setEstado("Finalizado");
                Window window = new resultado(tablero);
                window.Show();
                this.Close();
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Demostración Terminada");
            tablero.setEstado("Finalizado");
            Window window = new resultado(tablero);
            window.Show();
            this.Close();
        }
    }
}
