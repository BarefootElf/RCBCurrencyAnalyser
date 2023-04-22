using System.Net;
using System.Text;
using System.Xml;

namespace RCBCurrencyAnalyser.Helpers {
    public static class CbrAPIWorker {
        public static XmlDocument GetCurrencyCatalog(bool daily) {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var webRequest = WebRequest.Create("http://www.cbr.ru/scripts/XML_val.asp?d=" + (daily ? "0" : "1"));
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string xmlText = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1251)).ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlText);
            return xmlDoc;
        }

        public static XmlDocument GetCurrencyDaily(DateTime date) {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var webRequest = WebRequest.Create("http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date.Date.ToString("dd'/'MM'/'yyyy"));
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string xmlText = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1251)).ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlText);
            return xmlDoc;
        }
    }
}
