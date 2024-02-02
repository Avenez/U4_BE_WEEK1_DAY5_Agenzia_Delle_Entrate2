using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenzia_Delle_Entrate
{
    internal class Contribuente
    {
        // Proprietà
        private string Nome { get; set; }
        private string Cognome { get; set; }

        private DateTime dataNascita;
        private string CodiceFiscale { get; set; }
        private string Sesso { get; set; }
        private string ComuneResidenza { get; set; }
        private double RedditoAnnuale { get; set; }
        private double AliquotaDovuta { get; set; }


        // Costruttore 1

        public Contribuente() { }

        // Costruttore 2
        public Contribuente(string nome, string cognome, string dataNascita, string codiceFiscale, string sesso, string comuneResidenza, double redditoAnnuale, double aliquotaDovuta)
        {
            Nome = nome;
            Cognome = cognome;
            this.dataNascita = DateTime.Parse(dataNascita);
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
            AliquotaDovuta = aliquotaDovuta;
        }

        //ho pensato di usare il formato datetime per la conservazione del dato per un eventuale uso futuro.
        //Il sistema potrebbe aver bisogno di tale formato per la verifica di dati
        //Mentre per restituire il dato ad un eventuale utente potrebbe essere utile averre il tato scritto sotto forma di stringa
        public string DataNascita {

            get => dataNascita.ToString();
            set => dataNascita = DateTime.Parse(value);
}

        public DateTime getDataDiNascita () {

            return dataNascita;
        }

        // Metodo di esempio
        public void StampaInformazioni()
        {
            Console.WriteLine($"Contribuente: {Nome} {Cognome}");
            Console.WriteLine($"Nato Il: {DataNascita.Substring(0,11)} ({Sesso})");
            Console.WriteLine($"Codice Fiscale: {CodiceFiscale}");
            Console.WriteLine($"Sesso: {Sesso}");
            Console.WriteLine($"Residente in: {ComuneResidenza}");
            Console.WriteLine($"Reddito Dichiarao: Euro {RedditoAnnuale}");
            Console.WriteLine($"IMPOSTA DA VERSARE: Euro {AliquotaDovuta}");
        }
    }
}
