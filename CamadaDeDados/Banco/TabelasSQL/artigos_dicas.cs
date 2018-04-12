namespace CamadaDeDados.Banco
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class artigos_dicas
    {
        [Key]
        public int id_artDic { get; set; }

        [Required]
        [StringLength(50)]
        public string titulo_artDic { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string conteudo_artDic { get; set; }

        public bool ativo_artDic { get; set; }

        public int id_fis { get; set; }

        public DateTime data_artDic { get; set; }

        public int id_cat { get; set; }

        public virtual categorias_problemas categorias_problemas { get; set; }

        public virtual fisioterapeuta fisioterapeuta { get; set; }
    }
}
