using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Dobble:Interface_Dobble
    {
        private int Largo; //NumE
        private int NumC;
        private List<Card> mazo;

        /*-------------------------------------------------------------------------------------------
        * Definicion de Dooble (mazo)
        * --------------------------------------------------------------------------------------------- */
        public Dobble(int Largo, int NumC, bool Azar)
        {
            Largo = Largo - 1;
            List<Card> AllCards = new List<Card>();
            List<Card> AllCardsRandom = new List<Card>();
            List<Card> AllCardsCut = new List<Card>();
            Card cartita = new Card();

            for (int i = 1; i <= Largo + 1; i++)
            {
                cartita.addECarta(i);
            }
            AllCards.Add(cartita);

            for (int j = 1; j <= Largo; j++)
            {
                Card cartita2 = new Card();
                cartita2.addECarta(1);

                for (int k = 1; k <= Largo; k++)
                {
                    cartita2.addECarta(Largo * j + (k + 1));
                }
                AllCards.Add(cartita2);
            }
            for (int i = 1; i <= Largo; i++)
            {
                for (int j = 1; j <= Largo; j++)
                {
                    Card cartita3 = new Card();
                    cartita3.addECarta(i + 1);

                    for (int k = 1; k <= Largo; k++)
                    {
                        cartita3.addECarta(Largo + 2 + Largo * (k - 1) + (((i - 1) * (k - 1) + j - 1) % Largo));
                    }
                    AllCards.Add(cartita3);
                }
            }
            if (Azar == true)
            {
                Random random = new Random();
                int total = AllCards.Count();
                for (int i = 0; i < total; i++)
                {
                    int numRandom = random.Next(AllCards.Count());
                    AllCardsRandom.Add(AllCards[numRandom]);
                    AllCards.Remove(AllCards[numRandom]);
                }
                AllCards = AllCardsRandom;
            }

            if (NumC < 0)
            {
                this.mazo = AllCards;
            }
            if (NumC >= 0)
            {
                for (int i = 0; i < NumC; i++)
                {
                    AllCardsCut.Add(AllCards[i]);
                }
                this.mazo = AllCardsCut;
            }
        }

        /**
         * Obtiene un ArrayList de cartas
         * @return Arraylist<Card> mazo
         */
        public List<Card> getMazo()
        {
            return mazo;
        }

        /**
         * Modifica el mazo con uno nuevo
         * @ param mazo (Arraylist<Card>)
         */
        public void setMazo(List<Card> mazo)
        {
            this.mazo = mazo;
        }

        /**
         * Obtiene un Integer con el largo del mazo
         * @return Integer largo
         */
        public int getLargo()
        {
            return Largo;
        }

        /**
         * Modifica el largo de la lista
         * @ param Integer Largo nuevo
         */
        public void setLargo(int largo)
        {
            Largo = largo;
        }


        /**
         * Obetiene la nth carta de 0 hasta n-1
         * @ param Integer numero
         * @return Card carta
         */
        public Card nthCard(int n)
        {
            if (n < mazo.Count() && n > 0)
            {
                return mazo[n];
            }
            else
            {
                return null;
            }
        }

        /**
         * Obtiene un true si el mazo es valido o obtiene un false si el mazo es invalido
         * @return Boolean
         */
        public Boolean isDobble()
        {
            if (mazo.Count() == 0 || mazo.Count() == 1)
            {                                      // Caso mazo vacio
                return false;
            }
            int acum = 0;
            for (int i = 0; i < mazo.Count(); i++)
            {
                for (int j = i + 1; j < mazo.Count(); j++)
                {
                    if ((mazo[i]).TamCard() != (mazo[j]).TamCard())
                    {     //caso cuando hay una carta con mas o menos elementos
                        return false;
                    }
                }
            }
            for (int i = 0; i < mazo.Count(); i++)
            {
                if (((mazo[i]).EleComun(mazo[i])).Count() != (mazo[i]).TamCard())
                {   //caso cuando una carta tiene 1 o mas elementos repetidos
                    return false;
                }
            }
            for (int i = 0; i < mazo.Count(); i++)
            {
                for (int j = i + 1; j < mazo.Count(); j++)
                {
                    if ((mazo[i].EleComun(mazo[j])).Count() != 1)
                    {     //caso cuando hay 0 o mas de 1 elemento en comun
                        return false;
                    }
                }
            }
            return true;
        }

        /**
         * Obtiene un Interger con la cantidad de cartas
         * @return Integer largo
         */
        public int numCards()
        {
            int largo = mazo.Count();
            return largo;
        }

        /**
         * Obtiene el total de cartas de 1 carta de muestra
         * @ param Card carta
         * @return Integer total de cartas
         */
        public int FindTotalCards(Card carta)
        {
            int Tcard = ((carta.TamCard() - 1) ^ 2 + carta.TamCard());
            return Tcard;
        }

        /**
         * Obtiene el total de elementos requeridos para obtener un mazo, en base de una 1 carta de muestra
         * @return Integer total de elementos
         */
        public int ElemReque(Card carta)
        {
            int EReq = ((carta.TamCard() - 1) ^ 2 + carta.TamCard());
            return EReq;
        }

        /**
         * Obtiene las cartas faltantes para un mazo incompleto
         * @return Arraylist<Cards> mazo de cartas faltantes
         */
        public List<Card> missingCards()
        {
            int largoT = (mazo[0]).TamCard();
            Dobble mazoMissing = new Dobble(largoT, -1, false);
            for (int i = 0; i < mazo.Count(); i++)
            {
                for (int j = 0; j < (mazoMissing.numCards()); j++)
                {
                    if (mazo[i].Equals(mazoMissing.getMazo()[j]))
                    {                //caso la carta si esta dentro del mazo
                        mazoMissing.getMazo().Remove(mazoMissing.getMazo()[j]);
                        j--;
                    }
                }
            }
            return mazoMissing.getMazo();
        }

        /**
         * Agrega cartas a un mazo, procurando que este siga siendo valido
         * @ param Card carta
         */
        public void AddCardMazo(Card card)
        {
            Dobble mazoaux = new Dobble(0, -1, false);
            mazo.Add(card);
            mazoaux.setMazo(mazo);
            if (!mazoaux.isDobble())
            {
                mazo.RemoveAt(mazo.Count() - 1);
            }
        }

        /**
         * elimina las 2 primeras cartas de una mazo
         */
        public void EliminarCard()
        {
            this.mazo.RemoveAt(0);
            this.mazo.RemoveAt(0);
        }

        /**
         * Obtiene un true si el ambos mazo son iguales, o un false en caso contrario
         * @return Boolean
         */
        public override bool Equals(Object o)
        {
            Dobble mazo2 = (Dobble)o;
            if (mazo.Count() != mazo2.getMazo().Count())
            {
                return false;
            }
            else
            {
                int aux = 0;
                for (int i = 0; i < mazo.Count(); i++)
                {
                    for (int j = 0; j < mazo2.getMazo().Count(); j++)
                    {
                        if (mazo[i].Equals(mazo2.getMazo()[j]))
                        {
                            aux++;
                        }
                    }
                }
                if (aux == mazo.Count())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /**
         * Convierte el mazo en String
         * @return mazo (String)
         */
        public override String ToString()
        {
            String salida = "";
            for (int i = 0; i < mazo.Count(); i++)
            {
                salida += mazo[i] + " ";
            }
            return salida;

        }
    }
}
