using Parco.Fantasilandia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parco
{
    internal class Program
    {
        private static List<Attrazione> attrazioni = new List<Attrazione>();
        private static List<IRiparabile> elementiManutenzione = new List<IRiparabile>();
        private static double incassoTotale = 0;

        static void Main(string[] args)
        {
            MontagneRusse mr = new MontagneRusse("Blue Tornado", 30, 15.0, 140, 5.0);
            TorreCadutaLibera torre = new TorreCadutaLibera("Salto nel Vuoto", 20, 12.0, 130, 4.0, 100, 3.0);
            GiostraBambini giostra = new GiostraBambini("Carosello", 15, 5.0, 8);
            SalaGiochi sala = new SalaGiochi("Arcade Land", 50, 1.0);

            Chiosco chiosco = new Chiosco("I Burger di Cicciogamer89");
            Bagno bagno = new Bagno("bagno zona 3");

            attrazioni.Add(mr);
            attrazioni.Add(torre);
            attrazioni.Add(giostra);
            attrazioni.Add(sala);
            
            // aggiunta elementi in manutenzione
            elementiManutenzione.Add(mr);
            elementiManutenzione.Add(torre);
            elementiManutenzione.Add(giostra);
            elementiManutenzione.Add(sala);
            elementiManutenzione.Add(chiosco);
            elementiManutenzione.Add(bagno);

            // guasti avvenuti
            mr.SegnalaGuasto(90, 300.0);
            chiosco.SegnalaGuasto(30, 80.0);

            bool esci = false;
            while (!esci)
            {
                Console.WriteLine("1. Visualizza tutte le attrazioni");
                Console.WriteLine("2. Registra accesso visitatore a un'attrazione");
                Console.WriteLine("3. Mostra elementi in manutenzione (Guasti)");
                Console.WriteLine("4. Ripara un elemento");
                Console.WriteLine("5. Mostra incasso totale giornaliero");
                string scelta = Console.ReadLine();
                Console.WriteLine();

                switch (scelta)
                {
                    case "1": VisualizzaAttrazioni(); break;
                    case "2": RegistraAccesso(); break;
                    case "3": VisualizzaManutenzione(); break;
                    case "4": RiparaElemento(); break;
                    case "5": Console.WriteLine($"Incasso totale giornaliero: {incassoTotale}"); break;
                    case "0": esci = true; break;
                    default: Console.WriteLine("Opzione non valida, riprova"); break;
                }
            }
        }

        static void VisualizzaAttrazioni()
        {
            Console.WriteLine("ELENCO ATTRAZIONI");
            for (int i = 0; i < attrazioni.Count; i++)
            {
                Console.WriteLine($"[{i}] {attrazioni[i].Descrizione()}");
            }
        }

        static void RegistraAccesso()
        {
            VisualizzaAttrazioni();
            Console.WriteLine("Seleziona l'indice dell'attrazione: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < attrazioni.Count)
            {
                Attrazione att = attrazioni[idx];
                if (att.IsGuasto)
                {
                    Console.WriteLine("l'attrazione è guasta e in manutenzione");
                    return;
                }

                Console.Write("Nome visitatore: ");
                string nome = Console.ReadLine();
                Console.Write("Età: ");
                int eta = int.Parse(Console.ReadLine());
                Console.Write("Altezza (in cm): ");
                int altezza = int.Parse(Console.ReadLine());
                Console.Write("Peso (in kg): ");
                int peso = int.Parse(Console.ReadLine());

                bool fastPass = false;
                // fast pass solo per la montagna russa o la torre di caduta libera
                if (att is MontagneRusse)
                {
                    bool inputValido = false;
                    do
                    {
                        Console.Write("Ha il Fast Pass?: ");
                        string risposta = Console.ReadLine().Trim().ToLower();

                        if (risposta == "s" || risposta == "si")
                        {
                            fastPass = true;
                            inputValido = true;
                        }
                        else if (risposta == "n" || risposta == "no")
                        {
                            fastPass = false;
                            inputValido = true;
                        }
                        else
                        {
                            Console.WriteLine("inserisci 's' per sì o 'n' per no.");
                        }
                    }
                    while (!inputValido); // Continua a chiedere finché l'input non è corretto
                }

                int gettoni = 0;
                if (att is SalaGiochi)
                {
                    Console.Write("Quanti gettoni vuoi comprare: ");
                    gettoni = int.Parse(Console.ReadLine());
                }

                Visitatore vis = new Visitatore(nome, eta, altezza, peso, fastPass, gettoni);

                if (att.Verifica(vis))
                {
                    double prezzo = att.Costo(vis);
                    incassoTotale += prezzo;
                    Console.WriteLine($"Accesso consentito! Biglietto emesso per {vis.Nome}. Importo: {prezzo}€");
                }
                else
                {
                    Console.WriteLine($"Accesso negato: {vis.Nome} non rispetta i requisiti fisici");
                }
            }
        }

        static void VisualizzaManutenzione()
        {
            Console.WriteLine("Elementi in manutenzione");
            bool trovato = false;
            foreach (var el in elementiManutenzione)
            {
                if (el.IsGuasto)
                {
                    string nome = el is Attrazione a ? a.Nome : (el is Chiosco c ? c.Nome : "Bagno");
                    Console.WriteLine($" Elemento: {nome} | Tempo stimato: {el.TempoRiparazione} min | Costo riparazione: {el.CostoRiparazione}€");
                    trovato = true;
                }
            }
            if (!trovato)
            {
                Console.WriteLine("Nessun elemento guasto");
            }
        }

         static void RiparaElemento()
        {
            List<IRiparabile> guasti = new List<IRiparabile>();
            foreach (var el in elementiManutenzione)
            {
                if (el.IsGuasto) guasti.Add(el);
            }

            if (guasti.Count == 0)
            {
                Console.WriteLine("Non ci sono elementi guasti da riparare.");
                return;
            }

            Console.WriteLine("Seleziona un elemento da riparare");
            for (int i = 0; i < guasti.Count; i++)
            {
                string nome = guasti[i] is Attrazione a ? a.Nome : (guasti[i] is Chiosco c ? c.Nome : "Bagno");
                Console.WriteLine($"[{i}] {nome}");
            }

            Console.Write("Scelta: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < guasti.Count)
            {
                guasti[idx].Ripara();
                Console.WriteLine("Riparo completato");
            }
        }
    }
}

