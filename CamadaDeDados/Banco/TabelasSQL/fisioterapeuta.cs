namespace CamadaDeDados.Banco.TabelasSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fisioterapeuta")]
    public partial class fisioterapeuta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fisioterapeuta()
        {
            artigo_dica = new HashSet<artigo_dica>();
            mensagems = new HashSet<mensagem>();
            videos = new HashSet<video>();
            clinicas = new HashSet<clinica>();
            pacientes = new HashSet<paciente>();
        }

        [Key]
        public int id_fis { get; set; }

        public byte[] img_fis { get; set; }

        [Required]
        [StringLength(30)]
        public string nome_fis { get; set; }

        [Required]
        [StringLength(30)]
        public string email_fis { get; set; }

        [Required]
        [StringLength(20)]
        public string senha_fis { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string dados_fis { get; set; }

        [StringLength(14)]
        public string cel_fis { get; set; }

        [Required]
        [StringLength(11)]
        public string cpf_fis { get; set; }

        [Required]
        [StringLength(9)]
        public string rg_fis { get; set; }

        [Column(TypeName = "date")]
        public DateTime nasc_fis { get; set; }

        public bool ativo_fis { get; set; }

        public bool adm_fis { get; set; }

        public bool sexo_fis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<artigo_dica> artigo_dica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mensagem> mensagems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<video> videos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clinica> clinicas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paciente> pacientes { get; set; }
    }
}
