using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
public class DobbleGame:Interface_DobbleGame
    {
    private string estado;
    private Dobble mazoDobblegame;
    private int numPlayers;
    private string modalidad;
    private List<Player> ListPlayers;


    public DobbleGame(int NumPlayers, int TamCardSet, string modo)
    {
        ListPlayers = new List<Player>();
        mazoDobblegame = new Dobble((TamCardSet), -1, true);
        modalidad = modo;
        estado = "Preparacion";
        numPlayers = NumPlayers;
    }

    /**
     * Obtiene el estado del game
     * @return String estado
     */
    public string getEstado()
    {
        return estado;
    }

    /**
     * Modifica estado de un juego (String)
     * @ param estado (String)
     */
    public void setEstado(string estado)
    {
        this.estado = estado;
    }

    /**
     * Obtiene el mazo del juego (Dobble)
     * @return mazo (Dobble)
     */
    public Dobble getMazoDobblegame()
    {
        return mazoDobblegame;
    }

    /**
     * Modifica el mazo del juego (Dobble)
     * @ param mazo (Dobble)
     */
    public void setMazoDobblegame(Dobble mazoDobblegame)
    {
        this.mazoDobblegame = mazoDobblegame;
    }

    /**
     * Obtiene el numero de jugadores (Integer)
     * @return numero de players (Innteger)
     */
    public int getNumPlayers()
    {
        return Convert.ToInt32(numPlayers);
    }

    /**
     * Modifica el numero de jugadores (Integer)
     * @ param Integer numero
     */
    public void setNumPlayers(int numPlayers)
    {
        this.numPlayers = numPlayers;
    }

    /**
     * Obtiene un String con la modalidad actual del juego
     * @return String modalidad
     */
    public String getModalidad()
    {
        return modalidad;
    }

    /**
     * Modifica la modalidad (String)
     * @ param modalidad (String)
     */
    public void setModalidad(String modalidad)
    {
        this.modalidad = modalidad;
    }

    /**
     * Obtiene un Arraylist de los jugadores (Arraylist<Player>)
     * @return Lista de jugadores (Arraylist<Player>)
     */
    public List<Player> getListPlayers()
    {
        return ListPlayers;
    }

    /**
     * Modifica la lista de jugadores (Arraylist<Player>)
     * @ param Lista de jugadores (Arraylist<Player>)
     */
    public void setListPlayers(List<Player> listPlayers)
    {
        ListPlayers = listPlayers;
    }

    /**
     * Registra a un usuario, en donde si esta repetido no se agrega
     * @ param String nombre
     */
    public int registUser(string nombre)
    {
        if (0 < numPlayers)
        {
            bool repetido = false;
            for (int i = 0; i < ListPlayers.Count(); i++)
            {
                string nameAux = new string(ListPlayers[i].getName());
                if (nameAux.Equals(nombre))
                {
                    repetido = true;
                    //poner aqui algun mensaje de usuario registrado
                }
            }
            if (repetido == false)
            {
                Player jugador = new Player(nombre);
                ListPlayers.Add(jugador);
                numPlayers = numPlayers - 1;
                return 1;//registrado
            }
            return 2;//repitido
        }
        return 3;//ya no se puede registrar mas
    }

    /**
     * Obtiene un String con el nombre del jugador en turno actual
     * @return String name
     */
    public string whoseTurnIs()
    {
        int menor = ListPlayers[0].getTurno();
        string nameMenor = new string(ListPlayers[0].getName());
        for (int i = 1; i < ListPlayers.Count(); i++)
        {
            if (ListPlayers[i].getTurno() < menor)
            {
                menor = ListPlayers[i].getTurno();
                nameMenor = ListPlayers[i].getName();
            }
        }
        return nameMenor;
    }

    /**
     * Obtiene un Integer con el puntaje de un jugador segun su nombre
     * @ param String nombre
     * @return Integer puntaje
     */
    public int getScoreForName(string name)
    {
        int i = 0;
        while (!ListPlayers[i].getName().Equals(name))
        {
            i++;
        }
        return ListPlayers[i].getPuntos();
    }

    /**
     * Obtiene un Integer con el turno de un jugador segun su nombre
     * @ param String nombre
     * @return Integer turno
     */
    public int getTurnForName(string name)
    {
        int i = 0;
        while (!ListPlayers[i].getName().Equals(name))
        {
            i++;
        }
        return ListPlayers[i].getTurno();
    }

    /**
     * Obtiene la posicion de un jugador en la lista segun su nombre
     * @ param String nombre
     * @return Integer posicion
     */
    public int getPosicionForName(string name)
    {
        for (int i = 0; i < ListPlayers.Count(); i++)
        {
            if (ListPlayers[i].getName().Equals(name))
            {
                return i;
            }
        }
        return 0;
    }

    /**
     * Modifica el game segun su modalidad
     * @ param Integer Elemento en común, Dobble el mazo en juego, Integer posicion del jugador
     */
    public void play(int elem, Dobble mazo, int posicion)
    {
        // Caso para jugadores en Stack Mode
        if (modalidad.Equals("Stack") || modalidad.Equals("CPU"))
        {
            if (elem > 0)
            {
                if (elem.Equals(mazo.getMazo()[0].EleComun(mazo.getMazo()[1])[0]))
                {
                    ListPlayers[posicion].setPuntos(ListPlayers[posicion].getPuntos() + 1);
                    mazoDobblegame.EliminarCard();
                }
            }
            ListPlayers[posicion].setTurno(ListPlayers[posicion].getTurno() + 1);
        }

    }
    /**
     * Muestra el resutalado de un juego finalizado
     */
    public string resultado()
    {
        List<string> puestos = new List<string>();
        int mayor = 0;
        for (int i = 0; i < ListPlayers.Count(); i++)
        {
            if (mayor < ListPlayers[i].getPuntos())
            {
                mayor = ListPlayers[i].getPuntos();
                puestos.Clear();
                puestos.Add(ListPlayers[i].getName());
            }
            else if (mayor == ListPlayers[i].getPuntos())
            {
                puestos.Add(ListPlayers[i].getName());
            }
        }
        // Caso de empate
        if (1 < puestos.Count())
        {
                //caso empate
            string result = new string(String.Join(", ", puestos.ToArray()));
                return "Empate entre: " + result + "\n\r" + "Con puntaje de: " + getScoreForName(puestos[0]) + " puntos.";
            }
        // Caso de victoria
        else
        {
                return "Ganador: " + puestos[0] + "\n\r" + "Con puntaje de: " + getScoreForName(puestos[0]) + " puntos.";
            }
    }

    /**
     * Obtiene un True si dos games son iguales, contrario a esto obtiene un false
     * @return Boolean
     */
        public override bool Equals(Object o)
    {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        DobbleGame that = (DobbleGame)o;
        if (Object.Equals(estado, that.estado) && mazoDobblegame.Equals(mazoDobblegame) && Object.Equals(numPlayers, that.numPlayers) && Object.Equals(modalidad, that.modalidad))
        {
            if (ListPlayers.Count() != that.ListPlayers.Count())
            {
                return false;
            }
            else
            {
                int aux = 0;
                for (int i = 0; i < ListPlayers.Count(); i++)
                {
                    for (int j = 0; j < that.ListPlayers.Count(); j++)
                    {
                        if (ListPlayers[i].Equals(ListPlayers[j]))
                        {
                            aux++;
                        }
                    }
                }
                if (aux == ListPlayers.Count())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }
    /**
     * Convierte el contendio de DobbleGame a String
     * @return estado, mazoDobblegame, numPlayers, modalidad, ListPlayers como String
     */
        public override string ToString()
    {
        return "DobbleGame{" +
                "estado='" + estado.ToString() + '\'' +
                ", mazoDobblegame=" + mazoDobblegame.ToString() +
                ", numPlayers=" + numPlayers.ToString() +
                ", modalidad='" + modalidad.ToString() + '\'' +
                ", ListPlayers=" + ListPlayers.ToString() +
                '}';
        }
    }
}