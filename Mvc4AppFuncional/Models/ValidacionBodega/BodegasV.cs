using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc4AppFuncional.Models
{
    [MetadataType(typeof(Bodegas.MetaData))]
    public partial class Bodegas
    {
        sealed class MetaData
        {
            [Required]
            [RegularExpression("^[0-9]*$", ErrorMessage = "Solo debe escribir numeros")]
            public int IdCategoria;
            public Nullable<System.DateTime> FechaIngreso;
            public string Responsable;
            [StringLength(20, ErrorMessage = "Maximo {1} caracteres")]
            public string Codigo ;
            //[RegularExpression("^[a-z0-9]+$", ErrorMessage = "solo caracteres minúsculas")]
            public string Descripcion;
            //public string Unidad { get; set; }
            //public Nullable<double> Cantidad { get; set; }
            [Required]
            [RegularExpression("^[0-9]+([.][0-9]{2})?$", ErrorMessage = "Solo debe escribir numeros máx 2 decimal")]
            [Range(1, 98454, ErrorMessage = "Solo se permiten decimales")]// [Range(1,float.MaxValue,ErrorMessage=" fuera de rango")
            public decimal Costo;
            //public string CveProvedor { get; set; }
            //public Nullable<decimal> PrecioMenor { get; set; }
            //public Nullable<decimal> PrecioMayor { get; set; }
            [Display(Name="Id Lab")]
            public long Identificador { get; set; }
        }
    }
}