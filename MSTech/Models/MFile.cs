using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSTech.Models
{
    public class MFile
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public string Mime { get; set; }
        public string Ruta { get; set; }
        public string NombreCompleto { get; set; }
        public Int32 Size { get; set; }
    }
}