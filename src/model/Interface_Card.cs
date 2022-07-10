using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    internal interface Interface_Card
    {
        /**
     * Obtiene la longitud de una carta (Integer) de una carta (Card)
     * @return Integer longitud de una carta
     */
    public int TamCard();

    /**
     * Añade una numero (Integer) a una carta(card)
     * @ param card (ArrayList<Integer>).
     */
    public void addECarta(int a);

    /**
     * Comprueba igualdad entre 2 cartas
     * * @return Boolean
     */
    public bool Equals(Object o);
    }
}
