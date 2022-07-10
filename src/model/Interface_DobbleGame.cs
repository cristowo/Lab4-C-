using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    internal interface Interface_DobbleGame
    {
    /**
     * Registra a un usuario, en donde si esta repetido no se agrega
     * @ param String nombre
     */
    public int registUser (String nombre);

    /**
     * Obtiene un String con el nombre del jugador en turno actual
     * @return String name
     */
    public String whoseTurnIs();

    /**
     * Modifica el game segun su modalidad
     * @ param Integer Elemento en común, Dobble el mazo en juego, Integer posicion del jugador
     */
    public void play(int elem, Dobble mazo, int posicion);

    /**
     * Obtiene un True si dos games son iguales, contrario a esto obtiene un false
     * @return Boolean
     */
    public bool Equals(Object o);
    }
}
