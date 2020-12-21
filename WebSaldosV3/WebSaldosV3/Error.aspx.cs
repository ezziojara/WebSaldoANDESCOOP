using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;


public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlSalida = Request.QueryString["tError"];
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(xmlSalida);

        string Error = "";
        string vSaldo = "";

        XmlNodeList lista2 = xDoc.GetElementsByTagName("Error");
        foreach (XmlElement nodo in lista2)
        {
            Error = nodo.GetAttribute("Err");
            
        }

        txtError.Text = Error;
                
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost/SitioWebAndesCoop/Default.aspx");
                
    }
}
