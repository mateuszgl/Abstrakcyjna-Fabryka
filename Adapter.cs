using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo_wzorzec_fabryka
{
    public class Wilk
    {
        public string Wyj() {
            return "Auuu...";
        }
        public string PodajNazweLacinska() {
            return "Canis lupus";
        }
    }

    class WilkZaadoptowany : Zwierze
    {
        private Wilk wilk = new Wilk();
        public override void WydajGlos() {
            Console.WriteLine(wilk.Wyj());
        }
        public override string NazwaLacinska {
            get { return wilk.PodajNazweLacinska(); }
        }
        public override string ToString() {
            return "wilk";
        }
    }

}