using System;

namespace Racun_dedovanje
{
    public class Racun
    {
        // Ime in priimek
        public string imeLastnika { get; set; }
        public double stanje { get; set; }
        public double limit { get; set; }

        public Racun()
        {
            imeLastnika = "";
            stanje = 0;
            limit = 0;
        }

        public Racun(double Stanje)
        {
            stanje = Stanje;
        }

        public Racun(double Stanje, double Limit)
        {
            stanje = Stanje;
            limit = Limit;
        }

        public Racun(string ImeLastnika, double Stanje, double Limit)
        {
            imeLastnika = ImeLastnika;
            stanje = Stanje;
            limit = Limit;
        }

        public void Dvig(double Stanje)
        {
            //
        }

        public void Polog(double Stanje, double Limit)
        {
            //
        }
    }

    public class OsebniRacun : Racun
    {
        public bool varcevalni { get; set; }
        public double obrestnaMera { get; set; }

        public OsebniRacun()
        {
            imeLastnika = "";
            stanje = 0;
            limit = 0;
            varcevalni = false;
            obrestnaMera = 0;
        }

        public OsebniRacun(string ImeLastnika, double Stanje, double Limit)
        {
            imeLastnika = ImeLastnika;
            stanje = Stanje;
            limit = Limit;
        }

        public OsebniRacun(string ImeLastnika, double Stanje, double Limit, bool Varcevalni, double ObrestnaMera)
        {
            imeLastnika = ImeLastnika;
            stanje = Stanje;
            limit = Limit;
            varcevalni = Varcevalni;
            obrestnaMera = ObrestnaMera;
        }

        //public void IzracunajLetniPrihranek()
        public void NastaviObrestnoMero(double ObrestnaMera)
        {
            obrestnaMera = ObrestnaMera * 0.5;
        }
    }

    public class ValutniRacun : Racun
    {

    }
}
