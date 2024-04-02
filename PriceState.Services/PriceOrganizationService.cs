using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Model.PriceOrganization;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class PriceOrganizationService: IPriceOrganizationService
{
	private readonly DataContext _db;

	public PriceOrganizationService(DataContext db)
	{
		_db = db;
	}

	public async Task<PriceOrganization> CreatePriceOrganizationAsync(int organizationId, decimal price, DateTime date, long productId)
	{
		if (await _db.Organizations.AllAsync(x => x.Id != organizationId))
			throw new PriceStateException($"Organization {organizationId} is not exists!", EnumErrorCode.EntityIsNotFound);
		
		if (await _db.Products.AllAsync(x => x.Id != productId))
			throw new PriceStateException($"Product {productId} is not exists!", EnumErrorCode.EntityIsNotFound);
		
		if (await _db.PriceOrganizations.AnyAsync(x => x.ProductId == productId && x.OrganizationId == organizationId && x.Date == date))
			throw new PriceStateException($"There is such a price", EnumErrorCode.EntityIsAlreadyExists);
		var priceOrganization = new PriceOrganization
		{
			Date = date,
			OrganizationId = organizationId,
			Price = price,
			ProductId = productId
		};

		await _db.PriceOrganizations.AddAsync(priceOrganization);
		await _db.SaveChangesAsync();

		return priceOrganization;
	}
	


	public async Task<GetPriceOrganizationsResponse> GetAllPriceOrganizationAsync(GetPriceOrganizationsRequest request)
	{
		var query = request.Name != "" && request.OrganizationId.HasValue
			? _db.Products.Where(productPrice  => EF.Functions.Like(productPrice.Name, request.Name + "%"))
			: _db.Products.AsQueryable();
		
		var query = request.RegionId.HasValue
			? _db.Organizations.Where(x => x.RegionId == request.RegionId)
			: _db.Organizations.AsQueryable();

		var result = await query.GetPageAsync<GetOrganizationsResponse, Organization, OrganizationModel>(request, x =>
			new OrganizationModel
			{
				Id = x.Id,
				RegionId =  x.RegionId,
				Name = x.Name
			});

		return result;
	}


	public async Task<GetPriceOrganizationsResponse> GetPriceOrganizationAsync(GetPriceOrganizationRequest request)
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

	public async Task RenamePriceOrganizationAsync(int organizationId, decimal price, DateTime date, long productId)
	{
		var priceOrganization = await _db.PriceOrganizations.FirstOrDefaultAsync(x => x.ProductId == productId && x.OrganizationId == organizationId && x.Date == date)
		if (priceOrganization is null)
			throw new PriceStateException($"PriceOrganization is not exists!", EnumErrorCode.EntityIsNotFound);

		priceOrganization.Price = price;
		await _db.SaveChangesAsync();
	}
	
	
	public async Task DeleteOrganizationAsync(int organizationId, DateTime date, long productId)
	{
		var priceOrganization = await _db.PriceOrganizations.FirstOrDefaultAsync(x => x.ProductId == productId && x.OrganizationId == organizationId && x.Date == date))
		_db.PriceOrganizations.Remove(priceOrganization);
		await _db.SaveChangesAsync();
	}
	
}