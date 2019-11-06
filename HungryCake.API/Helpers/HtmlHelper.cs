using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HungryCake.API.Helpers
{
    public static class HtmlHelper
    {
        public async static Task<string> ReadHtml(string url)
        {
            string html = string.Empty;

            var request = (HttpWebRequest)WebRequest.Create(url);

            var response = await request.GetResponseAsync();
            var httpResponse = (HttpWebResponse)response;

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (httpResponse.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(httpResponse.CharacterSet));
                }

                html = await readStream.ReadToEndAsync();
                
                html = html.Replace("\t", string.Empty)
                           .Replace("\r\n", string.Empty)
                           .Replace("\n", string.Empty)
                           .Replace("\r", string.Empty);

                response.Close();
                httpResponse.Close();
                readStream.Close();
            }

            return html;
        }
    }
}