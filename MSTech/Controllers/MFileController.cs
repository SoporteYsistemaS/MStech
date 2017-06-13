using MSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Libs;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
//Importo de la libreria la extensión de la clase abstracta HttpPostedFileBase

namespace MSTech.Controllers
{
    public class MFileController : Controller
    {
        // POST: MFile/SubirArchivo
        // Mapeo de rutas MVC en caso de refactorizar el nombre de la acción.
        
        [Route("MFile/SubirArchivo")]
        public ActionResult SubirArchivo(HttpPostedFileBase input_file)
        {
            
            //Si el archivo no es nulo y su propiedad no está vacia.
            if(input_file == null || String.IsNullOrEmpty(input_file.FileName))
            {
                return View("Fracaso");
            }

            MFile file = new MFile()
            {
                //3 métodos de extensión de la clase abstracta HttpPostedFileBase
                Nombre = input_file.NombreSinExtension(),
                Extension = input_file.Extension(),
                NombreCompleto = input_file.NombreCompleto(),
                Ruta = @"",
                Mime = input_file.ContentType,
                Size = (Int32)input_file.ContentLength,
                 
                

            };

            string server = Server.MapPath("~/Content/Uploads");
            string rutaArchivo = Path.Combine(server, file.NombreCompleto);
            try
            {
                input_file.SaveAs(rutaArchivo);
            }
            catch (Exception exc)
            {
                return View("Fracaso", exc);
            }


            file.Ruta = rutaArchivo; //Guardo la ruta si el archivo fue guardado.

            //Pasar el archivo a binario para poder almacenarlo en la base de datos
            byte[] binario;
            try
            {
                binario = Arch2Bin2Arch.File2Bin(file.Ruta);
            }
            catch (Exception exc)
            {
                binario = null;
                return View("Fracaso", exc);
            }
            
            

            //Creamos un query parametrizado. Mas seguro.
            string querystring = @"
                INSERT INTO 
                dbo.files (nombre, extension, nombrecompleto, ruta, mime, size, binary_stream)
                VALUES (@nombre, @extension, @nombrecompleto, @ruta, @mime, @size, @binary_stream);
            ";



            using (var conexion = Conector.Conexion())
            {

                using (SqlCommand comando = new SqlCommand(querystring, conexion)) {
                    
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                    comando.Parameters.Add("@extension", SqlDbType.VarChar);
                    comando.Parameters.Add("@nombrecompleto", SqlDbType.VarChar);
                    comando.Parameters.Add("@ruta", SqlDbType.VarChar);
                    comando.Parameters.Add("@mime", SqlDbType.VarChar);
                    comando.Parameters.Add("@size", SqlDbType.Int);
                    comando.Parameters.Add("@binary_stream", SqlDbType.VarBinary);

                    comando.Parameters["@nombre"].Value = file.Nombre;
                    comando.Parameters["@extension"].Value = file.Extension;
                    comando.Parameters["@nombrecompleto"].Value = file.NombreCompleto;
                    comando.Parameters["@ruta"].Value = file.Ruta;
                    comando.Parameters["@mime"].Value = file.Mime;
                    comando.Parameters["@size"].Value = file.Size;
                    comando.Parameters["@binary_stream"].Value = binario;
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.Close();
                    }
                    catch (Exception exc)
                    {
                        return View("Fracaso", exc);
                        throw;
                    }
                    
                }
                
            }
           
            return View("Exito",file);

            


        }
    }
}