using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
namespace ModuloIntermedio
{ 
    public class Encripta 
{
        byte[] _key;
        byte[] _iv;
        public Encripta() 
    {
        _key = Encoding.ASCII.GetBytes("12EstaClave34es56dificil489ssswf");
        _iv = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
    } 
    public string Encrit(string inputText) 
    { 
        byte[] inputBytes = Encoding.ASCII.GetBytes(inputText);
        byte[] encripted;
        RijndaelManaged cripto = new RijndaelManaged(); 
        using (MemoryStream ms = new MemoryStream(inputBytes.Length))
        {
            using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(_key, _iv), CryptoStreamMode.Write)) { objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
            objCryptoStream.FlushFinalBlock(); objCryptoStream.Close();
        } 
            encripted = ms.ToArray();
        } 
        return Convert.ToBase64String(encripted);
    }
    public string Desencrit(string inputText)
    {
        byte[] inputBytes = Convert.FromBase64String(inputText);
        byte[] resultBytes = new byte[inputBytes.Length];
        string textoLimpio = String.Empty;
        RijndaelManaged cripto = new RijndaelManaged();
        using (MemoryStream ms = new MemoryStream(inputBytes))
        {
            using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(_key, _iv), CryptoStreamMode.Read))
            {
                using (StreamReader sr = new StreamReader(objCryptoStream, true))
                {
                    textoLimpio = sr.ReadToEnd();
                }
            }
        }
        return textoLimpio;
    }
}
}
