using System;
using System.Text;
using System.Collections.Generic;

namespace IntroduccionClases
{
    class Program
    {
        static void Main(string[] args)
        {

            Baraja barajaJ1 = new Baraja(4, 12, 1, 3);
            Baraja barajaJ2 = new Baraja(4, 12, 2, 3);
            Baraja barajaJ3 = new Baraja(4, 12, 3, 3);
            Carta numCartaBaraja2= new Carta(1,1);
            Carta numCartaBaraja3= new Carta(1,1);
            Carta numCartaBaraja1= new Carta(1,1);
            int quienCojeCartas;
            while(numCartaBaraja1.getNumDeCarta()>0 || numCartaBaraja2.getNumDeCarta() > 0 || numCartaBaraja3.getNumDeCarta() > 0 )
            {
                Console.Write("El J1 ");
                numCartaBaraja1 = barajaJ1.cogerCartaAlAzar();
                Console.Write("El J2 ");
                numCartaBaraja2 = barajaJ2.cogerCartaAlAzar();
                Console.Write("El J3 ");
                numCartaBaraja3 = barajaJ3.cogerCartaAlAzar();
                quienCojeCartas = numCartaBaraja1.whichCardIsBigger(numCartaBaraja2.getNumDeCarta(), numCartaBaraja3.getNumDeCarta());
                switch (quienCojeCartas)
                {
                    case 1:
                        Console.WriteLine("ha ganado el J1");
                        Console.Write("del J2 ");
                        barajaJ2.cogeCarta(numCartaBaraja2);
                        Console.Write("del J3 ");
                        barajaJ3.cogeCarta(numCartaBaraja3);
                        break;
                    case 2:
                        Console.WriteLine("ha ganado el J2");
                        Console.Write("del J1 ");
                        barajaJ1.cogeCarta(numCartaBaraja1);
                        Console.Write("del J3 ");
                        barajaJ3.cogeCarta(numCartaBaraja3);
                        break;
                    case 3:
                        Console.WriteLine("ha ganado el J3");
                        Console.Write("del J1 ");
                        barajaJ1.cogeCarta(numCartaBaraja1);
                        Console.Write("del J2 ");
                        barajaJ2.cogeCarta(numCartaBaraja2);
                        break;
                    case 0:
                        Console.WriteLine("Empate");
                        break;


                }
                Console.Write("Para el jugador 1: ");
                    barajaJ1.numeroCartas();
                Console.Write("Para el jugador 2: ");
                barajaJ2.numeroCartas();
                Console.Write("Para el jugador 3: ");
                barajaJ3.numeroCartas();
                    Console.WriteLine("\n Presiona cualquier tecla para ir a la siguiente ronda");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
    class Carta
    {
        private int numeroDeCarta;
        public int palo;
        string[] palos = { "Oros", "Copas", "Espadas", "Bastos" };
        public Carta()
        {
            numeroDeCarta = 0;
            palo = 0;
        }
        public Carta(int n, int p)
        {
            numeroDeCarta = n;
            palo = p;
        }
        public void escribeCarta()
        {
            Console.WriteLine(numeroDeCarta + " de " + palos[palo]);
        }

        public int getNumDeCarta()
        {
            return numeroDeCarta;
        }
        public int whichCardIsBigger(int carta2, int carta3 = 0, int carta4 = 0)
        {
            if (numeroDeCarta > carta2 && numeroDeCarta > carta3 && numeroDeCarta > carta4) return 1;
            else if (carta2 > numeroDeCarta && carta2 > carta3 && carta2 > carta4) return 2;
            else if (carta3 > numeroDeCarta && carta3 > carta2 && carta3 > carta4) return 3;
            else if (carta4 > numeroDeCarta && carta4 > carta3 && carta4 > carta2) return 4;
            else return 0;

        }
    }
    class Baraja
    {
        private List<Carta> baraja = new List<Carta>();
        public Carta card;
        public Baraja(int numPalos, int numCartas)
        {
            int i, j;
            for (j = 0; j < numPalos; j++)
            {
                for(i=0; i<numCartas; i++)
                {
                    card = new Carta(i + 1, j);
                    baraja.Add(card);
                }
            }
        }
        public Baraja(int numPalo, int numCartas, int jugador, int numeroJugadores)
        {
            {
                int i, j;
                for (j = 0; j < numPalo; j++)
                {
                    for (i = 0; i < numCartas; i++)
                    {
                        card = new Carta(i + 1, j);
                        baraja.Add(card);
                    }
                }
            }
            baraja = baraja.GetRange((jugador - 1)* baraja.Count/numeroJugadores, (baraja.Count/ numeroJugadores));
        }

        public void numeroCartas()
        {
            Console.WriteLine("quedan " + baraja.Count + " cartas");
        }
        public void robaCarta()
        {
            Console.WriteLine("Has cogido una carta:");
            baraja[0].escribeCarta();
            baraja.Remove(baraja[0]);
        }
        public void  cogeCarta(Carta cardToDelete)
        {
            Console.Write("has quitado la carta: ");
            cardToDelete.escribeCarta();
            baraja.RemoveAt(cardToDelete.getNumDeCarta()-1);
           
        }
        public Carta cogerCartaAlAzar()
        {
            Random r = new Random();
            int n = r.Next(1, baraja.Count);
            Console.Write("ha cogido la carta: ");
            baraja[n].escribeCarta();
            return new Carta(baraja[n].getNumDeCarta(), baraja[n].palo);
        }
        public void escribeBaraja()
        {
            int j;
            for (j = 0; j < baraja.Count; j++)
            {
                baraja[j].escribeCarta();
            }
        }
        public void Barajar()
        {
            Random r = new Random();
            int posicion;
            int i;
            for (i = 0; i < 112; i++)
            {
                posicion = r.Next(0, baraja.Count);
                baraja.Insert(posicion, baraja[0]);
                baraja.Remove(baraja[0]);
            }
        }
    }
}
