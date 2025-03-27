using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;

namespace GestionTI.model.proc
{
    public class Mo_Ticket
    {
        public static Response IngresoTicket(Req_Ticket ticket)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = ticket._trankey._app_fuente;
                vector_1[1] = ticket._trankey._app_version;
                vector_1[2] = ticket.cod_activo.ToString();
                vector_1[3] = ticket.estado;
                vector_1[4] = ticket.prioridad;
                vector_1[5] = ticket.descripcion;
                vector_1[6] = ticket.cod_usua_asig.ToString();
                vector_1[7] = ticket.cod_usua_creacion.ToString();
                vector_1[8] = "";
                vector_1[9] = "";
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(ticket._trankey, vector_1);

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

                    string[] vector = new string[6];
                    cb.sp = "dbo.usp_Web_O_IngresoTicket_G_ingr_tick";//poner el nombre correcto
                    vector[0] = "@ac_codigo,i," + ticket.cod_activo;
                    vector[1] = "@ti_estado,v," + ticket.estado;
                    vector[2] = "@ti_prioridad,v," + ticket.prioridad;
                    vector[3] = "@ti_descripcion,v," + ticket.descripcion;
                    vector[4] = "@us_codi_asignado,i," + ticket.cod_usua_asig;
                    vector[5] = "@us_codi_crea,i," + ticket.cod_usua_creacion;
                    

                    dt = cb.consultar(vector, 6, strCon);


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
