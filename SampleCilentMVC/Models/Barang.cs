using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCilentMVC.Models
{
    public class Barang
    {
        public string KodeBarang { get; set; }

        public int KategoriID { get; set; }

       
        public string NamaBarang { get; set; }

   
        public decimal? HargaBeli { get; set; }

    
        public decimal? HargaJual { get; set; }

        public int? Stok { get; set; }
    }
}