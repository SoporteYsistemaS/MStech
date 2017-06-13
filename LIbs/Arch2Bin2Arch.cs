using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Libs
{
    public static class Arch2Bin2Arch
    {
        public static byte[] File2Bin(string ruta) 
        {//Convierte cualquier archivo en la ruta indicada a binario.
            
            byte[] archivo; //Instancia vacia

            //Trabajo con el contexto para el archivo con usings para que libere los recursos al terminar las {}
            using (var streamContext = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            {
                using (var lectorContext = new BinaryReader(streamContext))
                {
                    try
                    {
                        archivo = lectorContext.ReadBytes((int)streamContext.Length);
                    }
                    catch (Exception)
                    {
                        //TODO IMPLEMENTAR EXCEPCIONES
                        throw;
                    }
                    
                }
            }
            return archivo;
            
        }

        public static bool Bin2File(Byte[] bin_data, string ruta_destino)
        {/*convierte un objeto binario a un archivo que se guarda en la ruta
           y con el nombre pasado en la "ruta de destino"  */
            using (var fsContext = new FileStream(ruta_destino, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    //Escribo el archivo en la ruta pasada como parametro
                    fsContext.Write(bin_data, 0, bin_data.Length);
                }
                catch (Exception)
                {
                    //TODO IMPLEMENTAR EXCEPCIONES
                    throw;
                    return false;
                }
                
            }
            return true;
        }
        
    }
}
