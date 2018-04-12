namespace CamadaDeDados.Banco.TabelasSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("clinica")]
    public partial class clinica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clinica()
        {
            fisioterapeutas = new HashSet<fisioterapeuta>();
        }

        [Key]
        public int id_cli { get; set; }

        [Required]
        [StringLength(50)]
        public string nome_cli { get; set; }

        [Required]
        [StringLength(50)]
        public string endereco_cli { get; set; }

        [Required]
        [StringLength(13)]
        public string tel_cli { get; set; }

        [Required]
        [StringLength(9)]
        public string cep_cli { get; set; }

        [Required]
        [StringLength(18)]
        public string cnpj_cli { get; set; }

        public bool ativo_cli { get; set; }

        public int id_state { get; set; }

        public virtual estado estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fisioterapeuta> fisioterapeutas { get; set; }
    }
}
