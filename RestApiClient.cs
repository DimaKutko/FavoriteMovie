using System;
using System.IO;
using System.Net;
using System.Text;

class RestApiClient
{
    private static readonly String api = "http://www.omdbapi.com/?";
    private static readonly String apiKey = "apikey=fdb692c9";
    private static readonly String optionsTitile = "t=";
    private static readonly String optionsID = "i=";
    private static readonly String optionsYear = "y=";
    private static readonly String optionsSearch = "s=";
    private static readonly String optionsType = "type=movie";
    private static readonly String optionsDataType = "r=xml";

    private static readonly String error = "ERROR";

    private XmlClient xmlClient;

    public RestApiClient()
    {
        xmlClient = new XmlClient();
    }

    public String SerchAllMovie(String title, String year = null)
    {
        String url = api + apiKey + "&" + optionsType + "&" + optionsDataType + "&"+ optionsSearch + title;

        if (year != null)
        {
            url += "&" + optionsYear + year;
        }

        String response = GetRequest(url);

        if(response != error)
        {
            response = CheckResponse(response);
        }

        return response;
    }

    public String GetMovie(String id)
    {
        String url = api + apiKey + "&" + optionsDataType + "&" + optionsID + id;

        String response = GetRequest(url);

        if (response != error)
        {
            response = CheckResponse(response);
        }

        return response;
    }

    private String CheckResponse(String response)
    {
        if (xmlClient.CheckResponseXml(response))
        {
            return response;
        }
        else
        {
            return error;
        }
    }

    private String GetRequest(String url)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string data = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();
                //Console.WriteLine(data);

                response.Close();
                readStream.Close();
            }

            return data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return error;
        }
    }

}