using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc4AppFuncional.Models
{
    public class BodegaCotizacion
    {
        public virtual List<Cotizaciones> lstbcCotizacion { get; set; }
        public  List<Bodegas> lstbcBodega { get; set; }
        public virtual List<Categorias> lstbcCategoria { get; set; }

        //public int IdCategoria { get; set; } <- movida a constructor

       // public IEnumerable<Get_Categorias> getCategory { get; set; }
    }
    public class BodegaCotizacionSheme
    {
        public List<Cotizaciones> vCotizacion { get; set; }
        public List<Bodegas> vBodegas { get; set; }
        public List<Categorias> vCategorias { get; set; }
        public string Id { get; set; }
        //public DateTime fechaCreacion { get; set; }     

        public int IdCategoria { get; set; }

        public BodegaCotizacionSheme()
        {
            vBodegas = new List<Bodegas>();
            vCotizacion = new List<Cotizaciones>();
            vCategorias = new List<Categorias>();

        }
    }
}