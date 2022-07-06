using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
public class DobbleGame
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
        return numPlayers;
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
    public void registUser(string nombre)
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
            }
        }
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
        if (modalidad.Equals("Stack"))
        {
            //Saltar turno
            if (elem == 0)
            {
                ListPlayers[posicion].setTurno(ListPlayers[posicion].getTurno() + 1);
            }
            // Terminar juego
            else if (elem < 0)
            {
                setEstado("Finalizado");
            }
            else
            {
                // Respuesta correcta
                if (elem.Equals(mazo.getMazo()[0].EleComun(mazo.getMazo()[1])[0]))
                {
                    ListPlayers[posicion].setPuntos(ListPlayers[posicion].getPuntos() + 1);
                    mazoDobblegame.EliminarCard();
                }
                // Respuesta incorrecta
                ListPlayers[posicion].setTurno(ListPlayers[posicion].getTurno() + 1);
            }
        }
        // Modalidad Player vs CPU
        else if (modalidad.Equals("VSCPU"))
        {
            // Saltar turno
            if (elem == 0)
            {
                ListPlayers[posicion].setTurno(ListPlayers[posicion].getTurno() + 1);
            }
            // Finalizar juego
            else if (elem < 0)
            {
                setEstado("Finalizado");
            }
            else
            {
                // Respuesta correcta
                if (elem.Equals(mazo.getMazo()[0].EleComun(mazo.getMazo()[1])[0]))
                {
                    ListPlayers[posicion].setPuntos(ListPlayers[posicion].getPuntos() + 1);
                    mazoDobblegame.EliminarCard();
                }
                // Respuesta incorrecta
                ListPlayers[posicion].setTurno(ListPlayers[posicion].getTurno() + 1);
            }
        }
    }

    /**
     * Muestra el resutalado de un juego finalizado
     */
    public void resultado()
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
            string result = new string(puestos.ToString().Replace("[", ""));
            result = result.Replace("]", "");
                /*
            System.out.println("Ganadores: " + result);
            System.out.println("Con puntaje de: " + getScoreForName(puestos.get(0)) + " puntos.");*/
             //ver como mostrar ganadores (return string)
        }
        // Caso de victoria
        else
        {
                /*
            System.out.println("Ganador: " + puestos.get(0));
            System.out.println("Con puntaje de: " + getScoreForName(puestos.get(0)) + " puntos.");*/
        }
    }

    /**
     * Obtiene un True si dos games son iguales, contrario a esto obtiene un false
     * @return Boolean
     */
    /*
    @Override
        public boolean equals(Object o)
    {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        DobbleGame that = (DobbleGame)o;
        if (Objects.equals(estado, that.estado) && mazoDobblegame.equals(mazoDobblegame) && Objects.equals(numPlayers, that.numPlayers) && Objects.equals(modalidad, that.modalidad))
        {
            if (ListPlayers.size() != that.ListPlayers.size())
            {
                return false;
            }
            else
            {
                int aux = 0;
                for (int i = 0; i < ListPlayers.size(); i++)
                {
                    for (int j = 0; j < that.ListPlayers.size(); j++)
                    {
                        if (ListPlayers.get(i).equals(ListPlayers.get(j)))
                        {
                            aux++;
                        }
                    }
                }
                if (aux == ListPlayers.size())
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
    }*/
    /**
     * Convierte el contendio de DobbleGame a String
     * @return estado, mazoDobblegame, numPlayers, modalidad, ListPlayers como String
     */
        public override string ToString()
    {
        return "DobbleGame{" +
                "estado='" + estado + '\'' +
                ", mazoDobblegame=" + mazoDobblegame +
                ", numPlayers=" + numPlayers +
                ", modalidad='" + modalidad + '\'' +
                ", ListPlayers=" + ListPlayers +
                '}';
    }
    }
}