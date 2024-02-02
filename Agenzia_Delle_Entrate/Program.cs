using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenzia_Delle_Entrate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Creo un menù per simulare un Kiosk dedicato ai clienti dell'agenzia che desiderano sapere quanto dovranno versare.

            Il programma si avvale di:
            - Una classe Contriguente all'interno della quale vengono conservate le informazioni 
            -Una classe statica Agenzia per usare dei metodi relativi al controllo delle informazioni inserite e il calcolo dell'aliquota
            */

            bool startOn = true;

            do {
                //Avvio
                Console.WriteLine("===================================================");
                Console.WriteLine("Buongiorno. Desideri Calcolare la tua imposta da versare ? y/n");
                string choice = Console.ReadLine();
                // Try/Catch per un controllo generale dell'inserimento dei dati
                try {
                    if (choice == "y")
                    {
                        string nome ="";
                        string cognome="";
                        string dataDiNascita ="";
                        string codiceFiscale="";
                        string sesso= "";
                        string comuneResidenza="";
                        double redditoAnnuale = 0;
                        double aliquotaDovuta;

                        // inserimento Nome
                        bool checkNome = true;
                        do
                        {
                            Console.WriteLine("Per prima cosa inserisci Il tuo Nome:");
                            string ControlloNome = Console.ReadLine();
                            // Controllo formato del CF
                            if (Agenzia.ControllaString(ControlloNome))
                            {
                                nome = ControlloNome;
                                checkNome = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Il Nome inserito non è in un Formato Valido");
                                Console.ResetColor();
                            }
                            Console.WriteLine("===================================================");

                        } while (checkNome);


                        // inserimento Cognome
                        bool checkCognome = true;
                        do
                        {
                            Console.WriteLine("Per prima cosa inserisci Il tuo // inserimento Cognome:");
                            string ControlloCognome = Console.ReadLine();
                            // Controllo formato del CF
                            if (Agenzia.ControllaString(ControlloCognome))
                            {
                                cognome = ControlloCognome;
                                checkCognome = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Il Cognome inserito non è in un Formato Valido");
                                Console.ResetColor();
                            }
                            Console.WriteLine("===================================================");

                        } while (checkCognome);


                        // inserimento data di nascita
                        bool checkDate = true;
                        do {
                            Console.WriteLine("Insersci la tua data di nascita (Formato gg/mm/aaaa):");
                            string ContdataDiNascita = Console.ReadLine();

                            //Controllo il formato della data
                            if (Agenzia.ControlloDataDiNascita(ContdataDiNascita))

                            {
                                //controllo se l'utente è maggiorenne
                                
                                if (Agenzia.ControlloMaggioreEta(ContdataDiNascita))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Il richiedente deve essere maggiorenne");
                                    Console.ResetColor();
        
                                    startOn = false;
                                    Console.ReadKey();
                                    Environment.Exit(0);
                                }
                                else {
                                    dataDiNascita = ContdataDiNascita;
                                    checkDate = false;
                                }

                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La data di nascita inserita non è in un Formato Valido");
                                Console.ResetColor();
                            }
                            Console.WriteLine("===================================================");
                            
                        } while (checkDate);




                        // inserimento Codice Fiscale
                        bool checkCF = true;
                        do
                        {
                            Console.WriteLine("Inserisci Il tuo CodiceFiscale:");
                            string ControlloCF = Console.ReadLine();
                            // Controllo formato del CF
                            if (Agenzia.ControlloCF(ControlloCF))
                            {
                                codiceFiscale = ControlloCF;
                                checkCF = false;

                            }
                            else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Il CF inserito non è in un Formato Valido");
                            Console.ResetColor();
                            }
                            Console.WriteLine("===================================================");

                        } while (checkCF);


                        //inserisco il Genere
                        Console.WriteLine("Inserisci Il tuo Genere:");
                        sesso = Console.ReadLine().ToUpper();



                        bool checkComuneResidenza = true;
                        do
                        {
                            Console.WriteLine("Inserisci Il tuo Comune di Residenza:");
                            string ControlloComuneResidenza = Console.ReadLine();
                            // Controllo formato del CF
                            if (Agenzia.ControllaString(ControlloComuneResidenza))
                            {
                                comuneResidenza = ControlloComuneResidenza;
                                checkComuneResidenza = false;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Il Comune inserito non è in un Formato Valido");
                                Console.ResetColor();
                            }
                            Console.WriteLine("===================================================");

                        } while (checkComuneResidenza);



                        // inserimento Reddito
                        bool checkReddito = true;
                        do
                        {
                            Console.WriteLine("Inserisci Il tuo Reddito (Formato X000,00):");
                            string ControlloReddito = Console.ReadLine();
                            //Controllo il Formato del reddito
                            if (Agenzia.ControlloReddito(ControlloReddito))
                            {
                                
                                redditoAnnuale = double.Parse(ControlloReddito);
                                Console.WriteLine($"{redditoAnnuale}");
                                checkReddito = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Il Reddito inserito non è in un Formato Valido");
                                Console.ResetColor();
                            }
                            Console.WriteLine("===================================================");

                        } while (checkReddito);

                        // Calcolo dell'aliquota
                        aliquotaDovuta = Agenzia.CalcoloAliquotaDovuto(redditoAnnuale);

                        //creazione del Contribuente e restituzione dei dati
                        Contribuente contribuente = new Contribuente(nome,cognome, dataDiNascita, codiceFiscale,sesso,comuneResidenza,redditoAnnuale,aliquotaDovuta   );
                        contribuente.StampaInformazioni();

                    }
                    else 
                    {
                        Console.WriteLine("Grazie e buona giornata!");
                        startOn = false;
                    }
                
                } catch {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Errore nell'inserimento della scelta o dei dati. Riprovare!");
                    Console.ResetColor();
                }

            } while (startOn);


            Console.ReadLine();


        }
    }
}
