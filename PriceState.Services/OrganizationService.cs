using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class OrganizationService: IOrganizationService
{
	private readonly DataContext _db;

	public OrganizationService(DataContext db)
	{
		_db = db;
	}

	public async Task<long> AddOrganizationAsync(int regionId, string name)
	{
		if (await _db.Regions.AllAsync(x => x.Id != regionId))
			throw new PriceStateException($"Region {regionId} is not exists!", EnumErrorCode.EntityIsNotFound);

		var organization = new Organization
		{
			Name = name,
			RegionId = regionId
		};

		await _db.Organizations.AddAsync(organization);
		await _db.SaveChangesAsync();

		return organization.Id;
	}

	public async Task<GetOrganizationsResponse> GetOrganizations(GetOrganizationsRequest request)
	{
		var query = request.RegionId.HasValue
			? _db.Organizations.Where(x => x.RegionId == request.RegionId)
			: _db.Organizations.AsQueryable();

		var result = await query.GetPageAsync<GetOrganizationsResponse, Organization, OrganizationModel>(request, x =>
			new OrganizationModel
			{
				Id = x.Id,
				RegionId = x.RegionId,
				Name = x.Name
			});

		return result;
	}

	public async Task<GetOrganizationsResponse> GetOrganization(GetOrganizationRequest request)
	{
		var query = request.OrganizationId.HasValue
			? _db.Organizations.Where(x => x.Id == request.OrganizationId)
			: _db.Organizations.AsQueryable();

		var result = await query.GetPageAsync<GetOrganizationsResponse, Organization, OrganizationModel>(request, x =>
			new OrganizationModel
			{
				Id = x.Id,
				RegionId = x.RegionId,
				Name = x.Name
			});

		return result;
	}

	public async Task RenameOrganization(long organizationId, string name)
	{
		var organization = await _db.Organizations.FirstOrDefaultAsync(x => x.Id == organizationId);
		if (organization is null)
			throw new PriceStateException($"Organization {organizationId} is not exists!", EnumErrorCode.EntityIsNotFound);

		organization.Name = name;
		await _db.SaveChangesAsync();
	}
	

	public async Task DeleteOrganization(long organizationId)
	{
		_db.Organizations.Remove(new Organization {Id = organizationId});
		await _db.SaveChangesAsync();
	}
	
}