using System;
using System.Xml;

class XmlClient
{
    public bool CheckResponseXml(String response)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);


            if (doc.DocumentElement.GetAttribute("response") == "True")
            {
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }   
    }
}