namespace XmlExport
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Udstyr")]
    public partial class Udstyr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Udstyr()
        {
            Ambient = new HashSet<Ambient>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UdstyrId { get; set; }

        [Required]
        [StringLength(100)]
        public string UdstyrNavn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ambient> Ambient { get; set; }
    }
}
