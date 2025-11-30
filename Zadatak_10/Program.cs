using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new test();
        }
    }
    public interface ZivoBice
    {
        void predstavise();
        void zivi();
    }
    public interface Zivotinja : ZivoBice
    {
        void kreciSe();
    }
    public interface Biljka : ZivoBice
    {
        void vrsiFotosintezu();
    }
    public interface Vodozemac : Zivotinja
    {
        void plivaj();
    }
    public interface Ptica : Zivotinja
    {
        void leti();
    }
    public interface Cujni
    {
        void oglasiSe();
    }

    public class zaba : Vodozemac, Cujni
    {
        public void kreciSe()
        {
            Console.Write("skakucem");
        }
        public void oglasiSe()
        {
            Console.Write("kre-kre");
        }
        public void plivaj()
        {
            Console.Write("plivam hitro");
        }
        public void zivi()
        {
            Console.Write("zivim u vodi");
        }
        public void toString()
        {
            Console.Write("Ja sam zaba.");
        }
        public void predstavise()
        {
            oglasiSe();
            Console.Write(" ");
            toString();
            Console.Write(", ");
            zivi();
            Console.Write(", ");
            kreciSe();
            Console.Write(", ");
            plivaj();
        }
    }
    public class lasta : Ptica, Cujni
    {
        public void kreciSe()
        {
            Console.Write("hodam i skakucem");
        }
        public void leti()
        {
            Console.Write("letim dugo");
        }
        public void oglasiSe()
        {
            Console.Write("cvrku-cvrku");
        }
        public void zivi()
        {
            Console.Write("zivim na nebu");
        }
        public void toString()
        {
            Console.Write("Ja sam lasta.");
        }
        public void predstavise()
        {
            oglasiSe();
            Console.Write(" ");
            toString();
            Console.Write(", ");
            zivi();
            Console.Write(", ");
            kreciSe();
            Console.Write(", ");
            leti();
        }
    }
    public class macka : Zivotinja, Cujni
    {
        public void kreciSe()
        {
            Console.Write("krecem se graciozno");
        }
        public void oglasiSe()
        {
            Console.Write("mijau-mijau");
        }
        public void zivi()
        {
            Console.Write("zivim u kucama");
        }
        public void toString()
        {
            Console.Write("Ja sam macka.");
        }
        public void predstavise()
        {
            oglasiSe();
            Console.Write(" ");
            toString();
            Console.Write(", ");
            zivi();
            Console.Write(", ");
            kreciSe();
        }
    }
    public class bakterija : ZivoBice
    {
        public void zivi()
        {
            Console.Write("zivim svuda");
        }
        public void toString()
        {
            Console.Write("Ja sam bakterija.");
        }
        public void predstavise()
        {
            toString();
            Console.Write(", ");
            zivi();
        }
    }
    public class jabuka : Biljka
    {
        public void vrsiFotosintezu()
        {
            Console.Write("vrsim fotosintezu");
        }
        public void zivi()
        {
            Console.Write("zivim na drvetu");
        }
        public void toString()
        {
            Console.Write("Ja sam jabuka.");
        }
        public void predstavise()
        {
            toString();
            Console.Write(", ");
            zivi();
        }
    }
    public class ruza : Biljka
    {
        public void vrsiFotosintezu()
        {
            Console.Write("vrsim fotosintezu");
        }
        public void zivi()
        {
            Console.Write("zivim u vrtu");
        }
        public void toString()
        {
            Console.Write("Ja sam ruza.");
        }
        public void predstavise()
        {
            toString();
            Console.Write(", ");
            zivi();
        }
    }
    public class koza : Zivotinja, Cujni
    {
        public void kreciSe()
        {
            Console.Write("pentram se po liticama");
        }
        public void oglasiSe()
        {
            Console.Write("meee-meee");
        }
        public void zivi()
        {
            Console.Write("zivim na planini");
        }
        public void toString()
        {
            Console.Write("Ja sam koza.");
        }
        public void predstavise()
        {
            oglasiSe();
            Console.Write(" ");
            toString();
            Console.Write(", ");
            zivi();
            Console.Write(", ");
            kreciSe();
        }
    }
    class test
    {
        public test()
        {
            ZivoBice[] niz = new ZivoBice[7];
            niz[0] = new zaba();
            niz[0].predstavise();
            Console.WriteLine();
            niz[1] = new lasta();
            niz[1].predstavise();
            Console.WriteLine();
            niz[2] = new macka();
            niz[2].predstavise();
            Console.WriteLine();
            niz[3] = new bakterija();
            niz[3].predstavise();
            Console.WriteLine();
            niz[4] = new jabuka();
            niz[4].predstavise();
            Console.WriteLine();
            niz[5] = new ruza();
            niz[5].predstavise();
            Console.WriteLine();
            niz[6] = new koza();
            niz[6].predstavise();
            Console.WriteLine();

            ZivoBice[] niz1 = new ZivoBice[3];
            niz1[0] = new bakterija();
            niz1[0].predstavise();
            Console.WriteLine();
            niz1[1] = new jabuka();
            niz1[1].predstavise();
            Console.WriteLine();
            niz1[2] = new ruza();
            niz1[2].predstavise();
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Broj dana? ");
            int dan = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < dan; i++)
            {
                Console.WriteLine("Dan " + (i + 1));
                foreach (ZivoBice zivo in niz)
                {
                    zivo.zivi();
                    Console.WriteLine();
                }
                foreach (ZivoBice zivo in niz)
                {
                    if (zivo is Cujni cujnobice)
                    {
                        cujnobice.oglasiSe();
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();

                foreach (ZivoBice zivo in niz1)
                {
                    zivo.zivi();
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
