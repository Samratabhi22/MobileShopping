using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShopping.GenericUtilities
{
    public class JsonReader
    {
        public JsonReader() 
        {
        
        } 
        public string extractData(string tokenName)
        {
            string myJsonString=File.ReadAllText("TestScripts\\TestData\\testData.json");
            var jsonObject=JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
        public string[] extractDataArray(string tokenName)
        {
            string myJsonString = File.ReadAllText("TestScripts\\TestData\\testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<string>productList= jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productList.ToArray();
        }
    }
}
