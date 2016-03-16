using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlExport.Models;

namespace XmlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            // //OpstillingId[not(. = following::OpstillingId/.)]
            const string Path = @"C:\Users\SanneWinther\Desktop\datamatiker4.semester\database\MandatoryAssignment\XmlExport\";
            document.Load(Path + "Ambient.xml");
            XmlNode root = document.DocumentElement;

            XmlNodeList nodes = root.SelectNodes("//Data");
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("--- Start! ---");
            stopwatch.Start();
            foreach (XmlNode item in nodes)
            {
                using (DataContext dataContext = new DataContext())
                {
                    dataContext.Ambient.Add(new Ambient()
                    {
                        DatoMaerke = Convert.ToDateTime(item.SelectSingleNode("DatoMaerke").InnerText),
                        MaaleStedId = Convert.ToInt32(item.SelectSingleNode("MaaleStedId").InnerText),
                        OpstillingId = Convert.ToInt32(item.SelectSingleNode("OpstillingId").InnerText),
                        StofId = Convert.ToInt32(item.SelectSingleNode("StofId").InnerText),
                        Resultat = Convert.ToDouble(item.SelectSingleNode("Resultat")?.InnerText.Replace(".", ",")),
                        EnhedId = Convert.ToInt32(item.SelectSingleNode("EnhedId").InnerText),
                        UdstyrId = Convert.ToInt32(item.SelectSingleNode("UdstyrId").InnerText),
                        Easting32 = Convert.ToInt32(item.SelectSingleNode("Easting_32").InnerText),
                        Northing32 = Convert.ToInt32(item.SelectSingleNode("Northing_32").InnerText)
                    });
                    dataContext.SaveChanges();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("--- Done! --- (" + stopwatch.Elapsed.ToString("g") + ")");
            Console.Read();
        }
    }
}
