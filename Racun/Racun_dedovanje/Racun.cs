using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Dvig(double znesek)
        {
            if (stanje - znesek < 0 )
            {
                return false;
            }
            else
            {
                stanje = stanje - znesek;
                return true;
            }

        }

        public void Polog(double znesek)
        {
            stanje = stanje + znesek;
        }

        public override string ToString()
        {
            string stringToReturn;
            stringToReturn = imeLastnika + " " + stanje + " " + limit;
            return stringToReturn;
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

        public double IzracunajLetniPrihranek(double povpMesecnoStanje)
        {
            return povpMesecnoStanje = stanje * obrestnaMera * 12;
        }

        public void NastaviObrestnoMero()
        {
            if (varcevalni == true)
            {
                obrestnaMera = obrestnaMera + 0.5;
            }
            else
            {
                throw new Exception("Ni varčevalni račun!");
            }
        }

        public override string ToString()
        {
            string stringToReturn;
            stringToReturn = imeLastnika + " " + stanje + " " + limit + " " + varcevalni + " " + obrestnaMera;
            return stringToReturn;
        }
    }

    public class ValutniRacun : Racun
    {
        public string primarnaValuta { get; set; }
        public List<string> seznamValut = new List<string>();

        public ValutniRacun()
        {
            imeLastnika = "";
            stanje = 0;
            limit = 0;
            primarnaValuta = "";
        }

        public ValutniRacun(string ImeLastnika, double Stanje, double Limit)
        {
            imeLastnika = ImeLastnika;
            stanje = Stanje;
            limit = Limit;
        }

        public ValutniRacun(string ImeLastnika, double Stanje, double Limit, string PrimarnaValuta)
        {
            imeLastnika = ImeLastnika;
            stanje = Stanje;
            limit = Limit;
            primarnaValuta = PrimarnaValuta;
        }

        public void ZamenjajValuto(double menjalniTecaj)
        {
            stanje = stanje * menjalniTecaj;
        }

        public override string ToString()
        {
            string stringToReturn;
            stringToReturn = imeLastnika + " " + stanje + " " + limit +  " " + primarnaValuta;
            return stringToReturn;
        }
    }

    public class PoslovniRacun : Racun
    {
        public string nazivPodjetja { get; set; }
        public string tipPodjetja { get; set; }

        public PoslovniRacun()
        {
            imeLastnika = "";
            stanje = 0;
            limit = 0;
            nazivPodjetja = "";
            tipPodjetja = "";
        }

        public PoslovniRacun(string ImeLastnika, double Stanje, double Limit)
        {
            imeLastnika = ImeLastnika;
            stanje = Stanje;
            limit = Limit;
        }

        public PoslovniRacun(string ImeLastnika, double Stanje, double Limit, string NazivPodjetja, string TipPodjetja)
        {
            imeLastnika = ImeLastnika;
            stanje = Stanje;
            limit = Limit;
            nazivPodjetja = NazivPodjetja;
            tipPodjetja = TipPodjetja;
        }

        public bool Likvidno()
        {
            if (stanje > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string stringToReturn;
            stringToReturn = imeLastnika + " " + stanje + " " + limit + " " + nazivPodjetja + " " + tipPodjetja;
            return stringToReturn;
        }
    }
}
