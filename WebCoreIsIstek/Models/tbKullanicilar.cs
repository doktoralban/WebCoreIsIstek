﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebCoreIsIstek.Models
{
    public partial class tbKullanicilar
    { 
        [Key]
        public int KullaniciID { get; set; }
        public string KullanıcıAdı { get; set; }
        public string Şifresi { get; set; }
        public string AdıSoyadı { get; set; }
        public string Grubu { get; set; }
        public string Tipi { get; set; }
        public bool Adminmi { get; set; }
        public string Ünvanı { get; set; }
        public Nullable<int> LokasyonID { get; set; }
        public Nullable<int> FaaliyetAlaniID { get; set; }
        public string Emaili { get; set; }
        public string CepTelefonu { get; set; }
        public string DahiliTelefonu { get; set; }
        public byte[] Fotografi { get; set; }
        public Nullable<int> UstAmiriID { get; set; }
        public Nullable<bool> SuanSistemde { get; set; }
        public Nullable<bool> DahiliMesajlaşmadaGörünür { get; set; }
        public Nullable<bool> BakımOnarımYapabilir { get; set; }
        public string YerelIPAdresi { get; set; }
        public Nullable<System.DateTime> SonGirişZamanı { get; set; }
        public Nullable<System.DateTime> SonÇikişZamanı { get; set; }
        public bool Aktif { get; set; }
    }
}