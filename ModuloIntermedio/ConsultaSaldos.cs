using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloIntermedio
{
   public class ConsultaSaldos
    {
       public String TraeSaldos(string xml, int op)
       {
           string strResultados = "";
           switch (op)
              {
                        case 1:
                        strResultados =   TraeCapitalSocio(xml);
                        break;
                        case 2:
                        strResultados = TraeLibreta(xml);
                        break;
                        case 3:
                        strResultados = TraeLibretaVista(xml);
                        break;
                        case 4:
                        strResultados = TraeDeposito(xml);
                        break;
                        case 7:
                        strResultados = TraeColocaciones(xml);
                        break;
                        case 8:
                        strResultados = TraeCredAutomatico(xml);
                        break;
                        case 11:
                        strResultados = TraeCastigo(xml);
                        break;
                   
              }

           return strResultados;       
           
       }

        public String TraeCapitalSocio(string xml)
        {
            try
            {
                Datos objDatos = new Datos();
                //OWN_FULLCOOP.PRC_SlcFULLSOC_TraeMovCapital
                //comCapitalSocio.CapitalSocio objCapitalSocio = new comCapitalSocio.CapitalSocio();
                String InfoParamXML = objDatos.TraeCapital(xml);
                return InfoParamXML;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            

        }
        public String TraeLibreta(string xml)
        {
            try
            {
                Datos objDatos = new Datos();
                //comLibretaCliente.LibretaCliente objLibreta = new comLibretaCliente.LibretaCliente();
                String InfoParamXML = objDatos.TraeLibretaCliente(xml);
                InfoParamXML = "<Libretas>" + InfoParamXML + "</Libretas>";
                return InfoParamXML;

                

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }


        }
        public String TraeLibretaVista(string xml)
        {
            try
            {
                Datos objDatos = new Datos();
                //comLibretaVista._LibretaVista objLVista = new comLibretaVista.LibretaVista();

                String InfoParamXML = objDatos.TraeLibretaVista(xml);
                return InfoParamXML;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }


        }
        public String TraeDeposito(string xml)
        {
            try
            {
                Datos objDatos = new Datos();
                //comDepositos.DepositoPlazo objdepo = new comDepositos.DepositoPlazo();
                String InfoParamXML = objDatos.TraeDepositosPlazo(xml);
                InfoParamXML = "<DepositoPlazo>" + InfoParamXML +"</DepositoPlazo>";
                return InfoParamXML;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }


        }
       //COLOCACIONES
        public String TraeColocaciones(string xml)
        {
            try
            {
                Datos objDatos = new Datos();
                //comColocacionPru.ColocacionPru objcolPru = new comColocacionPru.ColocacionPru();
                 String InfoParamXML = objDatos.TraeColocaciones(xml);
                InfoParamXML = "<Colocaciones>" + InfoParamXML + "</Colocaciones>"; 
                           
                
                return InfoParamXML;
            }
            catch (Exception ex)
                {
                    return ex.ToString();
                }
            
        }
        public String TraeCredAutomatico(string xml)
        {
            try
            {
                Datos objDatos = new Datos();
                //comCredAuto.CredAuto objAutomatico = new comCredAuto.CredAuto();
                String InfoParamXML = objDatos.TraeCreditosAutomaticos(xml);
                return InfoParamXML;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
        public String TraeCastigo(string xml)
        {
            try
            {
                Datos objDatos = new Datos();
                //comCastigo.Castigo_Ctr objCst = new comCastigo.Castigo_Ctr();
                String InfoParamXML = objDatos.TraeCastigos(xml);
                InfoParamXML = "<Colocaciones>" + InfoParamXML + "</Colocaciones>"; 
                return InfoParamXML; 
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }





    }
}
