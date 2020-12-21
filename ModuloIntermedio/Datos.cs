using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace ModuloIntermedio
{
    public class Datos
    {
        // String de Conexion  Data Source=localhost;Initial Catalog=fullnoticias;Integrated Security=True
        SqlConnection Conn = new SqlConnection();
        public Datos()
        {
            string SQLConnection = ConfigurationManager.AppSettings.Get("Conex");
            //string SQLConnection = @"Data Source=localhost;Initial Catalog=FULL_INTERMEDIO;User ID=own_fullcoop;Password=fullcoopsa";
            Conn.ConnectionString = SQLConnection;

        }
        public void Open()
        {

            //string SQLConnection = @"Data Source=INF-MDESARROLLO\MARIO;Initial Catalog=FULL_INTERMEDIO;User ID=own_fullcoop;Password=fullcoopsa";
            //Conn.Close();
            Conn.Open();
        }
        public void Cerrar()
        {
            Conn.Close();
        }
      
        public string AutenticaSocio(string xml)
        {
           
            DataSet datos = new DataSet();
             Open();

                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLSEG_AutenticaSocioUsuarioCoop " + " '" + xml + "'", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);

            
                comando.Fill(datos, "Transaccion");

                string xmll = "";

                foreach (DataRow theRow in datos.Tables[0].Rows)
                {
                    xmll = (theRow["Autentica"].ToString());
                }
                
                Cerrar();

                return xmll;
            
        }
        public Boolean ModificaSocio(string xml)
        {

           try
            {
                int CountFiles = 0;
                Boolean Result = false;

                
                Open();
                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_AdmFULLSEG_MantieneUsuarioSocio " + " '" + xml + "', " + "" + 0 + "", Conn);
                CountFiles = Cmd.ExecuteNonQuery();
                Cerrar();

                if (CountFiles > 0)
                    Result = true;

                Cerrar();
                return Result;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return false;
            }
        }
        public string TraePerfiles(string xml)
        {

            DataSet datos = new DataSet();
            try
            {
                Open();

                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLADM_ObtenerReferencias " + " '" + xml + "'", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);


                comando.Fill(datos, "Transaccion");

                string xmll = "";
                int i = 0;
                foreach (DataRow theRow in datos.Tables[i].Rows)
                {
                    xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                    i = i + 1;
                }
                Cerrar();


                return xmll;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return ex.ToString();
            }
        }
        public string TraePersona(int crut)
        {

            DataSet datos = new DataSet();
            try
            {
                Open();

                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLCOO_DatosPersonaXML " + " " + crut + " , " + "" + 0 + "", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);


                comando.Fill(datos, "Transaccion");

                string xmll = "";
                int i = 0;
                foreach (DataRow theRow in datos.Tables[i].Rows)
                {                          
                    xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                    i = i + 1;
                }

                Cerrar();


                return xmll;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return ex.ToString();
            }
        }

        public string TraeCapital(string xml)
        {
           
            DataSet datos = new DataSet();
            try
            {
                Open();

                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLSOC_TraeMovimientoCapital " + " '" + xml + "', " + "" + 0 + "", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);

            
                comando.Fill(datos, "Transaccion");

                string xmll = "";
                int i = 0;
                foreach (DataRow theRow in datos.Tables[i].Rows)
                {
                    xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                    i = i + 1;
                }
                
                Cerrar();


                return xmll;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return ex.ToString();
            }
        }

         public string TraeColocaciones(string xml)
        {
           
            DataSet datos = new DataSet();
            try
            {
                Open();

                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLCOL_TraeColocacionesIntermedio " + " '" + xml + "', " + "" + 0 + "", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);

            
                comando.Fill(datos, "Transaccion");

                string xmll = "";
                int i = 0;
                foreach (DataRow theRow in datos.Tables[i].Rows)
                {
                    xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                    i = i + 1;
                }
                
                Cerrar();
                return xmll;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return ex.ToString();
            }
        }

         public string TraeCreditosAutomaticos(string xml)
        {
           
            DataSet datos = new DataSet();
            try
            {
                Open();

                SqlCommand Cmd = new SqlCommand("FULLCOOP.OWN_FULLCOOP.PRC_SlcFULLCAJ_TraeCredAutomatico " + " '" + xml + "', " + "" + 0 + "", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);

            
                comando.Fill(datos, "Transaccion");

                string xmll = "";
                int i = 0;
                foreach (DataRow theRow in datos.Tables[i].Rows)
                {
                    xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                    i = i + 1;
                }
                
                Cerrar();


                return xmll;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return ex.ToString();
            }
        }
          public string TraeCastigos(string xml)
        {
           
            DataSet datos = new DataSet();
            try
            {
                Open();

                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.Prc_SlcFULLCOB_TraeColoCastigadasInt" + " '" + xml + "', " + "" + 0 + "", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);

            
                comando.Fill(datos, "Transaccion");

                string xmll = "";
                int i = 0;
                foreach (DataRow theRow in datos.Tables[i].Rows)
                {
                    xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                    i = i + 1;
                }
                
                Cerrar();


                return xmll;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return ex.ToString();
            }
        }
         public string TraeLibretaCliente(string xml)
        {
           
            DataSet datos = new DataSet();
            try
            {
                Open();
                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLCOL_TraeLibretasClienteInt " + " '" + xml + "', " + "" + 0 + "", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);
                           
                comando.Fill(datos, "Transaccion");

                string xmll = "";
                int i = 0;
                foreach (DataRow theRow in datos.Tables[i].Rows)
                {
                    xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                    i = i + 1;
                }
                
                Cerrar();


                return xmll;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return ex.ToString();
            }
        }
         public string TraeDepositosPlazo(string xml)
        {
           
            DataSet datos = new DataSet();
            try
            {
                Open();
                SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLCAJ_TraeDatosDepositoPlazoInt " + " '" + xml + "', " + "" + 0 + "", Conn);
                SqlDataAdapter comando = new SqlDataAdapter(Cmd);
                           
                comando.Fill(datos, "Transaccion");

                string xmll = "";
                int i = 0;
                foreach (DataRow theRow in datos.Tables[i].Rows)
                {
                    xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                    i = i + 1;
                }
                
                Cerrar();


                return xmll;
            }
            catch (Exception ex)
            {
                Error obj = new Error();
                obj.CapturaError(ex.ToString());
                return ex.ToString();
            }
        }
         public string TraeLibretaVista(string xml)
         {

             DataSet datos = new DataSet();
             try
             {
                 Open();
                 SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLCAP_TraeDatosCtaVistaInt " + " '" + xml + "', " + "" + 0 + "", Conn);
                 SqlDataAdapter comando = new SqlDataAdapter(Cmd);

                 comando.Fill(datos, "Transaccion");

                 string xmll = "";
                 int i = 0;
                 foreach (DataRow theRow in datos.Tables[i].Rows)
                 {
                     xmll = xmll + (theRow["XML_F52E2B61-18A1-11d1-B105-00805F49916B"].ToString());
                     i = i + 1;
                 }

                 Cerrar();


                 return xmll;
             }
             catch (Exception ex)
             {
                 Error obj = new Error();
                 obj.CapturaError(ex.ToString());
                 return ex.ToString();
             }
         }
        //************************************************************
        //Metodo captura error para ser visualizado en la trasa de sqlServer-
        //Creado por: Cesar Reyes
        //Fecha de creacion : 26-02-2011
         //************************************************************
         public string CapturaError(string err)
         {

             DataSet datos = new DataSet();
             try
             {
                 Open();
                 SqlCommand Cmd = new SqlCommand("OWN_FULLCOOP.PRC_SlcFULLADM_CapturaErrorInt " + " '" + err + "'", Conn);
                 SqlDataAdapter comando = new SqlDataAdapter(Cmd);

                 comando.Fill(datos, "Transaccion");
                 return "";

             }
             catch (Exception ex)
             {
                 return ex.ToString();
             }
         }
         public DataTable traeDtUsuariosSocios()
         {

             DataTable datos = new DataTable();
           
                 Open();
                 SqlCommand Cmd = new SqlCommand("select * from fullcoop.own_fullcoop.FULLSEG_UsuarioSocio ", Conn);
                 SqlDataAdapter comando = new SqlDataAdapter(Cmd);

                 comando.Fill(datos);
                 Cerrar();
                 return datos;
            
         }

         public int eliminaUsuariosSocios()
         {
             DataTable datos = new DataTable();
             Open();
             SqlCommand Cmd = new SqlCommand("delete from OWN_FULLCOOP.FULLSEG_UsuarioSocio", Conn);
             Cmd.ExecuteNonQuery();
             int salida = Cmd.ExecuteNonQuery();
             
             Cerrar();
             return salida;

         }

         public int cargaMasivaUsuariosSocios(int iPersona, string nPassword)
         {
             DataTable datos = new DataTable();
             Open();
             SqlCommand Cmd2 = new SqlCommand("INSERT INTO OWN_FULLCOOP.FULLSEG_UsuarioSocio  select " + iPersona + ",'" + nPassword + "',getdate(),getdate()," + 242 + "," + 1, Conn);
             int salida = Cmd2.ExecuteNonQuery();
             Cerrar();
             return salida;

         }
      

    }

}















