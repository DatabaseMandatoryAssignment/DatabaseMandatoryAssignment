namespace MandatoryAssignmentAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ambient")]
    public partial class Ambient
    {
        public int AmbientId { get; set; }

        public int MaaleStedId { get; set; }

        public DateTime DatoMaerke { get; set; }

        public int OpstillingId { get; set; }

        public int StofId { get; set; }

        public double? Resultat { get; set; }

        public int EnhedId { get; set; }

        public int UdstyrId { get; set; }

        public int Easting32 { get; set; }

        public int Northing32 { get; set; }

        public virtual Enhed Enhed { get; set; }

        public virtual Maalested Maalested { get; set; }

        public virtual Opstilling Opstilling { get; set; }

        public virtual Stof Stof { get; set; }

        public virtual Udstyr Udstyr { get; set; }
    }
}
