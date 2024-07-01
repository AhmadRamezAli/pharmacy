using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Infrastracture.Models;
using Pharmacy.Presentation.Models.User;

namespace Pharmacy.Infrastracture.DataContext;

public partial class PharmacyContext : IdentityDbContext<Pharmacy.Presentation.Models.User.User>
{


    public PharmacyContext(DbContextOptions<PharmacyContext> options)
        : base(options)
    {
    }

    protected PharmacyContext()
    {
    }
   // public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<CategoryDAO> Categories { get; set; } = null!;
    public virtual DbSet<CompanyDAO> Companies { get; set; } = null!;
    public virtual DbSet<DiseaseDAO> Diseases { get; set; } = null!;
    public virtual DbSet<DiseaseMedicineDAO> DiseaseMedicines { get; set; } = null!;
    public virtual DbSet<IngredientDAO> Ingredients { get; set; } = null!;
    public virtual DbSet<MedicienIngredientDAO> MedicienIngredients { get; set; } = null!;
    public virtual DbSet<MedicineDAO> Medicines { get; set; } = null!;
    public virtual DbSet<PatientDAO> Patients { get; set; } = null!;
    public virtual DbSet<PatientDiseaseDAO> PatientDiseases { get; set; } = null!;

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(x => x.Id).HasMaxLength(225);
        modelBuilder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(225);
        modelBuilder.Entity<IdentityUserLogin<string>>().Property(x => x.ProviderKey).HasMaxLength(225);


        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<CategoryDAO>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CompanyDAO>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DiseaseDAO>(entity =>
        {
            entity.ToTable("Disease");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DiseaseMedicineDAO>(entity =>
        {
            entity.ToTable("DiseaseMedicine");

            entity.HasIndex(e => new { e.Medicine, e.Disease }, "IX_PersonMedicine")
                .IsUnique();

            entity.HasOne(d => d.DiseaseNavigation)
                .WithMany(p => p.DiseaseMedicines)
                .HasForeignKey(d => d.Disease)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseaseMedicine_Disease");

            entity.HasOne(d => d.MedicineNavigation)
                .WithMany(p => p.DiseaseMedicines)
                .HasForeignKey(d => d.Medicine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseaseMedicine_Medicine");
        });

        modelBuilder.Entity<IngredientDAO>(entity =>
        {
            entity.ToTable("Ingredient");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MedicienIngredientDAO>(entity =>
        {
            entity.ToTable("MedicienIngredient");

            entity.Property(e => e.Ratio).HasColumnType("numeric(10, 7)");

            entity.HasOne(d => d.IngredientNavigation)
                .WithMany(p => p.MedicienIngredients)
                .HasForeignKey(d => d.Ingredient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicienIngredient_Ingredient");

            entity.HasOne(d => d.MedicineNavigation)
                .WithMany(p => p.MedicienIngredients)
                .HasForeignKey(d => d.Medicine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicienIngredient_Medicine");
        });

        modelBuilder.Entity<MedicineDAO>(entity =>
        {
            entity.ToTable("Medicine");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Dosage).HasColumnType("numeric(18, 5)");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ScientificName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoryNavigation)
                .WithMany(p => p.Medicines)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Category");

            entity.HasOne(d => d.CompanyNavigation)
                .WithMany(p => p.Medicines)
                .HasForeignKey(d => d.Company)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Company");
        });

        modelBuilder.Entity<PatientDAO>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<PatientDiseaseDAO>(entity =>
        {
            entity.ToTable("PatientDisease");

            entity.HasOne(d => d.DiseaseNavigation)
                .WithMany(p => p.PatientDiseases)
                .HasForeignKey(d => d.Disease)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDisease_Disease");

            entity.HasOne(d => d.PatientNavigation)
                .WithMany(p => p.PatientDiseases)
                .HasForeignKey(d => d.Patient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientDisease_Patient");
        });

        base.OnModelCreating(modelBuilder);
    }

}
