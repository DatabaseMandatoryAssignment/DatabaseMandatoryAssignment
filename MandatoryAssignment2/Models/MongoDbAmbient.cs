using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace MandatoryAssignment2.Models
{

    public class MongoDbAmbient
    {
        public ObjectId _id { get; set; }
        public DateTime DatoMaerke { get; set; }
        public string MaaleSted { get; set; }
        public string Opstilling { get; set; }
        public string Stof { get; set; }
        public int Resultat { get; set; }
        public string Enhed { get; set; }
        public string Udstyr { get; set; }
        public int Easting32 { get; set; }
        public int Northing32 { get; set; }
    }

}