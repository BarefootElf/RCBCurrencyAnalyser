using RCBCurrencyAnalyser.ORM;
using System.Xml;

namespace RCBCurrencyAnalyser.Domains {
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
    }
}