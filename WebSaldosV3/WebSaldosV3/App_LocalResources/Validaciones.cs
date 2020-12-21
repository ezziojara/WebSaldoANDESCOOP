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
/// Descripción breve de Validaciones
/// </summary>
public class Validaciones
{
    public Validaciones()
    {
    }
    //*******************************************************************
    //Metodo: Trae Digito Verificador
    //Funcionalidad : Trae el digito verificador de un rut ingresado
    //Entrada : Int Rut SoloNumeros
    //Salida : string Digito Verificador
    //Creado : 22/12/2010
    //Modificado ;
    //*******************************************************************
    public string digitoVerificador(int rut)
    {
        int Digito;
        int Contador;
        int Multiplo;
        int Acumulador;
        string RutDigito;

        Contador = 2;
        Acumulador = 0;

        while (rut != 0)
        {
            Multiplo = (rut % 10) * Contador;
            Acumulador = Acumulador + Multiplo;
            rut = rut / 10;
            Contador = Contador + 1;
            if (Contador == 8)
            {
                Contador = 2;
            }

        }

        Digito = 11 - (Acumulador % 11);
        RutDigito = Digito.ToString().Trim();
        if (Digito == 10)
        {
            RutDigito = "K";
        }
        if (Digito == 11)
        {
            RutDigito = "0";
        }
        return (RutDigito);

    }
    //*******************************************************************
    //Metodo: Valida Rut
    //Funcionalidad : Validar Rut ingresando todos sus digitos
    //Entrada : Int Rut contodos sus digitos
    //Salida :Confirmacion de rut y rut formateado
    //*******************************************************************
     public String ValidaRut(String Rut)
    {
        FunCaracteres objCarac = new FunCaracteres();
        string iCaraterFinal = objCarac.Right(Rut.ToString(),1);
        string dv = digitoVerificador(objCarac.SacarSoloNumerosRut(Rut.ToString()));
        if (iCaraterFinal == dv)
        {
            Formatos objFormatos = new Formatos();
            return objFormatos.DevuelveRutFormateado(Rut.ToString());
        }
        else
        {
            return "n";
        }


    }

       
}

