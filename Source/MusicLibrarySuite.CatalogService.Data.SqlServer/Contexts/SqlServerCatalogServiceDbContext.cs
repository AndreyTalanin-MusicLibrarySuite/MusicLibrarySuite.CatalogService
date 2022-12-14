using Microsoft.EntityFrameworkCore;

using MusicLibrarySuite.CatalogService.Data.Contexts;
using MusicLibrarySuite.CatalogService.Data.Entities;

namespace MusicLibrarySuite.CatalogService.Data.SqlServer.Contexts;

/// <summary>
/// Represents a SQL Server - specific implementation of the catalog service database context.
/// </summary>
public class SqlServerCatalogServiceDbContext : CatalogServiceDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SqlServerCatalogServiceDbContext" /> type.
    /// </summary>
    public SqlServerCatalogServiceDbContext()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SqlServerCatalogServiceDbContext" /> type using the specified database context options.
    /// </summary>
    /// <param name="contextOptions">The database context options.</param>
    public SqlServerCatalogServiceDbContext(DbContextOptions contextOptions)
        : base(contextOptions)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArtistDto>().ToTable("Artist", "dbo");
        modelBuilder.Entity<ArtistDto>().HasKey(entity => entity.Id);
        modelBuilder.Entity<ArtistDto>().HasCheckConstraint("CK_Artist_Name", "LEN(TRIM([Name])) > 0");
        modelBuilder.Entity<ArtistDto>().HasCheckConstraint("CK_Artist_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");
        modelBuilder.Entity<ArtistDto>().HasCheckConstraint("CK_Artist_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");

        modelBuilder.Entity<ArtistRelationshipDto>().ToTable("ArtistRelationship", "dbo");
        modelBuilder.Entity<ArtistRelationshipDto>().HasKey(entity => new { entity.ArtistId, entity.DependentArtistId });
        modelBuilder.Entity<ArtistRelationshipDto>()
            .HasOne<ArtistDto>(entity => entity.Artist)
            .WithMany(entity => entity.ArtistRelationships)
            .HasForeignKey(entity => entity.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ArtistRelationshipDto>()
            .HasOne<ArtistDto>(entity => entity.DependentArtist)
            .WithMany()
            .HasForeignKey(entity => entity.DependentArtistId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<ArtistRelationshipDto>()
            .HasIndex(entity => entity.ArtistId)
            .HasDatabaseName("IX_ArtistRelationship_ArtistId");
        modelBuilder.Entity<ArtistRelationshipDto>()
            .HasIndex(entity => entity.DependentArtistId)
            .HasDatabaseName("IX_ArtistRelationship_DependentArtistId");
        modelBuilder.Entity<ArtistRelationshipDto>()
            .HasIndex(entity => new { entity.ArtistId, entity.Order })
            .HasDatabaseName("UIX_ArtistRelationship_ArtistId_Order")
            .IsUnique();
        modelBuilder.Entity<ArtistRelationshipDto>().HasCheckConstraint("CK_ArtistRelationship_Name", "LEN(TRIM([Name])) > 0");
        modelBuilder.Entity<ArtistRelationshipDto>().HasCheckConstraint("CK_ArtistRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

        modelBuilder.Entity<ArtistGenreDto>().ToTable("ArtistGenre", "dbo");
        modelBuilder.Entity<ArtistGenreDto>().HasKey(entity => new { entity.ArtistId, entity.GenreId });
        modelBuilder.Entity<ArtistGenreDto>()
            .HasOne(entity => entity.Artist)
            .WithMany(entity => entity.ArtistGenres)
            .HasForeignKey(entity => entity.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ArtistGenreDto>()
            .HasOne(entity => entity.Genre)
            .WithMany()
            .HasForeignKey(entity => entity.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ArtistGenreDto>()
            .HasIndex(entity => entity.ArtistId)
            .HasDatabaseName("IX_ArtistGenre_ArtistId");
        modelBuilder.Entity<ArtistGenreDto>()
            .HasIndex(entity => entity.GenreId)
            .HasDatabaseName("IX_ArtistGenre_GenreId");
        modelBuilder.Entity<ArtistGenreDto>()
            .HasIndex(entity => new { entity.ArtistId, entity.Order })
            .HasDatabaseName("UIX_ArtistGenre_ArtistId_Order")
            .IsUnique();

        modelBuilder.Entity<ReleaseDto>().ToTable("Release", "dbo");
        modelBuilder.Entity<ReleaseDto>().HasKey(entity => entity.Id);
        modelBuilder.Entity<ReleaseDto>()
            .HasIndex(entity => entity.Barcode)
            .HasDatabaseName("IX_Release_Barcode");
        modelBuilder.Entity<ReleaseDto>()
            .HasIndex(entity => entity.CatalogNumber)
            .HasDatabaseName("IX_Release_CatalogNumber");
        modelBuilder.Entity<ReleaseDto>().HasCheckConstraint("CK_Release_Title", "LEN(TRIM([Title])) > 0");
        modelBuilder.Entity<ReleaseDto>().HasCheckConstraint("CK_Release_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");
        modelBuilder.Entity<ReleaseDto>().HasCheckConstraint("CK_Release_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");
        modelBuilder.Entity<ReleaseDto>().HasCheckConstraint("CK_Release_Barcode", "[Barcode] IS NULL OR LEN(TRIM([Barcode])) > 0");
        modelBuilder.Entity<ReleaseDto>().HasCheckConstraint("CK_Release_CatalogNumber", "[CatalogNumber] IS NULL OR LEN(TRIM([CatalogNumber])) > 0");
        modelBuilder.Entity<ReleaseDto>().HasCheckConstraint("CK_Release_MediaFormat", "[MediaFormat] IS NULL OR LEN(TRIM([MediaFormat])) > 0");
        modelBuilder.Entity<ReleaseDto>().HasCheckConstraint("CK_Release_PublishFormat", "[PublishFormat] IS NULL OR LEN(TRIM([PublishFormat])) > 0");
        modelBuilder.Entity<ReleaseDto>()
            .Property(entity => entity.ReleasedOn)
            .HasColumnType("date");

        modelBuilder.Entity<ReleaseGroupDto>().ToTable("ReleaseGroup", "dbo");
        modelBuilder.Entity<ReleaseGroupDto>().HasKey(entity => entity.Id);
        modelBuilder.Entity<ReleaseGroupDto>().HasCheckConstraint("CK_ReleaseGroup_Title", "LEN(TRIM([Title])) > 0");
        modelBuilder.Entity<ReleaseGroupDto>().HasCheckConstraint("CK_ReleaseGroup_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");
        modelBuilder.Entity<ReleaseGroupDto>().HasCheckConstraint("CK_ReleaseGroup_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");

        modelBuilder.Entity<ReleaseGroupRelationshipDto>().ToTable("ReleaseGroupRelationship", "dbo");
        modelBuilder.Entity<ReleaseGroupRelationshipDto>().HasKey(entity => new { entity.ReleaseGroupId, entity.DependentReleaseGroupId });
        modelBuilder.Entity<ReleaseGroupRelationshipDto>()
            .HasOne(entity => entity.ReleaseGroup)
            .WithMany(entity => entity.ReleaseGroupRelationships)
            .HasForeignKey(entity => entity.ReleaseGroupId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ReleaseGroupRelationshipDto>()
            .HasOne(entity => entity.DependentReleaseGroup)
            .WithMany()
            .HasForeignKey(entity => entity.DependentReleaseGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<ReleaseGroupRelationshipDto>()
            .HasIndex(entity => entity.ReleaseGroupId)
            .HasDatabaseName("IX_ReleaseGroupRelationship_ReleaseGroupId");
        modelBuilder.Entity<ReleaseGroupRelationshipDto>()
            .HasIndex(entity => entity.DependentReleaseGroupId)
            .HasDatabaseName("IX_ReleaseGroupRelationship_DependentReleaseGroupId");
        modelBuilder.Entity<ReleaseGroupRelationshipDto>()
            .HasIndex(entity => new { entity.ReleaseGroupId, entity.Order })
            .HasDatabaseName("UIX_ReleaseGroupRelationship_ReleaseGroupId_Order")
            .IsUnique();
        modelBuilder.Entity<ReleaseGroupRelationshipDto>().HasCheckConstraint("CK_ReleaseGroupRelationship_Name", "LEN(TRIM([Name])) > 0");
        modelBuilder.Entity<ReleaseGroupRelationshipDto>().HasCheckConstraint("CK_ReleaseGroupRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

        modelBuilder.Entity<GenreDto>().ToTable("Genre", "dbo");
        modelBuilder.Entity<GenreDto>().HasKey(entity => entity.Id);
        modelBuilder.Entity<GenreDto>().HasCheckConstraint("CK_Genre_Name", "LEN(TRIM([Name])) > 0");
        modelBuilder.Entity<GenreDto>().HasCheckConstraint("CK_Genre_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

        modelBuilder.Entity<GenreRelationshipDto>().ToTable("GenreRelationship", "dbo");
        modelBuilder.Entity<GenreRelationshipDto>().HasKey(entity => new { entity.GenreId, entity.DependentGenreId });
        modelBuilder.Entity<GenreRelationshipDto>()
            .HasOne(entity => entity.Genre)
            .WithMany(entity => entity.GenreRelationships)
            .HasForeignKey(entity => entity.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<GenreRelationshipDto>()
            .HasOne(entity => entity.DependentGenre)
            .WithMany()
            .HasForeignKey(entity => entity.DependentGenreId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<GenreRelationshipDto>()
            .HasIndex(entity => entity.GenreId)
            .HasDatabaseName("IX_GenreRelationship_GenreId");
        modelBuilder.Entity<GenreRelationshipDto>()
            .HasIndex(entity => entity.DependentGenreId)
            .HasDatabaseName("IX_GenreRelationship_DependentGenreId");
        modelBuilder.Entity<GenreRelationshipDto>()
            .HasIndex(entity => new { entity.GenreId, entity.Order })
            .HasDatabaseName("UIX_GenreRelationship_GenreId_Order")
            .IsUnique();
        modelBuilder.Entity<GenreRelationshipDto>().HasCheckConstraint("CK_GenreRelationship_Name", "LEN(TRIM([Name])) > 0");
        modelBuilder.Entity<GenreRelationshipDto>().HasCheckConstraint("CK_GenreRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

        modelBuilder.Entity<ProductDto>().ToTable("Product", "dbo");
        modelBuilder.Entity<ProductDto>().HasKey(entity => entity.Id);
        modelBuilder.Entity<ProductDto>().HasCheckConstraint("CK_Product_Title", "LEN(TRIM([Title])) > 0");
        modelBuilder.Entity<ProductDto>().HasCheckConstraint("CK_Product_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");
        modelBuilder.Entity<ProductDto>().HasCheckConstraint("CK_Product_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");
        modelBuilder.Entity<ProductDto>()
            .Property(entity => entity.ReleasedOn)
            .HasColumnType("date");

        modelBuilder.Entity<ProductRelationshipDto>().ToTable("ProductRelationship", "dbo");
        modelBuilder.Entity<ProductRelationshipDto>().HasKey(entity => new { entity.ProductId, entity.DependentProductId });
        modelBuilder.Entity<ProductRelationshipDto>()
            .HasOne(entity => entity.Product)
            .WithMany(entity => entity.ProductRelationships)
            .HasForeignKey(entity => entity.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductRelationshipDto>()
            .HasOne(entity => entity.DependentProduct)
            .WithMany()
            .HasForeignKey(entity => entity.DependentProductId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<ProductRelationshipDto>()
            .HasIndex(entity => entity.ProductId)
            .HasDatabaseName("IX_ProductRelationship_ProductId");
        modelBuilder.Entity<ProductRelationshipDto>()
            .HasIndex(entity => entity.DependentProductId)
            .HasDatabaseName("IX_ProductRelationship_DependentProductId");
        modelBuilder.Entity<ProductRelationshipDto>()
            .HasIndex(entity => new { entity.ProductId, entity.Order })
            .HasDatabaseName("UIX_ProductRelationship_ProductId_Order")
            .IsUnique();
        modelBuilder.Entity<ProductRelationshipDto>().HasCheckConstraint("CK_ProductRelationship_Name", "LEN(TRIM([Name])) > 0");
        modelBuilder.Entity<ProductRelationshipDto>().HasCheckConstraint("CK_ProductRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

        modelBuilder.Entity<WorkDto>().ToTable("Work", "dbo");
        modelBuilder.Entity<WorkDto>().HasKey(entity => entity.Id);
        modelBuilder.Entity<WorkDto>()
            .HasIndex(entity => entity.InternationalStandardMusicalWorkCode)
            .HasDatabaseName("IX_Work_InternationalStandardMusicalWorkCode");
        modelBuilder.Entity<WorkDto>().HasCheckConstraint("CK_Work_Title", "LEN(TRIM([Title])) > 0");
        modelBuilder.Entity<WorkDto>().HasCheckConstraint("CK_Work_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");
        modelBuilder.Entity<WorkDto>().HasCheckConstraint("CK_Work_DisambiguationText", "[DisambiguationText] IS NULL OR LEN(TRIM([DisambiguationText])) > 0");
        modelBuilder.Entity<WorkDto>().HasCheckConstraint("CK_Work_InternationalStandardMusicalWorkCode", "[InternationalStandardMusicalWorkCode] IS NULL OR LEN(TRIM([InternationalStandardMusicalWorkCode])) > 0");
        modelBuilder.Entity<WorkDto>()
            .Property(entity => entity.ReleasedOn)
            .HasColumnType("date");

        modelBuilder.Entity<WorkRelationshipDto>().ToTable("WorkRelationship", "dbo");
        modelBuilder.Entity<WorkRelationshipDto>().HasKey(entity => new { entity.WorkId, entity.DependentWorkId });
        modelBuilder.Entity<WorkRelationshipDto>()
            .HasOne(entity => entity.Work)
            .WithMany(entity => entity.WorkRelationships)
            .HasForeignKey(entity => entity.WorkId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkRelationshipDto>()
            .HasOne(entity => entity.DependentWork)
            .WithMany()
            .HasForeignKey(entity => entity.DependentWorkId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<WorkRelationshipDto>()
            .HasIndex(entity => entity.WorkId)
            .HasDatabaseName("IX_WorkRelationship_WorkId");
        modelBuilder.Entity<WorkRelationshipDto>()
            .HasIndex(entity => entity.DependentWorkId)
            .HasDatabaseName("IX_WorkRelationship_DependentWorkId");
        modelBuilder.Entity<WorkRelationshipDto>()
            .HasIndex(entity => new { entity.WorkId, entity.Order })
            .HasDatabaseName("UIX_WorkRelationship_WorkId_Order")
            .IsUnique();
        modelBuilder.Entity<WorkRelationshipDto>().HasCheckConstraint("CK_WorkRelationship_Name", "LEN(TRIM([Name])) > 0");
        modelBuilder.Entity<WorkRelationshipDto>().HasCheckConstraint("CK_WorkRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

        modelBuilder.Entity<WorkArtistDto>().ToTable("WorkArtist", "dbo");
        modelBuilder.Entity<WorkArtistDto>().HasKey(entity => new { entity.WorkId, entity.ArtistId });
        modelBuilder.Entity<WorkArtistDto>()
            .HasOne(entity => entity.Work)
            .WithMany(entity => entity.WorkArtists)
            .HasForeignKey(entity => entity.WorkId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkArtistDto>()
            .HasOne(entity => entity.Artist)
            .WithMany()
            .HasForeignKey(entity => entity.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkArtistDto>()
            .HasIndex(entity => entity.WorkId)
            .HasDatabaseName("IX_WorkArtist_WorkId");
        modelBuilder.Entity<WorkArtistDto>()
            .HasIndex(entity => entity.ArtistId)
            .HasDatabaseName("IX_WorkArtist_ArtistId");
        modelBuilder.Entity<WorkArtistDto>()
            .HasIndex(entity => new { entity.WorkId, entity.Order })
            .HasDatabaseName("UIX_WorkArtist_WorkId_Order")
            .IsUnique();

        modelBuilder.Entity<WorkFeaturedArtistDto>().ToTable("WorkFeaturedArtist", "dbo");
        modelBuilder.Entity<WorkFeaturedArtistDto>().HasKey(entity => new { entity.WorkId, entity.ArtistId });
        modelBuilder.Entity<WorkFeaturedArtistDto>()
            .HasOne(entity => entity.Work)
            .WithMany(entity => entity.WorkFeaturedArtists)
            .HasForeignKey(entity => entity.WorkId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkFeaturedArtistDto>()
            .HasOne(entity => entity.Artist)
            .WithMany()
            .HasForeignKey(entity => entity.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkFeaturedArtistDto>()
            .HasIndex(entity => entity.WorkId)
            .HasDatabaseName("IX_WorkFeaturedArtist_WorkId");
        modelBuilder.Entity<WorkFeaturedArtistDto>()
            .HasIndex(entity => entity.ArtistId)
            .HasDatabaseName("IX_WorkFeaturedArtist_ArtistId");
        modelBuilder.Entity<WorkFeaturedArtistDto>()
            .HasIndex(entity => new { entity.WorkId, entity.Order })
            .HasDatabaseName("UIX_WorkFeaturedArtist_WorkId_Order")
            .IsUnique();

        modelBuilder.Entity<WorkPerformerDto>().ToTable("WorkPerformer", "dbo");
        modelBuilder.Entity<WorkPerformerDto>().HasKey(entity => new { entity.WorkId, entity.ArtistId });
        modelBuilder.Entity<WorkPerformerDto>()
            .HasOne(entity => entity.Work)
            .WithMany(entity => entity.WorkPerformers)
            .HasForeignKey(entity => entity.WorkId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkPerformerDto>()
            .HasOne(entity => entity.Artist)
            .WithMany()
            .HasForeignKey(entity => entity.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkPerformerDto>()
            .HasIndex(entity => entity.WorkId)
            .HasDatabaseName("IX_WorkPerformer_WorkId");
        modelBuilder.Entity<WorkPerformerDto>()
            .HasIndex(entity => entity.ArtistId)
            .HasDatabaseName("IX_WorkPerformer_ArtistId");
        modelBuilder.Entity<WorkPerformerDto>()
            .HasIndex(entity => new { entity.WorkId, entity.Order })
            .HasDatabaseName("UIX_WorkPerformer_WorkId_Order")
            .IsUnique();

        modelBuilder.Entity<WorkComposerDto>().ToTable("WorkComposer", "dbo");
        modelBuilder.Entity<WorkComposerDto>().HasKey(entity => new { entity.WorkId, entity.ArtistId });
        modelBuilder.Entity<WorkComposerDto>()
            .HasOne(entity => entity.Work)
            .WithMany(entity => entity.WorkComposers)
            .HasForeignKey(entity => entity.WorkId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkComposerDto>()
            .HasOne(entity => entity.Artist)
            .WithMany()
            .HasForeignKey(entity => entity.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkComposerDto>()
            .HasIndex(entity => entity.WorkId)
            .HasDatabaseName("IX_WorkComposer_WorkId");
        modelBuilder.Entity<WorkComposerDto>()
            .HasIndex(entity => entity.ArtistId)
            .HasDatabaseName("IX_WorkComposer_ArtistId");
        modelBuilder.Entity<WorkComposerDto>()
            .HasIndex(entity => new { entity.WorkId, entity.Order })
            .HasDatabaseName("UIX_WorkComposer_WorkId_Order")
            .IsUnique();

        modelBuilder.Entity<WorkGenreDto>().ToTable("WorkGenre", "dbo");
        modelBuilder.Entity<WorkGenreDto>().HasKey(entity => new { entity.WorkId, entity.GenreId });
        modelBuilder.Entity<WorkGenreDto>()
            .HasOne(entity => entity.Work)
            .WithMany(entity => entity.WorkGenres)
            .HasForeignKey(entity => entity.WorkId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkGenreDto>()
            .HasOne(entity => entity.Genre)
            .WithMany()
            .HasForeignKey(entity => entity.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkGenreDto>()
            .HasIndex(entity => entity.WorkId)
            .HasDatabaseName("IX_WorkGenre_WorkId");
        modelBuilder.Entity<WorkGenreDto>()
            .HasIndex(entity => entity.GenreId)
            .HasDatabaseName("IX_WorkGenre_GenreId");
        modelBuilder.Entity<WorkGenreDto>()
            .HasIndex(entity => new { entity.WorkId, entity.Order })
            .HasDatabaseName("UIX_WorkGenre_WorkId_Order")
            .IsUnique();

        modelBuilder.Entity<WorkToProductRelationshipDto>().ToTable("WorkToProductRelationship", "dbo");
        modelBuilder.Entity<WorkToProductRelationshipDto>().HasKey(entity => new { entity.WorkId, entity.ProductId });
        modelBuilder.Entity<WorkToProductRelationshipDto>()
            .HasOne(entity => entity.Work)
            .WithMany(entity => entity.WorkToProductRelationships)
            .HasForeignKey(entity => entity.WorkId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkToProductRelationshipDto>()
            .HasOne(entity => entity.Product)
            .WithMany()
            .HasForeignKey(entity => entity.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WorkToProductRelationshipDto>()
            .HasIndex(entity => entity.WorkId)
            .HasDatabaseName("IX_WorkToProductRelationship_WorkId");
        modelBuilder.Entity<WorkToProductRelationshipDto>()
            .HasIndex(entity => entity.ProductId)
            .HasDatabaseName("IX_WorkToProductRelationship_ProductId");
        modelBuilder.Entity<WorkToProductRelationshipDto>()
            .HasIndex(entity => new { entity.WorkId, entity.Order })
            .HasDatabaseName("UIX_WorkToProductRelationship_WorkId_Order")
            .IsUnique();
        modelBuilder.Entity<WorkToProductRelationshipDto>()
            .HasIndex(entity => new { entity.ProductId, entity.ReferenceOrder })
            .HasDatabaseName("UIX_WorkToProductRelationship_ProductId_ReferenceOrder")
            .IsUnique();
        modelBuilder.Entity<WorkToProductRelationshipDto>().HasCheckConstraint("CK_WorkToProductRelationship_Name", "LEN(TRIM([Name])) > 0");
        modelBuilder.Entity<WorkToProductRelationshipDto>().HasCheckConstraint("CK_WorkToProductRelationship_Description", "[Description] IS NULL OR LEN(TRIM([Description])) > 0");

        base.OnModelCreating(modelBuilder);
    }
}
