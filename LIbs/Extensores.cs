using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace Libs
{
    public static class Extensores
    {

        // Extender la clase abstracta HttpPostedFileBase
        public static string Extension(this HttpPostedFileBase file) {return Path.GetExtension(file.FileName); }
        public static string NombreCompleto(this HttpPostedFileBase file) {return Path.GetFileName(file.FileName); }
        public static string NombreSinExtension(this HttpPostedFileBase file) {return Path.GetFileNameWithoutExtension(file.FileName); }

        

    }
}
