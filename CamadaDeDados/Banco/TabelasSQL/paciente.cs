namespace CamadaDeDados.Banco.TabelasSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("paciente")]
    public partial class paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public paciente()
        {
            fisioterapeutas = new HashSet<fisioterapeuta>();
        }

        [Key]
        public int id_pac { get; set; }

        public byte[] img_pac { get; set; }

        [Required]
        [StringLength(30)]
        public string nome_pac { get; set; }

        [Required]
        [StringLength(30)]
        public string email_pac { get; set; }

        [Required]
        [StringLength(20)]
        public string senha_pac { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string dados_pac { get; set; }

        [Required]
        [StringLength(14)]
        public string tel_pac { get; set; }

        [StringLength(14)]
        public string cel_pac { get; set; }

        [Required]
        [StringLength(11)]
        public string cpf_pac { get; set; }

        [Required]
        [StringLength(30)]
        public string endereco_pac { get; set; }

        [Required]
        [StringLength(9)]
        public string rg_pac { get; set; }

        [Column(TypeName = "date")]
        public DateTime nasc_pac { get; set; }

        public bool ativo_pac { get; set; }

        [Required]
        [StringLength(9)]
        public string cep_pac { get; set; }

        public bool sexo_pac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fisioterapeuta> fisioterapeutas { get; set; }
    }
}
