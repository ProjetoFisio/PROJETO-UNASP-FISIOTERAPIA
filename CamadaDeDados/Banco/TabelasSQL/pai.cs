namespace CamadaDeDados.Banco.TabelasSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pai()
        {
            estadoes = new HashSet<estado>();
        }

        [Key]
        public int id_pais { get; set; }

        [Required]
        [StringLength(50)]
        public string nome_pais { get; set; }

        [Required]
        [StringLength(5)]
        public string sigla_pais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<estado> estadoes { get; set; }
    }
}
