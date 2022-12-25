using Microsoft.EntityFrameworkCore;

using MusicLibrarySuite.CatalogService.Data.Entities;

namespace MusicLibrarySuite.CatalogService.Data.Contexts;

/// <summary>
/// Represents a base class for the catalog service database context.
/// </summary>
public abstract class CatalogServiceDbContext : DbContext
{
    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object for entities of the <see cref="ArtistDto" /> type.
    /// </summary>
    public DbSet<ArtistDto> Artists { get; }

    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object for entities of the <see cref="ArtistRelationshipDto" /> type.
    /// </summary>
    public DbSet<ArtistRelationshipDto> ArtistRelationships { get; }

    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object for entities of the <see cref="ArtistGenreDto" /> type.
    /// </summary>
    public DbSet<ArtistGenreDto> ArtistGenres { get; }

    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object for entities of the <see cref="GenreDto" /> type.
    /// </summary>
    public DbSet<GenreDto> Genres { get; }

    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object for entities of the <see cref="GenreRelationshipDto" /> type.
    /// </summary>
    public DbSet<GenreRelationshipDto> GenreRelationships { get; }

    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object for entities of the <see cref="ProductDto" /> type.
    /// </summary>
    public DbSet<ProductDto> Products { get; }

    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object for entities of the <see cref="ProductRelationshipDto" /> type.
    /// </summary>
    public DbSet<ProductRelationshipDto> ProductRelationships { get; }

    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object for entities of the <see cref="WorkDto" /> type.
    /// </summary>
    public DbSet<WorkDto> Works { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CatalogServiceDbContext" /> type.
    /// </summary>
    protected CatalogServiceDbContext()
        : base()
    {
        Artists = Set<ArtistDto>();
        ArtistRelationships = Set<ArtistRelationshipDto>();
        ArtistGenres = Set<ArtistGenreDto>();
        Genres = Set<GenreDto>();
        GenreRelationships = Set<GenreRelationshipDto>();
        Products = Set<ProductDto>();
        ProductRelationships = Set<ProductRelationshipDto>();
        Works = Set<WorkDto>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CatalogServiceDbContext" /> type using the specified database context options.
    /// </summary>
    /// <param name="contextOptions">The database context options.</param>
    protected CatalogServiceDbContext(DbContextOptions contextOptions)
        : base(contextOptions)
    {
        Artists = Set<ArtistDto>();
        ArtistRelationships = Set<ArtistRelationshipDto>();
        ArtistGenres = Set<ArtistGenreDto>();
        Genres = Set<GenreDto>();
        GenreRelationships = Set<GenreRelationshipDto>();
        Products = Set<ProductDto>();
        ProductRelationships = Set<ProductRelationshipDto>();
        Works = Set<WorkDto>();
    }
}
