using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Data;

public class CrmContext : DbContext
{
    public CrmContext(DbContextOptions<CrmContext> options) : base(options)
    {
    }
    public DbSet<Banco> Bancos { get; set; }
    public DbSet<Clausula_Abusiva> ClAbusivas { get; set; }
    public DbSet<Clausula> Clausulas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Estado_Civil> EstadosCivis { get; set; }
    public DbSet<Forum> Foruns { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Processo> Processos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>().ToTable("Tb_Bancos");
        modelBuilder.Entity<Banco>().HasKey(x => x.Id);
        modelBuilder.Entity<Banco>().Property(x => x.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Clausula_Abusiva>().ToTable("Tb_Clausulas_Abusivas");
        modelBuilder.Entity<Clausula_Abusiva>().HasKey(x => x.Id);
        modelBuilder.Entity<Clausula_Abusiva>().Property(x => x.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Clausula>().ToTable("Tb_Clausulas");
        modelBuilder.Entity<Clausula>().HasKey(x => x.Id);
        modelBuilder.Entity<Clausula>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Clausula>().HasData(new Clausula { Id = 1, Desc_Clausula = "Despachante" },
                                                new Clausula { Id = 2, Desc_Clausula = "Despesas com Terceiros" },
                                                new Clausula { Id = 3, Desc_Clausula = "Pac Parc Premiavel" },
                                                new Clausula { Id = 4, Desc_Clausula = "Registro de Contrato" },
                                                new Clausula { Id = 5, Desc_Clausula = "Seguro" },
                                                new Clausula { Id = 6, Desc_Clausula = "Seguro Mecânico" },
                                                new Clausula { Id = 7, Desc_Clausula = "Seguro Prestamista" },
                                                new Clausula { Id = 8, Desc_Clausula = "Tarifa de Avaliação" },
                                                new Clausula { Id = 9, Desc_Clausula = "Tarifa de Cadastro" },
                                                new Clausula { Id = 10, Desc_Clausula = "Tarifa de Registro" });

        modelBuilder.Entity<Clausula_Abusiva>().ToTable("Tb_Clausulas_Abusivas");
        modelBuilder.Entity<Clausula_Abusiva>().HasKey(x => x.Id);
        modelBuilder.Entity<Clausula_Abusiva>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Clausula_Abusiva>().HasOne(x => x.Contrato);
        modelBuilder.Entity<Clausula_Abusiva>().HasOne(x => x.Clausula);

        modelBuilder.Entity<Contrato>().ToTable("Tb_Contratos");
        modelBuilder.Entity<Contrato>().HasKey(x => x.Id);
        modelBuilder.Entity<Contrato>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Contrato>().HasOne(x => x.Pessoa);
        modelBuilder.Entity<Contrato>().HasOne(x => x.Banco);

        modelBuilder.Entity<Endereco>().ToTable("Tb_Enderecos");
        modelBuilder.Entity<Endereco>().HasKey(x => x.Cep);
        //modelBuilder.Entity<Endereco>().Property(x => x.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Estado_Civil>().ToTable("Tb_Estado_Civil");
        modelBuilder.Entity<Estado_Civil>().HasKey(x => x.Id);
        modelBuilder.Entity<Estado_Civil>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Estado_Civil>().HasData(new Estado_Civil { Id = 1, Estado = "Solteiro(a)" },
                                                    new Estado_Civil { Id = 2, Estado = "Casado(a)" },
                                                    new Estado_Civil { Id = 3, Estado = "Divorciado(a)" },
                                                    new Estado_Civil { Id = 4, Estado = "Viúvo(a)" },
                                                    new Estado_Civil { Id = 5, Estado = "União Estavel" });

        modelBuilder.Entity<Forum>().ToTable("Tb_Foruns");
        modelBuilder.Entity<Forum>().HasKey(x => x.Id);
        modelBuilder.Entity<Forum>().Property(x => x.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Pessoa>().ToTable("Tb_Pessoas");
        modelBuilder.Entity<Pessoa>().HasKey(x => x.Id);
        modelBuilder.Entity<Pessoa>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Pessoa>().HasOne(x => x.Estado_Civil);

        modelBuilder.Entity<Processo>().ToTable("Tb_Processos");
        modelBuilder.Entity<Processo>().HasKey(x => x.Id);
        modelBuilder.Entity<Processo>().Property(x => x.Id).ValueGeneratedOnAdd();
    }
}
