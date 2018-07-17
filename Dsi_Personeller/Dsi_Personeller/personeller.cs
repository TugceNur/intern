using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dsi_Personeller
{
    public class personeller
    {
        public int personelid { get; set; }
        public string personelad { get; set; }
        public string personelsoyad { get; set; }
        public int birimid { get; set; }
        public int gorevid { get; set; }
        public string telefon { get; set; }
        public string mail { get; set; }
        public string fotograf { get; set; }
        public string sifre { get; set; }
        internal static object ToList()
        {
            throw new NotImplementedException();
        }

        internal void PersonelGuncellestir(personeller guncellenecekpersonel)
        {
            throw new NotImplementedException();
        }
    }
    public class birimler
    {
        public int birimid { get; set; }
        public string birimadi { get; set; }

    }
    public class gorevler
    {
        public int gorevid { get; set; }
        public string gorevadi { get; set; }
    }

}