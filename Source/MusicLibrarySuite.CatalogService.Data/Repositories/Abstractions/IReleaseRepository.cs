using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MusicLibrarySuite.CatalogService.Data.Entities;
using MusicLibrarySuite.CatalogService.Data.Entities.Base;

namespace MusicLibrarySuite.CatalogService.Data.Repositories.Abstractions;

/// <summary>
/// Defines a set of members a provider-specific release repository should implement.
/// </summary>
public interface IReleaseRepository
{
    /// <summary>
    /// Asynchronously gets a release by its unique identifier.
    /// </summary>
    /// <param name="releaseId">The release's unique identifier.</param>
    /// <returns>
    /// The task object representing the asynchronous operation.
    /// The task's result will be the release found or <see langword="null" />.
    /// </returns>
    public Task<ReleaseDto?> GetReleaseAsync(Guid releaseId);

    /// <summary>
    /// Asynchronously gets all releases.
    /// </summary>
    /// <returns>
    /// The task object representing the asynchronous operation.
    /// The task's result will be an array containing all releases.
    /// </returns>
    public Task<ReleaseDto[]> GetReleasesAsync();

    /// <summary>
    /// Asynchronously gets releases by a collection of unique identifiers.
    /// </summary>
    /// <param name="releaseIds">The collection of unique identifiers to search for.</param>
    /// <returns>
    /// The task object representing the asynchronous operation.
    /// The task's result will be an array containing all found releases.
    /// </returns>
    public Task<ReleaseDto[]> GetReleasesAsync(IEnumerable<Guid> releaseIds);

    /// <summary>
    /// Asynchronously gets releases filtered by a collection processor.
    /// </summary>
    /// <param name="collectionProcessor">The collection processor to filter releases.</param>
    /// <returns>
    /// The task object representing the asynchronous operation.
    /// The task's result will be an array containing all found releases.
    /// </returns>
    public Task<ReleaseDto[]> GetReleasesAsync(EntityCollectionProcessor<ReleaseDto> collectionProcessor);

    /// <summary>
    /// Asynchronously gets releases by a release page request.
    /// </summary>
    /// <param name="releaseRequest">The release page request configuration.</param>
    /// <returns>
    /// The task object representing the asynchronous operation.
    /// The task's result will be an array containing all releases corresponding to the request configuration.
    /// </returns>
    public Task<PageResponseDto<ReleaseDto>> GetReleasesAsync(ReleaseRequestDto releaseRequest);

    /// <summary>
    /// Asynchronously creates a new release.
    /// </summary>
    /// <param name="release">The release to create in the database.</param>
    /// <returns>
    /// The task object representing the asynchronous operation.
    /// The task's result will be the created release with properties like <see cref="ReleaseDto.Id" /> set.
    /// </returns>
    public Task<ReleaseDto> CreateReleaseAsync(ReleaseDto release);

    /// <summary>
    /// Asynchronously updates an existing release.
    /// </summary>
    /// <param name="release">The release to update in the database.</param>
    /// <returns>
    /// The task object representing the asynchronous operation.
    /// The task's result will be a value indicating whether the release was found and updated.
    /// </returns>
    public Task<bool> UpdateReleaseAsync(ReleaseDto release);

    /// <summary>
    /// Asynchronously deletes an existing release.
    /// </summary>
    /// <param name="releaseId">The unique identifier of the release to delete from the database.</param>
    /// <returns>
    /// The task object representing the asynchronous operation.
    /// The task's result will be a value indicating whether the release was found and deleted.
    /// </returns>
    public Task<bool> DeleteReleaseAsync(Guid releaseId);
}
