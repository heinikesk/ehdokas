using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Harjotustyo
{
    class Program
    {
        static void Main(string[] args)
        {

            int counter = 0;
            string line;

            // Lista ehdokkaista
            List<Ehdokas> ehdokkaat = new List<Ehdokas>();

            StreamReader file = null;
            // Read the file and display it line by line.
            try
            {
                file =
                    new StreamReader("C:/Windows/tmp/ehdokkaat.txt", Encoding.UTF7);
                while ((line = file.ReadLine()) != null)
                {
                    // poimitaan rivillä olevat tiedot erilleen
                    string[] palaset = line.Split();

                    try
                    {
                        if (palaset.Length < 6)
                        {
                            // halutaan aiheuttaa itse poikkeus
                            throw new Exception("<5");
                        }
                    
                        int aanimaara = int.Parse(palaset[3]);
                        int vertailuluku = int.Parse(palaset[4]);

                        // luodaan Ehdokas-olio
                        Ehdokas e = new Ehdokas(palaset[0], palaset[1], palaset[2], aanimaara, vertailuluku);
                        // lisätään ehdokas listaan
                        ehdokkaat.Add(e);

                        counter++;
                    }
                    catch (FormatException)
                    {
                        // ei tehdä mitään, ohitetaan vain virheellinen rivi
                        Console.WriteLine("Virheellinen rivi");
                        //Console.ReadKey();
                    }
                    catch (Exception e)
                    {   // oma poikkeus käsitellään tässä
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                } // endwhile
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Tiedoston avaaminen ei onnistunut");
                return;
            }
            catch (IOException)
            {
                Console.WriteLine("Tiedoston lukeminen ei onnistunut");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("ei onnistu");
                return;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }

            // järjestetään ehdokkaat
            ehdokkaat.Sort();

            JarjestaAaniMaaranMukaan jarjAanimaaranMukaan = new JarjestaAaniMaaranMukaan();
            ehdokkaat.Sort(jarjAanimaaranMukaan);
            for (int i = 0; i < ehdokkaat.Count; i++)
            {
                Console.WriteLine(ehdokkaat[i].ToString());
            }
            
            int aanetYht = 0;
            foreach (var item in ehdokkaat)
            {
                aanetYht += item.AaniMaara;
            }
            Console.WriteLine(aanetYht);

        }
    }
}

