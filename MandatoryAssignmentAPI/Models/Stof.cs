namespace MandatoryAssignmentAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stof")]
    public partial class Stof
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stof()
        {
            Ambient = new HashSet<Ambient>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StofId { get; set; }

        [Required]
        [StringLength(100)]
        public string StofNavn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ambient> Ambient { get; set; }
    }
}
