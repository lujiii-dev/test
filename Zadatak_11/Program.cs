using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new test();
        }
    }
    class stan
    {
        private double povrsina;
        private int brojstanara;
        public double Povrsina
        {
            get { return povrsina; }
            set { povrsina = value; }
        }
        public int Brojstanara
        {
            get { return brojstanara; }
            set { brojstanara = value; }
        }
        public stan()
        {
            povrsina = 0;
            brojstanara = 0;
        }
        public stan (double povrsina, int brojstanara)
        {
            this.povrsina = povrsina;
            this.brojstanara = brojstanara;
        }
        public void ucitaj()
        {
            Console.WriteLine("Unesite povrsinu stana: ");
            povrsina = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite broj stanara: ");
            brojstanara = int.Parse(Console.ReadLine());
        }
        public void ispisi()
        {
            Console.WriteLine("Povrsina stana: " + povrsina);
            Console.WriteLine("Broj stanara: " + brojstanara);
        }
    }

    abstract class stambeniobjekat
    {
        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }
        public stambeniobjekat()
        {
            adresa = "";
        }
        public stambeniobjekat(string adresa)
        {
            this.adresa = adresa;
        }
        public abstract void ispisi();
        public abstract double porez(double cenapokvadratu);
    }

    class kuca : stambeniobjekat
    {
        private stan stan;
        public kuca(string adresa, stan stan)
        {
            this.stan = stan;
            this.Adresa = adresa;
        }
        public override void ispisi()
        {
            Console.WriteLine("Adresa: " + this.Adresa);
            stan.ispisi();
        }
        public override double porez(double cenapokvadratu)
        {
            if (stan.Brojstanara > 2)
               return stan.Povrsina * cenapokvadratu - 0.05 * (stan.Brojstanara - 2) * stan.Povrsina * cenapokvadratu;
            else
               return stan.Povrsina * cenapokvadratu;
        }
    }
    class zgrada : stambeniobjekat
    {
        int brojstanova;
        stan[] stanovi;

        public zgrada(int brojstanova)
        {
            this.brojstanova = brojstanova;
            stanovi = new stan[brojstanova];
            for (int i = 0; i < brojstanova; i++)
            {
                stanovi[i] = new stan();
                stanovi[i].ucitaj();
            }
        }
        public override void ispisi()
        {
            Console.WriteLine("Zgrada: ");
            Console.WriteLine("Adresa: " + this.Adresa);
            Console.WriteLine("Broj stanova je " + brojstanova);
            for (int i = 0; i < brojstanova; i++)
            {
                Console.WriteLine("Stan " + (i + 1) + ": ");
                stanovi[i].ispisi();
            }
        }
        public override double porez(double cenapokvadratu)
        {
            double zbir = 0;
            foreach (stan s in stanovi)
            {
                zbir = zbir + s.Povrsina * cenapokvadratu * (1 - (s.Brojstanara - 2) * 0.05);
            }
            return zbir;
        }
    }


    class test
    {
        public test()
        {
            Console.WriteLine("Adresa? ");
            string adresa = Console.ReadLine();
            Console.WriteLine("Tip stambenog objekta? ");
            char tip = char.Parse(Console.ReadLine());
            if (tip == 'z')
            {
                Console.WriteLine("Broj stanova? ");
                int brojstanova = int.Parse(Console.ReadLine());
                zgrada z = new zgrada(brojstanova);
                z.Adresa = adresa;
                Console.WriteLine("Cena poreza po kvadratu? ");
                double cena = double.Parse(Console.ReadLine());
                Console.WriteLine("Porez za zgradu je: " + z.porez(cena) + " za zgradu:");
                z.ispisi();
            }
            else
            {
                stan s = new stan();
                s.ucitaj();
                kuca k = new kuca(adresa, s);
                Console.WriteLine("Cena poreza po kvadratu? ");
                double cena = double.Parse(Console.ReadLine());
                Console.WriteLine("Porez za kucu je: " + k.porez(cena) + " za kucu:");
                k.ispisi();
            }
        }
    }
}
