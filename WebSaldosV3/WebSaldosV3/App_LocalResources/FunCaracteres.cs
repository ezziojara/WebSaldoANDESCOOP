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
/// Descripción breve de FunCaracteres
/// </summary>
public class FunCaracteres
{
    public FunCaracteres()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    //*******************************************************************
    //Metodo: Left
    //Funcionalidad : Selecciona Caracter Izquierdo
    //Entrada : Int Rut SoloNumeros
    //Salida : string Digito Verificador
    //Creado : 22/12/2010
    //Modificado ;
    //*******************************************************************
    public string Left(string text, int length)
    {
        return text.Substring(0, length);
    }
    //*******************************************************************
    //Metodo: Right
    //Funcionalidad : Selecciona Caracter Derecho
    //Entrada : Int Rut SoloNumeros
    //Salida : string Digito Verificador
    //Creado : 22/12/2010 por Cesar Reyes
    //Modificado ;
    //*******************************************************************

    public string Right(string text, int length)
    {
        return text.Substring(text.Length - length, length);
    }
    //*******************************************************************
    //Metodo: SacarSoloNumeroRut
    //Funcionalidad : Selecciona solo los numeros del rut
    //Entrada : string Rut Completo
    //Salida : int Solo numeros
    //Creado : 22/12/2010 por Cesar Reyes
    //Modificado ;
    //*******************************************************************
    public int SacarSoloNumerosRut(string rut)
    {
        try
        {
            string iRutsdigitos = "0";
            if (rut.Length == 2)
                iRutsdigitos = rut.Substring(0, 1);
            if (rut.Length == 3)
                iRutsdigitos = rut.Substring(0, 2);
            if (rut.Length == 4)
                iRutsdigitos = rut.Substring(0, 3);
            if (rut.Length == 8)
                iRutsdigitos = rut.Substring(0, 7);
            if (rut.Length == 9)
                iRutsdigitos = rut.Substring(0, 8);
            if (rut.Length == 10)
                iRutsdigitos = rut.Substring(0, 9);
            int iRutsd = Int32.Parse(iRutsdigitos);
            return iRutsd;
        }
        catch (Exception ex)
        {

            return 5844;
        }
    }
}
