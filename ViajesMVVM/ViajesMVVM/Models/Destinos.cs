using System;
using System.Collections.Generic;
using System.Text;

namespace ViajesMVVM.Models
{
    public class Destinos
    {
        public string ImagenLugar { get; set; } = "";
        public string LocacionMapa { get; set; } = "";
        public string NombreLugar { get; set; } = "";
        public string Ciudad { get; set; } = "";
        public string Pais { get; set; } = "";

        public string Descripcion { get; set; } = "";
        public decimal Costo { get; set; }
        
    }
}
