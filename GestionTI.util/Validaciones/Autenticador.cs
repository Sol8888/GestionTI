using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTI.util.Validaciones
{
    public class Autenticador
    {
        public static bool Verificar(util.Request.Trankey respuesta, string clavePrivada)
        {
            string nuevaCadena = respuesta._random + respuesta._fecha + clavePrivada;
            string cadenaConvertida = Base64(nuevaCadena);
            if (respuesta._firma.Equals(cadenaConvertida))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static private string Base64(string cadena)
        {
            return System.Convert.ToBase64String(ToSha256(cadena));
        }

        static public byte[] ToSha1(string cadena)
        {
            byte[] valor;
            System.Security.Cryptography.SHA1 sHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            valor = sHA1.ComputeHash(ToStream(cadena));
            return sHA1.ComputeHash(ToStream(cadena));

        }

        static public byte[] ToSha256(string cadena)
        {
            byte[] valor;
            System.Security.Cryptography.SHA256 sHA256 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            valor = sHA256.ComputeHash(ToStream(cadena));
            return sHA256.ComputeHash(ToStream(cadena));
        }

        private static Stream ToStream(string cadena)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter sw = new StreamWriter(stream);
            sw.Write(cadena);
            sw.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
