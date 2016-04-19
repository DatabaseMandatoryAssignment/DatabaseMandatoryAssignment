namespace MandatoryAssignmentAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AmbientView")]
    public partial class AmbientView
    {
        [Key]
        [Column(Order = 0)]
        public DateTime DatoMaerke { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Easting32 { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Northing32 { get; set; }

        public double? Resultat { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EnhedId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string EnhedNavn { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaalestedId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string Maalested { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OpstillingId { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(100)]
        public string OpstillingNavn { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StofId { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(100)]
        public string StofNavn { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UdstyrId { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(100)]
        public string UdstyrNavn { get; set; }
    }
}
