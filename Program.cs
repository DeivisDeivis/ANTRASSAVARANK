using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrauzd
{
    internal class Program
    {
        class Valiuta
        {
            private int pilnas;
            private int centas;

            public Valiuta(int pilnas, int centas)
            {
                this.pilnas = pilnas;
                this.centas = centas;
            }

            public int ImtiPilna() { return pilnas; }
            public int ImtiCenta() { return centas; }
        }

        const int Cn = 100;
        const string CFd1 = "TextFile1.txt";
        const string CFd2 = "TextFile2.txt";
        static void Main(string[] args)
        {
            Valiuta[] D1 = new Valiuta[Cn];
            string vard1;
            double kursas1;
            int kiekis1;

            Skaitymas(CFd1, D1, out vard1, out kursas1, out kiekis1);
            //Console.WriteLine("USD kursas: {0}", kursas1);
            //for (int i = 0; i < kiekis1; i++)
            //{
            //    Console.WriteLine("{0} turi: {1},{2}$", vard1, D1[i].ImtiPilna(), D1[i].ImtiCenta());
            //}

            double pilnaSuma1 = Konvertacija(D1, kiekis1, kursas1);
            //Console.WriteLine("Jo kovertuotas kiekis yra: {0:f2}", pilnaSuma1);

            Valiuta[] D2 = new Valiuta[Cn];
            string vard2;
            double kursas2;
            int kiekis2;

            Skaitymas(CFd2, D2, out vard2, out kursas2, out kiekis2);
            //Console.WriteLine("\nJPY kursas: {0}", kursas2);
            //for (int i = 0; i < kiekis2; i++)
            //{
            //    Console.WriteLine("{0} turi: {1},{2}¥", vard2, D2[i].ImtiPilna(), D2[i].ImtiCenta());
            //}

            double pilnaSuma2 = Konvertacija(D2, kiekis2, kursas2);
            //Console.WriteLine("Jo kovertuotas kiekis yra: {0:f2}", pilnaSuma2);

            double bendraSuma = pilnaSuma1 + pilnaSuma2;
            spausdinti(D1, D2, vard1, vard2, kiekis1, kiekis2, kursas1, kursas2, pilnaSuma1, pilnaSuma2);

            Console.WriteLine("\nBendra ju suma eurais: {0:f2}", bendraSuma);


        }

        static void Skaitymas(string fv, Valiuta[] D, out string vard, out double kursas, out int kiekis)
        {
            int pilnas;
            int centas;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                vard = line;
                line = reader.ReadLine();
                kursas = double.Parse(line);
                line = reader.ReadLine();
                kiekis = int.Parse(line);
                for (int i = 0; i < kiekis; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pilnas = int.Parse(parts[0]);
                    centas = int.Parse(parts[1]);
                    D[i] = new Valiuta(pilnas, centas);
                }
            }
        }
        static double Konvertacija(Valiuta[] D, int kiekis, double kursas)
        {
            double konvertuotaEuras;
            double konvertuotaCentas;
            double pilnaSuma = 0;
            for (int i = 0; i < kiekis; i++)
            {
                konvertuotaEuras = D[i].ImtiPilna() * kursas;
                konvertuotaCentas = (D[i].ImtiCenta() * 0.01) * kursas;
                pilnaSuma = konvertuotaCentas + konvertuotaEuras;
            }
            return pilnaSuma;
        }

        static void spausdinti (Valiuta[] D1, Valiuta[] D2, string vard1, string vard2, int kiekis1, int kiekis2, double kursas1, double kursas2, double pilnaSuma1, double pilnaSuma2)
        {
            Console.WriteLine("USD kursas: {0}", kursas1);
            for (int i = 0; i < kiekis1; i++)
            {
                Console.WriteLine("{0} turi: {1},{2}$", vard1, D1[i].ImtiPilna(), D1[i].ImtiCenta());
                Console.WriteLine("Kovertuotas kiekis yra: {0:f2}", pilnaSuma1);
            }
            Console.WriteLine("\nJPY kursas: {0}", kursas2);
            for (int i = 0; i < kiekis2; i++)
            {
                Console.WriteLine("{0} turi: {1},{2}¥", vard2, D2[i].ImtiPilna(), D2[i].ImtiCenta());
                Console.WriteLine("Kovertuotas kiekis yra: {0:f2}", pilnaSuma2);
            }
        }

    }
}