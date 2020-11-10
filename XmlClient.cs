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

    public FullMovie XmlToFullMovie(String xml)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);

        var root = doc.DocumentElement.InnerXml;

        doc.LoadXml(root);

        var movie = doc.DocumentElement;

        FullMoviePayload payload = new FullMoviePayload();

        payload.title = movie.GetAttribute("title");
        payload.year = movie.GetAttribute("year");
        payload.rated = movie.GetAttribute("rated");
        payload.released = movie.GetAttribute("released");
        payload.runtime = movie.GetAttribute("runtime");
        payload.genre = movie.GetAttribute("genre");
        payload.director = movie.GetAttribute("director");
        payload.writer = movie.GetAttribute("writer");
        payload.actors = movie.GetAttribute("actors");
        payload.plot = movie.GetAttribute("plot");
        payload.language = movie.GetAttribute("language");
        payload.awards = movie.GetAttribute("awards");
        payload.imdbRating = movie.GetAttribute("imdbRating");

        return new FullMovie(payload: payload);
    }
}