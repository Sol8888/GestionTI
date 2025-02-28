using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;

namespace GestionTI.model.proc
{
    public class Mo_Marca
    {
        public static Response IngresoMarca(Req_Marca marca)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = marca._trankey._app_fuente;
                vector_1[1] = marca._trankey._app_version;
                vector_1[2] = marca.nombre;
                vector_1[3] = marca.cod_usua_creacion.ToString();
                vector_1[4] = "";
                vector_1[5] = "";
                vector_1[6] = "";
                vector_1[7] = "";
                vector_1[8] = "";
                vector_1[9] = "";
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(marca._trankey, vector_1);

                if (!res_identidad.CodigoError.Equals(-1))
                {
                    res.Message = "Que pena me da tu caso";
                    res.CodigoError = res_identidad.CodigoError;
                    res.Message = res_identidad.Message;
                    return res;
                }
                else
                {

                    data.DAO.c_base_datos cb = new data.DAO.c_base_datos();
                    System.Data.DataTable dt;
                    string strCon = util.Conexion.Conexion.CadenaConexion();

                    string[] vector = new string[2];
                    cb.sp = "dbo.sp_InsertarMarca";//poner el nombre correcto
                    vector[0] = "@ma_nombre,v," + marca.nombre;
                    vector[1] = "@us_codi_crea,i," +  marca.cod_usua_creacion;

                    dt = cb.consultar(vector, 2, strCon);


                    res.CodigoError = cb.valo_erro;
                    if (res.CodigoError == -1)
                    {

                        res.Message = "OK";
                        res.Message = cb.valo_resp;
                        //res.Result = dt;

                    }
                    else
                    {
                        res.Message = "Que pena me da tu caso";
                        res.Message = cb.valo_resp;
                    }
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

