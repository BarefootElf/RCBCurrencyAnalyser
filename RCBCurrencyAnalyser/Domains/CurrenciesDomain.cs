using RCBCurrencyAnalyser.ORM;
using System.Globalization;
using System.Xml;

namespace RCBCurrencyAnalyser.Domains
{
    public static class CurrenciesDomain {
        private static readonly CurrenciesContext dbContext = new();

        public static void UpdateCurrencies(XmlDocument xmlDocument) {
            var currencyNodes = xmlDocument.ChildNodes[1].ChildNodes;
            for (int i = 0; i < currencyNodes.Count; i++) {
                var currency = new Currency {
                    Id = currencyNodes[i].Attributes[0].Value,
                    Name = currencyNodes[i].ChildNodes[0].InnerText,
                    EngName = currencyNodes[i].ChildNodes[1].InnerText,
                    Nominal = Convert.ToInt32(currencyNodes[i].ChildNodes[2].InnerText),
                    ParentCode = currencyNodes[i].ChildNodes[3].InnerText
                };

                if (!dbContext.Currencies.Any(c => c.Id == currency.Id && c.Name == currency.Name)) {
                    dbContext.Currencies.Add(currency);
                    dbContext.SaveChanges();
                }       
            }
        }

        public static void UpdateCurrenciesData(XmlDocument xmlDocument) {
            var date = DateTime.ParseExact(xmlDocument.ChildNodes[1].Attributes[0].Value, "dd.MM.yyyy", new CultureInfo("ru-RU"), DateTimeStyles.None);
            var currencyDataNodes = xmlDocument.ChildNodes[1].ChildNodes;
            for (int i = 0; i < currencyDataNodes.Count; i++) {
                var maxId = dbContext.CurrencyData.Max(cd => cd.Id);
                var currencyData = new CurrencyDatum {
                    Date = new DateOnly(date.Year, date.Month, date.Day),
                    CurrencyId = currencyDataNodes[i].Attributes[0].Value,
                    NumCode = Convert.ToInt32(currencyDataNodes[i].ChildNodes[0].InnerText),
                    CharCode = currencyDataNodes[i].ChildNodes[1].InnerText,
                    Nominal = Convert.ToInt32(currencyDataNodes[i].ChildNodes[2].InnerText),
                    Name = currencyDataNodes[i].ChildNodes[3].InnerText,
                    Value = (float)Convert.ToDouble(currencyDataNodes[i].ChildNodes[4].InnerText),
                    Id = maxId + 1
                };

                if (!dbContext.CurrencyData.Any(cd => cd.Date == currencyData.Date && cd.CurrencyId == currencyData.CurrencyId)) {
                    dbContext.CurrencyData.Add(currencyData);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}