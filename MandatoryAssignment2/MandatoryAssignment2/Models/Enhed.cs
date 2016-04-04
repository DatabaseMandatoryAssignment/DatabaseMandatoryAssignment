namespace MandatoryAssignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enhed")]
    public partial class Enhed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enhed()
        {
            Ambient = new HashSet<Ambient>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EnhedId { get; set; }

        [Required]
        [StringLength(100)]
        public string EnhedNavn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ambient> Ambient { get; set; }
    }
}
