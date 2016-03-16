namespace XmlExport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Maalested")]
    public partial class Maalested
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maalested()
        {
            Ambient = new HashSet<Ambient>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaalestedId { get; set; }

        [Column("Maalested")]
        [Required]
        [StringLength(100)]
        public string Maalested1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ambient> Ambient { get; set; }
    }
}
