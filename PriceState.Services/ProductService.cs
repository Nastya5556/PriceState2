using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Product;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class ProductService: IProductService
{
	private readonly DataContext _db;

	public ProductService(DataContext db)
	{
		_db = db;
	}

	public async Task<long> AddProductAsync(int unitId, string name)
	{
		if (await _db.Products.AllAsync(x => x.Id != unitId))
			throw new PriceStateException($"Unit {unitId} is not exists!", EnumErrorCode.EntityIsNotFound);

		var organization = new Organization
		{
			Name = name,
			UnitId = unitId
		};

		await _db.Units.AddAsync(unit);
		await _db.SaveChangesAsync();

		return unit.Id;
	}

	public async Task<GetProductsResponse> GetAllProductAsync(GetProductsRequest request)
	{
		var query = request.UnitId.HasValue
			? _db.Products.Where(x => x.UnitId == request.UnitId)
			: _db.Products.AsQueryable();

		var result = await query.GetPageAsync<GetProductsResponse, Product, ProductModel>(request, x =>
			new ProductModel
			{
				Id = x.Id,
				UnitId = x.UnitId,
				Name = x.Name
			});

		return result;
	}

	public async Task<GetProductsResponse> GetProductAsync(GetProductRequest request)
	{
		var query = request.ProductId.HasValue
			? _db.Organizations.Where(x => x.Id == request.ProductId)
			: _db.Organizations.AsQueryable();

		var result = await query.GetPageAsync<GetProductsResponse, Product, ProductModel>(request, x =>
			new ProductModel
			{
				Id = x.Id,
				UnitId = x.UnitId,
				Name = x.Name
			});

		return result;
	}

	public async Task RenameProductAsync(long productId, string name)
	{
		var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == productId);
		if (product is null)
			throw new PriceStateException($"Product{productId} is not exists!", EnumErrorCode.EntityIsNotFound);

		product.Name = name;
		await _db.SaveChangesAsync();
	}
	

	public async Task DeleteProductAsync(long productId)
	{
		_db.Products.Remove(new Product {Id = productId});
		await _db.SaveChangesAsync();
	}
	
}