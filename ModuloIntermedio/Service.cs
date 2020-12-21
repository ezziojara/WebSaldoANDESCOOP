using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ModuloIntermedio
{
    public class Service
    {
        public Service()
        {

            //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
            //InitializeComponent(); 
        }


        public String TraePerfiles()
        {
            Perfiles objPerfiles = new Perfiles();
            return objPerfiles.TraePerfilesInter();

        }

        public string ConsultaSaldosSocio(string xml, int Tipo)
        {
            ConsultaSaldos objConsultaSaldos = new ConsultaSaldos();
            return objConsultaSaldos.TraeSaldos(xml, Tipo);
        }

        public string TraePersonas(int lgnRut)
        {
            Persona objPersona = new Persona();
            return objPersona.TraePersona(lgnRut);

        }


        public string AutenticaUsuario(string Rut, string Pasww)
        {
            string xml = "<ParametrosIn Rut=\"" + Rut + "\" Password=\"" + Pasww + "\" />";
            Persona objPersona = new Persona();
            //return "<ParametrosOut><Autorizacion cCodigo=\"2\" Mensaje=\"No Autorizado\"><Perfiles></Perfiles></Autorizacion></ParametrosOut>";
            //return "<ParametrosOut><Autorizacion cCodigo=\"2\" Mensaje=\"No Autorizado\"><Perfiles></Perfiles></Autorizacion></ParametrosOut>";
            string XMLSAL = objPersona.AutenticaUsuario(xml);
            return XMLSAL;

        }

        public Boolean ModificaUsuario(string xml)
        {
            Persona objPersona = new Persona();
            return objPersona.ModificaUsuario(xml);

        }
        public DataTable traeDtUsuariosSocios()
        {
            Datos objDatos = new Datos();
            return objDatos.traeDtUsuariosSocios();
        }

        public int InsertaMasivoSocios()
        {
            Datos objDatos = new Datos();
            return 0;
        }

        public void cargaMasiva()
        {
            Datos objDatos = new Datos();
            DataTable objDt = objDatos.traeDtUsuariosSocios();
            Encripta objEncr = new Encripta();
            int salidaEliminaSocio = objDatos.eliminaUsuariosSocios();
            foreach (DataRow dr in objDt.Rows)
            {
                string ipersona = dr["ipersona"].ToString();
                string encripta = objEncr.Encrit(dr["nPassword"].ToString());
                int salida = objDatos.cargaMasivaUsuariosSocios(Int32.Parse(dr["ipersona"].ToString()), encripta);

            }
        }

    }
}