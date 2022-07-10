using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
public class Card:Interface_Card
    {
    // Atributos
    private List<int> carta;

    // Metodo
    public Card(){
        this.carta = new List<int>();
    }

    /**
     * Obtiene la lista de enteros (ArrayList<Integer>) de una carta (Card)
     * @return ArrayList<Integer> lista de enteros
     */
    public List<int> getCarta(){
        return carta;
    }

    /**
     * Modifica la lista de enteros (ArrayList<Integer>) de una carta (Card)
     * @param carta (ArrayList<Integer>). La carta
     */
    public void setCarta(List<int> carta){
        this.carta = carta;
    }

    /**
     * Obtiene la longitud de una carta (Integer) de una carta (Card)
     * @return Integer longitud de una carta
     */
    public int TamCard(){
        return carta.Count();
    }
    
    /**
     * Obtiene una lista con los numeros en comun entre 2 cartas
     * @return ArrayList<Integer> lista de enteros
     */
    public List<int> EleComun(Card carta2){
            Card aux = new Card();
            for (int i = 0; i < carta2.getCarta().Count(); i++)
            {
                for (int j = 0; j < this.carta.Count(); j++)
                {
                    if(carta2.getCarta()[i] == this.carta[j])
                    {
                        aux.addECarta(carta2.getCarta()[i]);
                    }
                }
            }
        return aux.getCarta();
    }

    /**
     * Añade una numero (Integer) a una carta(card)
     * @ param card (ArrayList<Integer>).
     */
    public void addECarta(int a){
        carta.Add(a);
    }

    /**
     * Elimina todos los numeros de una carta(Card)
     * @return carta
     */
    public List<int> Vaciar(){
        carta.Clear();
        return carta;
    }

    /**
     * Vacia una carta y copia los elemntos de otra
     * @ param carta (Card)
     */
    public void CopyCard(Card card2){
        card2.Vaciar();
        for (int i = 0; i < carta.Count(); i++){
            card2.addECarta(carta[i]);
        }
    }

    /**
     * Desordena los numeros de una carta (Card)
     * @ param carta (Card).
     */
    /*public void cardRandom()
    {
        Collections.shuffle(carta);
    }*/

    /**
     * Comprueba igualdad entre 2 cartas
     * * @return Boolean
     */
        public override bool Equals(Object o){
        Card card = (Card)o;
        Card card2 = new Card();
        card2.setCarta(carta);
        if (carta.Count() == card.TamCard() && card.EleComun(card2).Count() == carta.Count()){
            return true;
        }else{
            return false;
        }}
        /**
         * convierte carta a String
         * * @return carta String
         */
        public override String ToString()
        {
            String salida = "";
            for (int i = 0; i < carta.Count(); i++)
            {
                salida += carta[i] + " ";
            }
            return salida;

        }
    }
}
