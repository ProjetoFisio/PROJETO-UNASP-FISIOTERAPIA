namespace CamadaDeDados.Banco.TabelasSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("estado")]
    public partial class estado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estado()
        {
            clinicas = new HashSet<clinica>();
        }

        [Key]
        public int id_state { get; set; }

        [Required]
        [StringLength(50)]
        public string nome_state { get; set; }

        [Required]
        [StringLength(5)]
        public string sigla_state { get; set; }

        public int id_pais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clinica> clinicas { get; set; }

        public virtual pai pai { get; set; }
    }
}
