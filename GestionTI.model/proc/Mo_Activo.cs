using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;

namespace GestionTI.model.proc
{
    public class Mo_Activo
    {
        public static Response IngresoActivo(Req_Activo activo)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = activo._trankey._app_fuente;
                vector_1[1] = activo._trankey._app_version;
                vector_1[2] = activo.nombre;
                vector_1[3] = activo.cod_tipo_acti.ToString();
                vector_1[4] = activo.cod_modelo.ToString();
                vector_1[5] = activo.serie;
                vector_1[6] = activo.cod_estado.ToString();
                vector_1[7] = activo.fech_adquisicion;
                vector_1[8] = activo.cod_proveedor.ToString();
                vector_1[9] = activo.cod_usua_creacion.ToString();
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(activo._trankey, vector_1);

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

                    string[] vector = new string[8];
                    cb.sp = "dbo.usp_Web_O_IngresoActivo_G_ingr_acti";//poner el nombre correcto
                    vector[0] = "@ac_nombre,v," + activo.nombre;
                    vector[1] = "@ta_codigo,i," + activo.cod_tipo_acti;
                    vector[2] = "@mo_codigo,i," + activo.cod_modelo;
                    vector[3] = "@ac_serie,v," + activo.serie;
                    vector[4] = "@ea_codigo,i," + activo.cod_estado;
                    vector[5] = "@ac_fecha_adquisicion,v," + activo.fech_adquisicion;
                    vector[6] = "@pr_codigo,i," + activo.cod_proveedor;
                    vector[7] = "@us_codi_crea,i," + activo.cod_usua_creacion;

                    dt = cb.consultar(vector, 8, strCon);


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
