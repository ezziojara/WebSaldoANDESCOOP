using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Descripción breve de Formatos
/// </summary>
public class Formatos
{
    public Formatos()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    //*******************************************************************
    //Metodo: DevuelveRutFormateado
    //Funcionalidad : Formatea un rut 
    //Entrada : string Rut Completo
    //Salida : string Rut Formateado
    //Creado : 22/12/2010 por Cesar Reyes
    //Modificado ;
    //*******************************************************************
    public String DevuelveRutFormateado(string rut)
    {
        string strRutFormateado = "0";
        
        if (rut.Length == 2)
            strRutFormateado = rut.Substring(0, 1) + "-" + rut.Substring(1, 1);
        if (rut.Length == 3)
            strRutFormateado = rut.Substring(0, 1) + "-" + rut.Substring(2, 1);
        if (rut.Length == 4)
            strRutFormateado = rut.Substring(0, 1)  + "-" + rut.Substring(3, 1);
        if (rut.Length == 5)
            strRutFormateado = rut.Substring(0, 1) + "." + rut.Substring(1, 3) +  "-" + rut.Substring(4, 1);
        if (rut.Length == 6)
            strRutFormateado = rut.Substring(0, 2) + "." + rut.Substring(2, 3) +  "-" + rut.Substring(5, 1);
        if (rut.Length == 7)
            strRutFormateado = rut.Substring(0, 3) + "." + rut.Substring(3, 3) + "-" + rut.Substring(6, 1);
        if (rut.Length == 8)
            strRutFormateado = rut.Substring(0, 1) + "." + rut.Substring(1, 3) + "." + rut.Substring(4, 3) + "-"  + rut.Substring(7, 1);
        if (rut.Length == 9)
            strRutFormateado = rut.Substring(0, 2) + "." + rut.Substring(2, 3) + "." + rut.Substring(5, 3) + "-" + rut.Substring(8, 1);
        return strRutFormateado;
    }
    //*******************************************************************
    //Metodo: QuitaFormatoRut
    //Funcionalidad : saca formato a un rut 
    //Entrada : string Rut Completo
    //Salida : string Rut sin Formateado
    //Creado : 22/12/2010 por Cesar Reyes
    //Modificado ;
    //*******************************************************************
    public string QuitaFormatoRut(string rut)
    {
        
        string strRutQuitaGuion = rut.Replace("-", "");
        string strRutQuitaPunto = strRutQuitaGuion.Replace(".", "");
        string strRutSinFormato = "2";
        if (strRutQuitaPunto.Length == 2)
            strRutSinFormato = strRutQuitaPunto.Substring(0, 1);
        if (strRutQuitaPunto.Length == 3)
            strRutSinFormato = strRutQuitaPunto.Substring(0, 2);
        if (strRutQuitaPunto.Length == 4)
            strRutSinFormato = strRutQuitaPunto.Substring(0, 3);
        if (strRutQuitaPunto.Length == 5)
            strRutSinFormato = strRutQuitaPunto.Substring(0, 4);
        if (strRutQuitaPunto.Length == 6)
            strRutSinFormato = strRutQuitaPunto.Substring(0, 5);
        if (strRutQuitaPunto.Length == 7)
            strRutSinFormato = strRutQuitaPunto.Substring(0, 6);

        if (strRutQuitaPunto.Length == 8)
            strRutSinFormato = strRutQuitaPunto.Substring(0, 7);
        if (strRutQuitaPunto.Length == 9)
            strRutSinFormato = strRutQuitaPunto.Substring(0, 8);
        return strRutSinFormato;
    }
    //*******************************************************************
    //Metodo: FormateaNumero
    //Funcionalidad : formato moneda 
    //Entrada : string Numero
    //Salida : string Numeroformateado moneda
    //Creado :09/12/2010 por Cesar Reyes
    //Modificado ;
    //*******************************************************************
    public string FormateaNumero(string num)
    {
        if (num.Length < 4)
        {
            return "$" + num;
        }else{
            if (num != "0")
                if (num.Substring(num.Length - 3, 3) == ".00")
                    num = num.Substring(0, num.Length - 3);

            int op = num.Length;
            switch (op)
            {
                case 4:
                    num = num.Substring(0, 1) + "." + num.Substring(1, 3);
                    break;
                case 5:
                    num = num.Substring(0, 2) + "." + num.Substring(2, 3);
                    break;
                case 6:
                    num = num.Substring(0, 3) + "." + num.Substring(3, 3);
                    break;
                case 7:
                    num = num.Substring(0, 1) + "." + num.Substring(1, 3) + "." + num.Substring(4, 3);
                    break;
                case 8:
                    num = num.Substring(0, 2) + "." + num.Substring(2, 3) + "." + num.Substring(5, 3);
                    break;
                case 9:
                    num = num.Substring(0, 3) + "." + num.Substring(3, 3) + "." + num.Substring(6, 3);
                    break;
                case 10:
                    num = num.Substring(0, 1) + "." + num.Substring(1, 3) + "." + num.Substring(4, 3)+ "." + num.Substring(7, 3);
                    break;


            }
           
            return "$" + num;
        }


     }
    //*******************************************************************
    //Metodo: NombrePagina
    //Funcionalidad : Trae Nombre Pagina
    //Entrada : void
    //Salida : string Nombre Pagina
    //Creado :17/01/2011
    //autor : Cesar Reyes
    //Modificado ; 
    //*******************************************************************
    public String NombrePagina()
    {
        string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
        String result = arrResult[arrResult.GetUpperBound(0)];
        arrResult = result.Split('?');
        return arrResult[arrResult.GetLowerBound(0)];
    }
    //*******************************************************************
    //Metodo: NombrePagina
    //Funcionalidad : Trae Nombre Pagina
    //Entrada : void
    //Salida : string Nombre Pagina
    //Creado :17/01/2011
    //autor : Cesar Reyes
    //Modificado ; 
    //*******************************************************************
    public string ImprimePagina(string porigen, string pexel,string ip)
    {
        int largopag = porigen.Length;
        string pagImprime = porigen.Substring(0, largopag - 5) + "Print" + "." + porigen.Substring(largopag - 4, 4) + "?opcionExel=" + pexel;
       //pagImprime = "http://" + ip + "/SitioWebAndescoop/Impresion/" + pagImprime + "?opcionExel=" + pexel;
       // pagImprime = "http://200.27.145.181/SitioWebAndescoop/Impresion/" + pagImprime + "?opcionExel=" + pexel;
       // pagImprime = "http://192.168.0.70/SitioWebAndescoop/Impresion/" + pagImprime + "?opcionExel=" + pexel;
        string pagImprimefinal = "~/Impresion/" + pagImprime;
        return pagImprimefinal;
        
    }
    public string ImprimePaginav2(string porigen, string pexel, string ip)
    {
        int largopag = porigen.Length;
        string pagImprime = porigen.Substring(0, largopag - 5) + "Print" + "." + porigen.Substring(largopag - 4, 4) + "?opcionExel=" + pexel;
        string pagImprimefinal = "/websaldos/Impresion/" + pagImprime;
        return pagImprimefinal;

    }
    public string NombrePaginaFormateada(String cPagina)
    {
        string NombrePagina ="";
         switch (cPagina)
        {
            case "CreditoCuotas.aspx":
                NombrePagina = "Crédito en Cuotas";
                break;
            case "CreditoCuotas2.aspx":
                NombrePagina = "Detalle Crédito en Cuotas";
                break;
            case "CredExtraordinario.aspx":
                NombrePagina = "Crédito Extraordinario";
                break;
            case "CredExtraordinario2.aspx":
                NombrePagina = "Detalle Extraordinario";
                break;
            case "CreditoAutomatico.aspx":
                NombrePagina = "Crédito Automatico";
                break;
            case "CreditoAutomatico2.aspx":
                NombrePagina = "Detalle Crédito Automatico";
                break;

            case "Castigos.aspx":
                NombrePagina = "Castigos";
                break;
            case "Castigos2.aspx":
                NombrePagina = "Detalle Castigos";
                break;
             //Captaciones
            case "CapitalSocial.aspx":
                NombrePagina = "Capital Social";
                break;
            case "LibretaPlazo.aspx":
                NombrePagina = "Libreta a Plazo";
                break;
            case "LibretaPlazo2.aspx":
                NombrePagina = "Detalle Libreta a Plazo";
                break;
            case "LibretaVista.aspx":
                NombrePagina = "Cuenta Vista";
                break;
            case "DepositoPlazo.aspx":
                NombrePagina = "Deposito Plazo";
                break;
            case "DepositoPlazo2.aspx":
                NombrePagina = "Detalle Deposito Plazo";
                break;
             //Saldos
            case "SaldosColocaciones.aspx":
                NombrePagina = "Saldos Colocaciones";
                break;
            case "SaldosCaptaciones.aspx":
                NombrePagina = "Saldo Captaciones";
                break;
       

        }
         return NombrePagina;
       
      } 
     
    }

    

