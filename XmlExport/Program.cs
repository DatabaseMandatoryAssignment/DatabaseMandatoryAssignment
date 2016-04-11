using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MongoDB.Bson;
using MongoDB.Driver;

namespace XmlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("DatabaseMandatoryDatabase");
            var ambient = db.GetCollection<BsonDocument>("Ambient");

            XmlDocument document = new XmlDocument();
            // //OpstillingId[not(. = following::OpstillingId/.)]
            const string path = @"C:\Users\SanneWinther\Desktop\akademi\Data\";
            document.Load(path + "Ambient.xml");
            XmlNode root = document.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//Data");
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("--- Start! --- (" + stopwatch.Elapsed.ToString("g") + ")");
            stopwatch.Start();

            /*using (DataContextTable dataContext = new DataContextTable())
            {*/
            foreach (XmlNode item in nodes)
            {
                var bsonDocument = new BsonDocument
                        {
                            {"DatoMaerke", Convert.ToDateTime(item.SelectSingleNode("DatoMaerke").InnerText)},
                            {"MaaleSted", item.SelectSingleNode("Maalested").InnerText},
                            {"Opstilling", item.SelectSingleNode("OpstillingNavn").InnerText},
                            {"Stof", item.SelectSingleNode("StofNavn").InnerText},
                            {"Resultat", Convert.ToDouble(item.SelectSingleNode("Resultat")?.InnerText, System.Globalization.CultureInfo.InvariantCulture)},
                            {"Enhed", item.SelectSingleNode("EnhedNavn").InnerText},
                            {"Udstyr", item.SelectSingleNode("UdstyrNavn").InnerText},
                            {"Easting32", Convert.ToInt32(item.SelectSingleNode("Easting_32").InnerText)},
                            {"Northing32", Convert.ToInt32(item.SelectSingleNode("Northing_32").InnerText)},
                        };
                ambient.InsertOne(bsonDocument);

                /*dataContext.Ambient.Add(new Ambient()
                {
                    Northing32 = Convert.ToInt32(item.SelectSingleNode("Northing_32").InnerText)
                });
                dataContext.SaveChanges();*/
            }
            /*}*/
            stopwatch.Stop();
            Console.WriteLine("--- Done! --- (" + stopwatch.Elapsed.ToString("g") + ")");
            Console.Read();
        }
    }
}