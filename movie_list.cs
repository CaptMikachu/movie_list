using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {

        //List<Leffa> leffat = new List<Leffa>() { };
        /*
        leffat.Add(new Leffa("Robocop", 102, 1987));
        leffat.Add(new Leffa("Robocop 2", 117, 1990));
        leffat.Add(new Leffa("Robocop 3", 104, 1993));
        */

        MenuMetodi();

        /*
        foreach (var leffa in leffat)
        {
            Console.Write("Nimi: " + leffa.Nimi + ", kesto: " + leffa.Kesto + "min, vuosi: " + leffa.Vuosi + "\n\r");
        }

        Console.ReadLine();
        */

    }


    static void MenuMetodi()
    {
        List<Leffa> leffat = new List<Leffa>() { };
    /*
    leffat.Add(new Leffa("Robocop", 102, 1987));
    leffat.Add(new Leffa("Robocop 2", 117, 1990));
    leffat.Add(new Leffa("Robocop 3", 104, 1993));
    */
    Alku:

        Console.WriteLine("\n\r\n\rLeffojen Katseluloki\n====================\n1) Lisää Leffa\n2) Poista Leffa\n3) Näytä Raportti\n4) Lataa Tietokanta\n5) Tallenna Tietokanta\n6) Lopeta");
        Console.Write("Syöte: ");

        string valinta = Console.ReadLine();


        switch (valinta)
        {
            case "1":

                Console.WriteLine("\n\rLisää Leffa:");

                Console.Write("Nimi:");
                string nimiSyote = Console.ReadLine();
                Console.Write("Kesto (min):");
                int kestoSyote = int.Parse(Console.ReadLine());
                Console.Write("Vuosi:");
                int vuosiSyote = int.Parse(Console.ReadLine());

                leffat.Add(new Leffa(nimiSyote, vuosiSyote, kestoSyote));


                break;

            case "2":

                int leffaNumero = 1;
                // Viopen vammailun takia
                if (leffat.Count < 2)
                {
                    Console.WriteLine("\n\rPoista Leffa:");
                    foreach (var leffa in leffat)
                    {
                        Console.WriteLine(leffaNumero + ") " + leffa.Nimi + " (" + leffa.Vuosi + "), " + leffa.Kesto + " minuuttia.  ");
                        leffaNumero++;
                    }

                }
                else
                {
                    Console.WriteLine("\n\rPoista Leffa:");
                    foreach (var leffa in leffat)
                    {
                        Console.WriteLine(leffaNumero + ") " + leffa.Nimi + " (" + leffa.Vuosi + "), " + leffa.Kesto + " minuuttia.  ");
                        leffaNumero++;
                    }
                }
                //oma versio
                /*foreach (var leffa in leffat)
                {
                    Console.WriteLine("\n\r" + leffaNumero + ") " + leffa.Nimi + " (" + leffa.Vuosi + "), " + leffa.Kesto + " minuuttia.  ");
                    leffaNumero++;
                }*/

                Console.Write("Syöte: ");

                int poistoSyote = int.Parse(Console.ReadLine()) - 1;

                leffat.RemoveAt(poistoSyote);

                break;

            case "3":

                //Console.WriteLine("\n\rNäytä Raportti");
                //Viopen pelleilyä varten
                if (leffat.Count < 2)
                {
                    foreach (var leffa in leffat)
                    {
                        Console.WriteLine("\n\r" + leffa.Nimi + " (" + leffa.Vuosi + "), " + leffa.Kesto + " minuuttia.  ");
                    }

                }
                else
                {
                    Console.Write("\n\r");
                    foreach (var leffa in leffat)
                    {
                        Console.WriteLine(leffa.Nimi + " (" + leffa.Vuosi + "), " + leffa.Kesto + " minuuttia.  ");
                    }
                }
                /*
                //oma versio
                foreach (var leffa in leffat)
                {
                    Console.Write("\n\r" + leffa.Nimi + " (" + leffa.Vuosi + "), " + leffa.Kesto + " minuuttia. ");
                }
                */
                int leffatAmount = 0;
                int leffatYhteiskesto = 0;

                foreach (var leffa in leffat)
                {
                    leffatAmount++;
                    leffatYhteiskesto += leffa.Kesto;
                }

                // if-lause pelkästään Viopen vammaisuuden vuoksi
                if (leffatAmount == 0)
                {
                    Console.WriteLine("\n\r\n\rLeffoja katsottu yhteensä " + leffatAmount + ", yhteiskesto " + leffatYhteiskesto + " minuuttia.");
                }

                else
                {
                    Console.WriteLine("\n\rLeffoja katsottu yhteensä " + leffatAmount + ", yhteiskesto " + leffatYhteiskesto + " minuuttia.");
                }

                break;

            case "4":

                XmlSerializer deSerialisoija = new XmlSerializer(typeof(List<Leffa>));

                string desktopPolku2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string tiedostonPolku2 = desktopPolku2 + "\\tietokanta.xml";

                if (File.Exists(tiedostonPolku2))
                {
                    using (StreamReader sr = new StreamReader(tiedostonPolku2))
                    {
                        leffat = (List<Leffa>)deSerialisoija.Deserialize(sr);

                        Console.WriteLine("\n\rTietokanta ladattu.");
                    }
                }
                else
                {
                    Console.WriteLine("\n\rTietokantaa ei saatavilla.");
                }

                break;

            case "5":

                XmlSerializer serialisoija = new XmlSerializer(typeof(List<Leffa>));

                string desktopPolku = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string tiedostonPolku = desktopPolku + "\\tietokanta.xml";

                if (File.Exists(tiedostonPolku))
                {
                    Console.WriteLine("\n\rTiedosto on jo olemassa, tietokantaa ei tallennettu!");
                }
                else
                {


                    using (StreamWriter sw = new StreamWriter(tiedostonPolku))
                    {
                        serialisoija.Serialize(sw, leffat);
                        sw.Close();

                        Console.WriteLine("\n\rTietokanta tallennettu.");
                    }
                }

                break;

            case "6":

                break;

            default:

                Console.WriteLine("\n\rTuntematon komento");
                break;
        }

        if (valinta == "6")
        {
            Console.Write("\n\r");
            return;
        }

        goto Alku;
    }
    /* static void RaporttiMetodi()
     {


         Console.ReadLine();

     }
    */

}

[Serializable]
public class Leffa
{
    public string Nimi { get; set; }
    public int Kesto { get; set; }
    public int Vuosi { get; set; }

    public Leffa() { }
    public Leffa(string nimi, int vuosi, int kesto)
    {
        this.Nimi = nimi;
        this.Vuosi = vuosi;
        this.Kesto = kesto;

    }

}