using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Region;
using PriceState.Interfaces.Pagination;
using PriseState.Core.Models;

namespace PriseState.Core.Controller;

public class RegionController : Microsoft.AspNetCore.Mvc.Controller
{
	private readonly IRegionService _region;

	public RegionController(IRegionService region)
	{
		_region = region;
	}

	/// <summary>
	///     Добавить регион
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpPost]
	[Route($"{nameof(Add)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<int>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse<int>> Add([FromBody] AddRegionRequest model)
	{
		var result = await _region.CreateRegionAsync(model.Name);
		return new BaseResponse<int>(result?.Id ?? 0);
	}

	/// <summary>
	///     Получить список всех факультетов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<GetRegionsResponse>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetRegionsResponse>> GetAll([FromQuery] Page request)
	{
		var result = await _region.GetAllRegionAsync(new GetRegionsRequest {Page = request});
		return new BaseResponse<GetRegionsResponse>(result);
	}

	/// <summary>
	///     Получить факультет
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(Get)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<(int Id, string Name)>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<(int Id, string Name)>> Get([FromQuery] [Required] int id)
	{
		var result = await _region.GetRegionAsync(id);
		return new BaseResponse<(int Id, string Name)>((result.Id, result.Name));
	}

	/// <summary>
	///     Переименовать факультет
	/// </summary>
	/// <returns></returns>
	[HttpPatch]
	[Route($"{nameof(Rename)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse> Rename([FromQuery] int id,[FromQuery] string name)
	{
		await _region.RenameRegionAsync(id,name);
		return new BaseResponse();
	}

	/// <summary>
	///     Удалить факультет
	/// </summary>
	/// <returns></returns>
	[HttpDelete]
	[Route($"{nameof(Delete)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	[Authorize]
	public async Task<BaseResponse> Delete([FromQuery] int id)
	{
		await _region.DeleteRegionAsync(id);
		return new BaseResponse();
	}
}