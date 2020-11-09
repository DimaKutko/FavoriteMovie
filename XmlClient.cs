using System;
using System.Collections.Generic;
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


    public List<Movie> ToSearchList(String xml)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);

        XmlNodeList nodes = doc.GetElementsByTagName("result");

        List<Movie> list = new List<Movie>(nodes.Count);

        foreach (XmlNode node in nodes)
        {
            list.Add(
                new ShortMovie(
                    node.Attributes.GetNamedItem("title").Value,
                    node.Attributes.GetNamedItem("year").Value,
                    node.Attributes.GetNamedItem("imdbID").Value
                    )
            );
        }

        return list;
    }
}