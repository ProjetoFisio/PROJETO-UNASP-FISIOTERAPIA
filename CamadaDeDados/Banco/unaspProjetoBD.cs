namespace CamadaDeDados.Banco
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class unaspProjetoBD : DbContext
    {
        public unaspProjetoBD()
            : base("name=unaspProjetoBD")
        {
        }

        public virtual DbSet<artigos_dicas> artigos_dicas { get; set; }
        public virtual DbSet<categorias_problemas> categorias_problemas { get; set; }
        public virtual DbSet<clinica> clinicas { get; set; }
        public virtual DbSet<estado> estadoes { get; set; }
        public virtual DbSet<fisioterapeuta> fisioterapeutas { get; set; }
        public virtual DbSet<mensagem> mensagems { get; set; }
        public virtual DbSet<paciente> pacientes { get; set; }
        public virtual DbSet<pais> pais { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<video> videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<artigos_dicas>()
                .Property(e => e.titulo_artDic)
                .IsUnicode(false);

            modelBuilder.Entity<artigos_dicas>()
                .Property(e => e.conteudo_artDic)
                .IsUnicode(false);

            modelBuilder.Entity<categorias_problemas>()
                .Property(e => e.nome_cat)
                .IsUnicode(false);

            modelBuilder.Entity<categorias_problemas>()
                .HasMany(e => e.artigos_dicas)
                .WithRequired(e => e.categorias_problemas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<clinica>()
                .Property(e => e.nome_cli)
                .IsUnicode(false);

            modelBuilder.Entity<clinica>()
                .Property(e => e.endereco_cli)
                .IsUnicode(false);

            modelBuilder.Entity<clinica>()
                .Property(e => e.tel_cli)
                .IsUnicode(false);

            modelBuilder.Entity<clinica>()
                .Property(e => e.cep_cli)
                .IsUnicode(false);

            modelBuilder.Entity<clinica>()
                .Property(e => e.cnpj_cli)
                .IsUnicode(false);

            modelBuilder.Entity<clinica>()
                .HasMany(e => e.fisioterapeutas)
                .WithMany(e => e.clinicas)
                .Map(m => m.ToTable("cli_fis").MapLeftKey("id_cli").MapRightKey("id_fis"));

            modelBuilder.Entity<estado>()
                .Property(e => e.nome_state)
                .IsUnicode(false);

            modelBuilder.Entity<estado>()
                .Property(e => e.sigla_state)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<estado>()
                .HasMany(e => e.clinicas)
                .WithRequired(e => e.estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<fisioterapeuta>()
                .Property(e => e.nome_fis)
                .IsUnicode(false);

            modelBuilder.Entity<fisioterapeuta>()
                .Property(e => e.email_fis)
                .IsUnicode(false);

            modelBuilder.Entity<fisioterapeuta>()
                .Property(e => e.senha_fis)
                .IsUnicode(false);

            modelBuilder.Entity<fisioterapeuta>()
                .Property(e => e.dados_fis)
                .IsUnicode(false);

            modelBuilder.Entity<fisioterapeuta>()
                .Property(e => e.cel_fis)
                .IsUnicode(false);

            modelBuilder.Entity<fisioterapeuta>()
                .Property(e => e.cpf_fis)
                .IsUnicode(false);

            modelBuilder.Entity<fisioterapeuta>()
                .Property(e => e.rg_fis)
                .IsUnicode(false);

            modelBuilder.Entity<fisioterapeuta>()
                .HasMany(e => e.artigos_dicas)
                .WithRequired(e => e.fisioterapeuta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<fisioterapeuta>()
                .HasMany(e => e.mensagems)
                .WithRequired(e => e.fisioterapeuta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<fisioterapeuta>()
                .HasMany(e => e.pacientes)
                .WithMany(e => e.fisioterapeutas)
                .Map(m => m.ToTable("fis_pac").MapLeftKey("id_fis").MapRightKey("id_pac"));

            modelBuilder.Entity<mensagem>()
                .Property(e => e.titulo_mensagem)
                .IsUnicode(false);

            modelBuilder.Entity<mensagem>()
                .Property(e => e.conteudo_mensagem)
                .IsUnicode(false);

            modelBuilder.Entity<mensagem>()
                .HasMany(e => e.pacientes)
                .WithMany(e => e.mensagems)
                .Map(m => m.ToTable("mens_pac").MapLeftKey("id_mensagem").MapRightKey("id_pac"));

            modelBuilder.Entity<paciente>()
                .Property(e => e.nome_pac)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.email_pac)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.senha_pac)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.dados_pac)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.tel_pac)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.cel_pac)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.cpf_pac)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.endereco_pac)
                .IsUnicode(false);

            modelBuilder.Entity<paciente>()
                .Property(e => e.rg_pac)
                .IsUnicode(false);

            modelBuilder.Entity<pais>()
                .Property(e => e.nome_pais)
                .IsUnicode(false);

            modelBuilder.Entity<pais>()
                .Property(e => e.sigla_pais)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<pais>()
                .HasMany(e => e.estadoes)
                .WithRequired(e => e.pai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<video>()
                .Property(e => e.titulo_video)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.descricao_video)
                .IsUnicode(false);
        }
    }
}
