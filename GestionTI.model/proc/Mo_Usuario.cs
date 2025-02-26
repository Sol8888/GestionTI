using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;

namespace GestionTI.model.proc
{
    public class Mo_Usuario
    {
        public static Response IngresoUsuarios(Req_Usuario usuario)
        {
            Response res = new Response() { CodigoError = 0, Message = "Sin Resultados", Result = null };

            try
            {
                string[] vector_1 = new string[13];

                vector_1[0] = usuario._trankey._app_fuente;
                vector_1[1] = usuario._trankey._app_version;
                vector_1[2] = usuario.nombre;
                vector_1[3] = usuario.apellido;
                vector_1[4] = usuario.email;
                vector_1[5] = usuario.rol;
                vector_1[6] = usuario.cuenta;
                vector_1[7] = usuario.contrasena;
                vector_1[8] = usuario.cod_departamento.ToString();
                vector_1[9] = usuario.cod_usua_creacion.ToString();
                vector_1[10] = "";
                vector_1[11] = "";
                vector_1[12] = "";
                Response res_identidad = util.Validaciones.Identidad.validar_Identidad(usuario._trankey, vector_1);

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
                    cb.sp = "sp_CrearUsuario";//poner el nombre correcto
                    vector[0] = "@us_nombre,v," + usuario.nombre;
                    vector[1] = "@us_apellido,v," + usuario.apellido;
                    vector[2] = "@us_email,v," + usuario.email;
                    vector[3] = "@us_rol,v," + usuario.rol;
                    vector[4] = "@us_cuenta,v," + usuario.cuenta;
                    vector[5] = "@us_contrasena,v," + usuario.contrasena;
                    vector[6] = "@de_codig,i," + usuario.cod_departamento;
                    vector[7] = "@us_codi_crea,i," + usuario.cod_usua_creacion;




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
