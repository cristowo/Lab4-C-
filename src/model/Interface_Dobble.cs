using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    internal interface Interface_Dobble
    {
        /**
     * Obetiene la nth carta de 0 hasta n-1
     * @ param Integer numero
     * @return Card carta
     */
    public Card nthCard(int n);

    /**
     * Obtiene un true si el mazo es valido o obtiene un false si el mazo es invalido
     * @return Boolean
     */
    public bool isDobble();

    /**
     * Obtiene un Interger con la cantidad de cartas
     * @return Integer largo
     */
    public int numCards();

    /**
     * Obtiene el total de cartas de 1 carta de muestra
     * @ param Card carta
     * @return Integer total de cartas
     */
    public int FindTotalCards(Card carta);

    /**
     * Obtiene el total de elementos requeridos para obtener un mazo, en base de una 1 carta de muestra
     * @return Integer total de elementos
     */
    public int ElemReque(Card carta);

    /**
     * Obtiene las cartas faltantes para un mazo incompleto
     * @return Arraylist<Cards> mazo de cartas faltantes
     */
    public List<Card> missingCards();

    /**
     * Obtiene un true si el ambos mazo son iguales, o un false en caso contrario
     * @return Boolean
     */
    public bool Equals(Object o);
    }
}
