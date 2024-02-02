using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Agenzia_Delle_Entrate
{
    internal static class Agenzia

    {

        //Creo una classe statica per l'agenzia per eventuali controlli fissi con metodi statici da usare nal Main

        //Separo i calcolo dell'aliquota dai casi incaso di aggiornamento degli scaglioni
        public static double CalcoloAliquota(double reddito, int limiteMinimo, int aliquotaPercentuale, int aliquotaFissa = 0) {
            double CalcAliquotaDovuta;

            if (aliquotaFissa == 0)
            {
                CalcAliquotaDovuta = (reddito * aliquotaPercentuale)/100;
            }
            else {
                CalcAliquotaDovuta = (aliquotaFissa + (((reddito - limiteMinimo) * aliquotaPercentuale) / 100));
            }


            

            return CalcAliquotaDovuta; 
        }


        //Check Scaglione
        public static int CalcoloAliquotaDovuto(double redditoAnnuale)
        {
            double aliquotaDovuta;


            if (redditoAnnuale < 15000) { aliquotaDovuta = CalcoloAliquota(redditoAnnuale, 15000, 23); }
            else if (15001 < redditoAnnuale && redditoAnnuale < 28000) { aliquotaDovuta = Agenzia.CalcoloAliquota(redditoAnnuale, 15000, 27, 3450); }
            else if (28001 < redditoAnnuale && redditoAnnuale < 55000) { aliquotaDovuta = Agenzia.CalcoloAliquota(redditoAnnuale, 28000, 38, 6960); }
            else if (55001 < redditoAnnuale && redditoAnnuale < 75000) { aliquotaDovuta = Agenzia.CalcoloAliquota(redditoAnnuale, 55000, 41, 17220); }
            else { aliquotaDovuta = Agenzia.CalcoloAliquota(redditoAnnuale, 75000, 43, 25420); };


            int aliquotaDovutaInt = (int)aliquotaDovuta;
            return aliquotaDovutaInt;

        }


        //Controllo Nome e Cognome 
        public static bool ControllaString(string input)
        {
            return !string.IsNullOrEmpty(input);
        }


        //controllo il CF
        public static bool ControlloCF(string codiceFiscale)
        {
            bool checkCF = false;

            if (codiceFiscale.Length == 16)
            {
                // Verifico che i primi 6 caratteri siano lettere
                if (codiceFiscale.Substring(0, 5).All(char.IsLetter))
                {
                  // Verifico che i successivi caratteri siano numeri
                    if (char.IsDigit(codiceFiscale[6]) && char.IsDigit(codiceFiscale[7]))
                    {
                        // Verifico che l'ultimo carattere sia una lettera
                        if (char.IsLetter(codiceFiscale[15]))
                        {
                            checkCF = true;
                        }
                    }
                }
            }

            return checkCF;
        }


        //Controllo Data di Nascita
        //Santo StachOverflow
        public static bool ControlloDataDiNascita(string dataDiNascita)
        {
            //Controllo se la data inserita è in un formato correttoe  sotto se non supera parametri standard come giorno del mese/ mese/ anno
            if (DateTime.TryParseExact(dataDiNascita, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            { 
                if (parsedDate.Day <= 31 && parsedDate.Month <= 12 && parsedDate.Year <= DateTime.Now.Year)
                {
                    return true;
                }
            }

            return false;
        }


        //Controllo Maggiore Età
        public static bool ControlloMaggioreEta(string dataDiNascita) {
            DateTime presente = DateTime.Now;
            int anni = presente.Year - Int32.Parse(dataDiNascita.Substring(6, 4));

            if (anni < 18) { 
            return true;
            }
            return false;
        }


        //Controllo il formato del reddito attraverso il controllo della posizione della virgola
        public static bool ControlloReddito(string reddito ) {
            
            bool checkReddito = false;
            if ((double.Parse(reddito) > 0) && (reddito[reddito.Length - 3].ToString() == ",")) {
                checkReddito = true;

            }

            return checkReddito;

        
        }



    }

}


