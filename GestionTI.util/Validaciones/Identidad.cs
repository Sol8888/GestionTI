using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;


namespace GestionTI.util.Validaciones
{
    public class Identidad
    {
        public static Response validar_Identidad(Trankey trankey, String[] _registrolog)
        {

            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };
            string clavePrivada = util.Conexion.Conexion.CadenaClavePrivada();


            try
            {
                if (!util.Validaciones.Autenticador.Verificar(trankey, clavePrivada))
                {
                    res.Message = "Error de autenticación";
                    res.CodigoError = 101;
                    return res;
                }

                data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                System.Data.DataTable dt;
                string strCon = util.Conexion.Conexion.CadenaConexion();
                if (string.IsNullOrEmpty(strCon))
                {
                    res.CodigoError = 102;
                    res.Message = "Error de conexión";
                    return res;
                }

                string[] vector = new string[12];
                cb.sp = "holaprocedure";
                vector[0] = "@app_fuente,v," + _registrolog[0];
                vector[1] = "@app_version,v," + _registrolog[1];
                vector[2] = "@para_1,v," + _registrolog[2];
                vector[3] = "@para_2,v," + _registrolog[3];
                vector[4] = "@para_3,v," + _registrolog[4];
                vector[5] = "@para_4,v," + _registrolog[5];
                vector[6] = "@para_5,v," + _registrolog[6];
                vector[7] = "@para_6,v," + _registrolog[7];
                vector[8] = "@para_7,v," + _registrolog[8];
                vector[9] = "@para_8,v," + _registrolog[9];
                vector[10] = "@para_9,v," + _registrolog[10];
                vector[11] = "@para_10,v," + _registrolog[11];
                dt = cb.consultar(vector, 12, strCon);
                res.CodigoError = cb.valo_erro;

                if (!res.CodigoError.Equals(-1))
                {
                    res.Message = "Que pena me da tu caso";
                    res.Message = cb.valo_resp;
                    return res;
                }
                else
                {
                    res.Message = "Validado Ingreso";
                    res.Message = cb.valo_resp;
                    return res;
                }

            }
            catch (Exception ex)
            {
                res.CodigoError = -100;
                res.Message = "Error inesperado";
                res.Message = ex.Message;

            }
            return res;

        }
    }
}
