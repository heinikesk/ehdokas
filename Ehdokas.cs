using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Harjotustyo
{
    public class JarjestaAaniMaaranMukaan : IComparer<Ehdokas>
    {
        public int Compare(Ehdokas x, Ehdokas y)
        {
            int tulos = x.AaniMaara.CompareTo(y.AaniMaara);
            if (tulos == 0)
                tulos = x.VertailuLuku.CompareTo(y.VertailuLuku);
            

            return tulos;
        }
    }
   public class Ehdokas : IComparable<Ehdokas>
    {
        public int CompareTo(Ehdokas other)
        {
            return -this.AaniMaara + other.AaniMaara;
        }
        private int id;
        private static int counter = 1;
        public string Sukunimi { get; set; }
        public string Etunimi { get; set; }
        public string Vaaliliitto { get; set; }
        public int AaniMaara { get; set; }
        public int VertailuLuku { get; set; }
        
        public Ehdokas(string etunimi, string sukunimi, string vaaliliitto, int aanimaara, int vertailuluku)
        {
            Etunimi = etunimi;
            Sukunimi = sukunimi;
            Vaaliliitto = vaaliliitto;
            AaniMaara= aanimaara;
            VertailuLuku = vertailuluku;
            id = counter++;
        }

        void Vertailuluku(double vertailuLuku)
        {

        }

        public override string ToString()
        {
            return Sukunimi + " " + Etunimi + " " + AaniMaara + " " + VertailuLuku;
        }

    }
}
