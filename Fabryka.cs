using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo_wzorzec_fabryka
{
    class Zwierze {
        public virtual void WydajGlos() {
            Console.WriteLine("Zwierze wydają rózne dźwięki...");
        }
        public virtual string NazwaLacinska {
            get { return "Animalia"; }
        }
        public override string ToString() {
            return "zwierze";
        }
    }
    class Owca : Zwierze{
        public override void WydajGlos() {
            Console.WriteLine("Beee...");
        }
        public override string NazwaLacinska {
            get { return "Ovis aries"; }
        }
        public override string ToString() {
            return "owca";
        }
    }
    class Osiol : Zwierze{
        public override void WydajGlos() {
            Console.WriteLine("Ioo ioo...");
        }
        public override string NazwaLacinska {
            get { return "Equus asinus"; }
        }
        public override string ToString() {
            return "osioł";
        }
    }

    class Pies : Zwierze
    {
        public override void WydajGlos()
        {
            Console.WriteLine("Hau Hau...");
        }
        public override string NazwaLacinska
        {
            get { return "piesus pospolitus"; }
        }
        public override string ToString()
        {
            return "pies";
        }
    }

    abstract class IFabryka
    {
        public abstract Zwierze Utworz();
    }

    class FabrykaOwiec : IFabryka
    {
        public override Zwierze Utworz()
        {
            return new Owca();
        }
    }

    class FabrykaOslow : IFabryka
    {
        public override Zwierze Utworz()
        {
            return new Osiol();
        }
    }

    class FabrykaPsow : IFabryka
    {
        public override Zwierze Utworz()
        {
            return new Pies();
        }
    }

    class FabrykaWilkow : IFabryka
    {
        public override Zwierze Utworz()
        {
            return new WilkZaadoptowany();
        }
    }

    class FactoryMaker
    {
        private static IFabryka pf = null;
        public static IFabryka getFactory(char choice)
        {
            if (choice.Equals('a'))
            {
                pf = new FabrykaOwiec();
            }
            else if (choice.Equals('b'))
            {
                pf = new FabrykaOslow();
            }
            else if (choice.Equals('c'))
            {
                pf = new FabrykaWilkow();
            }
            else if (choice.Equals('d'))
            {
                pf = new FabrykaPsow();
            }
            return pf;
        }
    }

    class Klient {
        private Zwierze zwierze;

        public int Menu() {
            Console.WriteLine("Twój aktualkny wybór to {0}\n", zwierze);
            Console.WriteLine("1 - Dżwięki wydawane przez zwierzę");
            Console.WriteLine("2 - Nazwa łacińska");
            Console.WriteLine("3 - Powrót do menu główne");
            int i;
            bool b;
            do {
                b = int.TryParse(Console.ReadLine(), out i);
            }while (!b);
            return i;
        }
        public void Uruchom() {
           int j;
           char choice;

           Console.WriteLine("Owca - a\nOsioł - b\nWilk - c\nPies - d\nWyjscie - z");

            while(true) {
                choice = Console.ReadKey().KeyChar;

                if(choice == 'z')
                    break;

               IFabryka fabryka = FactoryMaker.getFactory(choice);
               zwierze = fabryka.Utworz();

                do {
                    j = Menu();
                    Console.Clear();
                    switch (j) {
                        case 1: zwierze.WydajGlos();
                            Console.ReadKey();
                            break;
                        case 2: Console.WriteLine(zwierze.NazwaLacinska);
                            Console.ReadKey();
                            break;
                    }
                }while (j != 3);
            }
        }

        static void Main(string[] args) {
            Klient k = new Klient();
            k.Uruchom();
        }
    }
}
