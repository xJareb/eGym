﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eGym.Data;

#nullable disable

namespace eGym.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231206122609_Narudzbatest2")]
    partial class Narudzbatest2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eGym.Data.Models.Brend", b =>
                {
                    b.Property<int>("BrendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrendId"));

                    b.Property<string>("NazivBrenda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrendId");

                    b.ToTable("Brend");
                });

            modelBuilder.Entity("eGym.Data.Models.Clan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BrojClana")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("eGym.Data.Models.Clanarina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DatumIsteka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumUplate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Clanarina");
                });

            modelBuilder.Entity("eGym.Data.Models.Drzava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skracenica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("eGym.Data.Models.Grad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("eGym.Data.Models.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NazivKategorije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("eGym.Data.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isKorisnik")
                        .HasColumnType("bit");

                    b.Property<bool>("isRadnik")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("KorisnickiNalog");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("eGym.Data.Models.KreditnaKartica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojKartice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumIsteka")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("SigurnosniBroj")
                        .HasColumnType("int");

                    b.Property<string>("TipKartice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("KreditnaKartica");
                });

            modelBuilder.Entity("eGym.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("NacinPlacanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Popust")
                        .HasColumnType("float");

                    b.Property<double>("Vrijednost")
                        .HasColumnType("float");

                    b.Property<bool>("isOdobrena")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("eGym.Data.Models.Obavjesti", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.ToTable("Obavjesti");
                });

            modelBuilder.Entity("eGym.Data.Models.Proizvod", b =>
                {
                    b.Property<int>("ProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProizvodID"));

                    b.Property<string>("Boja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrendID")
                        .HasColumnType("int");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Izbrisan")
                        .HasColumnType("bit");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("KolicinaNaSkladistu")
                        .HasColumnType("int");

                    b.Property<int?>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Velicina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isIzdvojen")
                        .HasColumnType("bit");

                    b.Property<double?>("popust")
                        .HasColumnType("float");

                    b.HasKey("ProizvodID");

                    b.HasIndex("BrendID");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("eGym.Data.Models.Admin", b =>
                {
                    b.HasBaseType("eGym.Data.Models.KorisnickiNalog");

                    b.Property<string>("AdminKod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("eGym.Data.Models.Korisnik", b =>
                {
                    b.HasBaseType("eGym.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpstinaRodjenjaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isClan")
                        .HasColumnType("bit");

                    b.HasIndex("OpstinaRodjenjaID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("eGym.Data.Models.Radnik", b =>
                {
                    b.HasBaseType("eGym.Data.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RadnikID")
                        .HasColumnType("int");

                    b.Property<string>("Spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("GradID");

                    b.ToTable("Radnik");
                });

            modelBuilder.Entity("eGym.Data.Models.Grad", b =>
                {
                    b.HasOne("eGym.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("eGym.Data.Models.KreditnaKartica", b =>
                {
                    b.HasOne("eGym.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eGym.Data.Models.Obavjesti", b =>
                {
                    b.HasOne("eGym.Data.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("eGym.Data.Models.Proizvod", b =>
                {
                    b.HasOne("eGym.Data.Models.Brend", "brend")
                        .WithMany()
                        .HasForeignKey("BrendID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.Kategorija", "kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.Narudzba", null)
                        .WithMany("Proizvodi")
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("brend");

                    b.Navigation("kategorija");
                });

            modelBuilder.Entity("eGym.Data.Models.Admin", b =>
                {
                    b.HasOne("eGym.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("eGym.Data.Models.Admin", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eGym.Data.Models.Korisnik", b =>
                {
                    b.HasOne("eGym.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("eGym.Data.Models.Korisnik", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.Grad", "OpstinaRodjenja")
                        .WithMany()
                        .HasForeignKey("OpstinaRodjenjaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("OpstinaRodjenja");
                });

            modelBuilder.Entity("eGym.Data.Models.Radnik", b =>
                {
                    b.HasOne("eGym.Data.Models.Grad", "grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("eGym.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("eGym.Data.Models.Radnik", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grad");
                });

            modelBuilder.Entity("eGym.Data.Models.Narudzba", b =>
                {
                    b.Navigation("Proizvodi");
                });
#pragma warning restore 612, 618
        }
    }
}
