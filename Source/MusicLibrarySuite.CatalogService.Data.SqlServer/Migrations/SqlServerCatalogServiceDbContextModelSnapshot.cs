// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicLibrarySuite.CatalogService.Data.SqlServer.Contexts;

#nullable disable

namespace MusicLibrarySuite.CatalogService.Data.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerCatalogServiceDbContext))]
    partial class SqlServerCatalogServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("DisambiguationText")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("SystemEntity")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Artist", "dbo");

                    b.HasCheckConstraint("CK_Artist_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_Artist_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");

                    b.HasCheckConstraint("CK_Artist_Name", "LEN(TRIM([Name])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ArtistGenreDto", b =>
                {
                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "GenreId");

                    b.HasIndex("ArtistId")
                        .HasDatabaseName("IX_ArtistGenre_ArtistId");

                    b.HasIndex("GenreId")
                        .HasDatabaseName("IX_ArtistGenre_GenreId");

                    b.HasIndex("ArtistId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_ArtistGenre_ArtistId_Order");

                    b.ToTable("ArtistGenre", "dbo");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ArtistRelationshipDto", b =>
                {
                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DependentArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "DependentArtistId");

                    b.HasIndex("ArtistId")
                        .HasDatabaseName("IX_ArtistRelationship_ArtistId");

                    b.HasIndex("DependentArtistId")
                        .HasDatabaseName("IX_ArtistRelationship_DependentArtistId");

                    b.HasIndex("ArtistId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_ArtistRelationship_ArtistId_Order");

                    b.ToTable("ArtistRelationship", "dbo");

                    b.HasCheckConstraint("CK_ArtistRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_ArtistRelationship_Name", "LEN(TRIM([Name])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.GenreDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("SystemEntity")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Genre", "dbo");

                    b.HasCheckConstraint("CK_Genre_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_Genre_Name", "LEN(TRIM([Name])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.GenreRelationshipDto", b =>
                {
                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DependentGenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "DependentGenreId");

                    b.HasIndex("DependentGenreId")
                        .HasDatabaseName("IX_GenreRelationship_DependentGenreId");

                    b.HasIndex("GenreId")
                        .HasDatabaseName("IX_GenreRelationship_GenreId");

                    b.HasIndex("GenreId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_GenreRelationship_GenreId_Order");

                    b.ToTable("GenreRelationship", "dbo");

                    b.HasCheckConstraint("CK_GenreRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_GenreRelationship_Name", "LEN(TRIM([Name])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ProductDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("DisambiguationText")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReleasedOn")
                        .HasColumnType("date");

                    b.Property<bool>("ReleasedOnYearOnly")
                        .HasColumnType("bit");

                    b.Property<bool>("SystemEntity")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Product", "dbo");

                    b.HasCheckConstraint("CK_Product_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_Product_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");

                    b.HasCheckConstraint("CK_Product_Title", "LEN(TRIM([Title])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ProductRelationshipDto", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DependentProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "DependentProductId");

                    b.HasIndex("DependentProductId")
                        .HasDatabaseName("IX_ProductRelationship_DependentProductId");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("IX_ProductRelationship_ProductId");

                    b.HasIndex("ProductId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_ProductRelationship_ProductId_Order");

                    b.ToTable("ProductRelationship", "dbo");

                    b.HasCheckConstraint("CK_ProductRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_ProductRelationship_Name", "LEN(TRIM([Name])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ReleaseGroupDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("DisambiguationText")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("ReleaseGroup", "dbo");

                    b.HasCheckConstraint("CK_ReleaseGroup_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_ReleaseGroup_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");

                    b.HasCheckConstraint("CK_ReleaseGroup_Title", "LEN(TRIM([Title])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ReleaseGroupRelationshipDto", b =>
                {
                    b.Property<Guid>("ReleaseGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DependentReleaseGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("ReleaseGroupId", "DependentReleaseGroupId");

                    b.HasIndex("DependentReleaseGroupId")
                        .HasDatabaseName("IX_ReleaseGroupRelationship_DependentReleaseGroupId");

                    b.HasIndex("ReleaseGroupId")
                        .HasDatabaseName("IX_ReleaseGroupRelationship_ReleaseGroupId");

                    b.HasIndex("ReleaseGroupId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_ReleaseGroupRelationship_ReleaseGroupId_Order");

                    b.ToTable("ReleaseGroupRelationship", "dbo");

                    b.HasCheckConstraint("CK_ReleaseGroupRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_ReleaseGroupRelationship_Name", "LEN(TRIM([Name])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkArtistDto", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "ArtistId");

                    b.HasIndex("ArtistId")
                        .HasDatabaseName("IX_WorkArtist_ArtistId");

                    b.HasIndex("WorkId")
                        .HasDatabaseName("IX_WorkArtist_WorkId");

                    b.HasIndex("WorkId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_WorkArtist_WorkId_Order");

                    b.ToTable("WorkArtist", "dbo");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkComposerDto", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "ArtistId");

                    b.HasIndex("ArtistId")
                        .HasDatabaseName("IX_WorkComposer_ArtistId");

                    b.HasIndex("WorkId")
                        .HasDatabaseName("IX_WorkComposer_WorkId");

                    b.HasIndex("WorkId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_WorkComposer_WorkId_Order");

                    b.ToTable("WorkComposer", "dbo");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("DisambiguationText")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("InternationalStandardMusicalWorkCode")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("ReleasedOn")
                        .HasColumnType("date");

                    b.Property<bool>("ReleasedOnYearOnly")
                        .HasColumnType("bit");

                    b.Property<bool>("SystemEntity")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("InternationalStandardMusicalWorkCode")
                        .HasDatabaseName("IX_Work_InternationalStandardMusicalWorkCode");

                    b.ToTable("Work", "dbo");

                    b.HasCheckConstraint("CK_Work_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_Work_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");

                    b.HasCheckConstraint("CK_Work_InternationalStandardMusicalWorkCode", "[InternationalStandardMusicalWorkCode] IS NULL OR LEN(TRIM([InternationalStandardMusicalWorkCode])) > 0");

                    b.HasCheckConstraint("CK_Work_Title", "LEN(TRIM([Title])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkFeaturedArtistDto", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "ArtistId");

                    b.HasIndex("ArtistId")
                        .HasDatabaseName("IX_WorkFeaturedArtist_ArtistId");

                    b.HasIndex("WorkId")
                        .HasDatabaseName("IX_WorkFeaturedArtist_WorkId");

                    b.HasIndex("WorkId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_WorkFeaturedArtist_WorkId_Order");

                    b.ToTable("WorkFeaturedArtist", "dbo");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkGenreDto", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "GenreId");

                    b.HasIndex("GenreId")
                        .HasDatabaseName("IX_WorkGenre_GenreId");

                    b.HasIndex("WorkId")
                        .HasDatabaseName("IX_WorkGenre_WorkId");

                    b.HasIndex("WorkId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_WorkGenre_WorkId_Order");

                    b.ToTable("WorkGenre", "dbo");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkPerformerDto", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "ArtistId");

                    b.HasIndex("ArtistId")
                        .HasDatabaseName("IX_WorkPerformer_ArtistId");

                    b.HasIndex("WorkId")
                        .HasDatabaseName("IX_WorkPerformer_WorkId");

                    b.HasIndex("WorkId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_WorkPerformer_WorkId_Order");

                    b.ToTable("WorkPerformer", "dbo");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkRelationshipDto", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DependentWorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "DependentWorkId");

                    b.HasIndex("DependentWorkId")
                        .HasDatabaseName("IX_WorkRelationship_DependentWorkId");

                    b.HasIndex("WorkId")
                        .HasDatabaseName("IX_WorkRelationship_WorkId");

                    b.HasIndex("WorkId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_WorkRelationship_WorkId_Order");

                    b.ToTable("WorkRelationship", "dbo");

                    b.HasCheckConstraint("CK_WorkRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_WorkRelationship_Name", "LEN(TRIM([Name])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkToProductRelationshipDto", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceOrder")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "ProductId");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("IX_WorkToProductRelationship_ProductId");

                    b.HasIndex("WorkId")
                        .HasDatabaseName("IX_WorkToProductRelationship_WorkId");

                    b.HasIndex("ProductId", "ReferenceOrder")
                        .IsUnique()
                        .HasDatabaseName("UIX_WorkToProductRelationship_ProductId_ReferenceOrder");

                    b.HasIndex("WorkId", "Order")
                        .IsUnique()
                        .HasDatabaseName("UIX_WorkToProductRelationship_WorkId_Order");

                    b.ToTable("WorkToProductRelationship", "dbo");

                    b.HasCheckConstraint("CK_WorkToProductRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

                    b.HasCheckConstraint("CK_WorkToProductRelationship_Name", "LEN(TRIM([Name])) > 0");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ArtistGenreDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", "Artist")
                        .WithMany("ArtistGenres")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.GenreDto", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ArtistRelationshipDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", "Artist")
                        .WithMany("ArtistRelationships")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", "DependentArtist")
                        .WithMany()
                        .HasForeignKey("DependentArtistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("DependentArtist");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.GenreRelationshipDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.GenreDto", "DependentGenre")
                        .WithMany()
                        .HasForeignKey("DependentGenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.GenreDto", "Genre")
                        .WithMany("GenreRelationships")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DependentGenre");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ProductRelationshipDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ProductDto", "DependentProduct")
                        .WithMany()
                        .HasForeignKey("DependentProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ProductDto", "Product")
                        .WithMany("ProductRelationships")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DependentProduct");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ReleaseGroupRelationshipDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ReleaseGroupDto", "DependentReleaseGroup")
                        .WithMany()
                        .HasForeignKey("DependentReleaseGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ReleaseGroupDto", "ReleaseGroup")
                        .WithMany("ReleaseGroupRelationships")
                        .HasForeignKey("ReleaseGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DependentReleaseGroup");

                    b.Navigation("ReleaseGroup");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkArtistDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", "Work")
                        .WithMany("WorkArtists")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkComposerDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", "Work")
                        .WithMany("WorkComposers")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkFeaturedArtistDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", "Work")
                        .WithMany("WorkFeaturedArtists")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkGenreDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.GenreDto", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", "Work")
                        .WithMany("WorkGenres")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkPerformerDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", "Work")
                        .WithMany("WorkPerformers")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkRelationshipDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", "DependentWork")
                        .WithMany()
                        .HasForeignKey("DependentWorkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", "Work")
                        .WithMany("WorkRelationships")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DependentWork");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkToProductRelationshipDto", b =>
                {
                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.ProductDto", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", "Work")
                        .WithMany("WorkToProductRelationships")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ArtistDto", b =>
                {
                    b.Navigation("ArtistGenres");

                    b.Navigation("ArtistRelationships");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.GenreDto", b =>
                {
                    b.Navigation("GenreRelationships");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ProductDto", b =>
                {
                    b.Navigation("ProductRelationships");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.ReleaseGroupDto", b =>
                {
                    b.Navigation("ReleaseGroupRelationships");
                });

            modelBuilder.Entity("MusicLibrarySuite.CatalogService.Data.Entities.WorkDto", b =>
                {
                    b.Navigation("WorkArtists");

                    b.Navigation("WorkComposers");

                    b.Navigation("WorkFeaturedArtists");

                    b.Navigation("WorkGenres");

                    b.Navigation("WorkPerformers");

                    b.Navigation("WorkRelationships");

                    b.Navigation("WorkToProductRelationships");
                });
#pragma warning restore 612, 618
        }
    }
}
