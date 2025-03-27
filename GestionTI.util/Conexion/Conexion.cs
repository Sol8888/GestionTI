using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTI.util.Conexion
{
    public class Conexion
    {
        private static string servidor = @"192.168.100.88";
        private static string base_tip = "GestionTi";
        private static string usuario = "sa";
        private static string password = "1234";
        private static string clav_priv = "dfaeiriecmvjhe3943dfadahyeu3456";
        public static string CadenaConexion()
        {
            //string str;
            //System.IO.StreamReader sr;
            //string cadena;

            //try
            //{

            //    string cad = "";
            //    cad = HttpContext.Current.Request.MapPath("~");
            //    sr = new System.IO.StreamReader(cad + @"\App_Data\Credenciales\conectar.txt");//PEDIR EL ARCHIVO CORRECTO
            //    str = sr.ReadLine(); // servidor
            //    if (str != null)
            //        cadena = "Data Source=" + str.Trim();
            //    else
            //        return "";
            //    str = sr.ReadLine(); // base
            //    if (str != null)
            //        cadena = cadena + ";Initial Catalog=" + str.Trim();
            //    else
            //        return "";
            //    str = sr.ReadLine(); // usuario
            //    if (str != null)
            //        cadena = cadena + ";User ID=" + str.Trim();
            //    else
            //        return "";
            //    str = sr.ReadLine(); // password
            //    if (str != null)
            //        cadena = cadena + ";Password=" + str.Trim();
            //    else
            //        return "";
            //    sr.Close();

            //}
            //catch (Exception ex)
            //{
            //    return "";

            //}
            //return cadena;
            return "Data Source=" + servidor + ";Initial Catalog=" + base_tip + ";User ID=" + usuario + ";Password=" + password + ";TrustServerCertificate=True";
        }

        public static string CadenaClavePrivada()
        {
            //string str;
            //System.IO.StreamReader sr;
            //string cadena;
            //try
            //{
            //    string cad = "";
            //    cad = HttpContext.Current.Request.MapPath("~");
            //    sr = new System.IO.StreamReader(cad + @"\App_Data\Credenciales\conectar.txt");
            //    str = sr.ReadLine(); // servidor
            //    str = sr.ReadLine(); // base
            //    str = sr.ReadLine(); // usuario
            //    str = sr.ReadLine(); // password
            //    str = sr.ReadLine(); // .
            //    str = sr.ReadLine(); // clavePrivada
            //    if (str != null)
            //        cadena = str.Trim();
            //    else
            //        return "";
            //    sr.Close();
            //}
            //catch (Exception ex)
            //{
            //    return "";
            //}
            //return cadena;
            return clav_priv.Trim();

        }
    }
}
