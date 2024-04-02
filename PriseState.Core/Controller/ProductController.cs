using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Model.Product;
using PriseState.Core.Models;

namespace PriseState.Core.Controller;

public class ProductController: Microsoft.AspNetCore.Mvc.Controller
{
	private readonly IProductService _productService;

	public ProductController(IProductService productService)
	{
		_productService = productService;
	}


	/// <summary>
	///     Добавить кафедру
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	[HttpPost]
	[Route($"{nameof(Add)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse<long>> Add([FromBody] AddProductRequest request)
	{
		var result = await _productService.AddProductAsync(request.RegionId, request.Name);
		return new BaseResponse<long>(result);
	}

	/// <summary>
	///     Получить список всех кафедр
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<ProductModel>>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetProductsResponse>> GetAll([FromQuery] GetProductsRequest request)
	{
		var result = await _productService.GetProducts(request);
		return new BaseResponse<GetProductsResponse>(result);
	}

	/// <summary>
	///     Получить название кафедры и факультета
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetProduct)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<ProductModel>>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetOrganizationsResponse>> GetOrganization([FromQuery] GetProductRequest request)
	{
		var result = await _productService.GetProduct(request);
		return new BaseResponse<GetOrganizationsResponse>(result);
	}

	/// <summary>
	///     Переименовать Кафедру
	/// </summary>
	/// <returns></returns>
	[HttpPatch]
	[Route($"{nameof(Rename)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] string name)
	{
		await _productService.RenameProduct(id, name);
		return new BaseResponse();
	}

	/// <summary>
	///     Удалить кафедру
	/// </summary>
	/// <returns></returns>
	[HttpDelete]
	[Route($"{nameof(Delete)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse> Delete([FromQuery] long id)
	{
		await _productService.DeleteProduct(id);
		return new BaseResponse();
	}
}