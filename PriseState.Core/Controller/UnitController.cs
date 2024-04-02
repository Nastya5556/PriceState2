using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Region;
using PriceState.Interfaces.Model.Unit;
using PriceState.Interfaces.Pagination;
using PriseState.Core.Models;

namespace PriseState.Core.Controller;

public class UnitController: Microsoft.AspNetCore.Mvc.Controller
{
	private readonly IUnitService _unit;

	public UnitController(IUnitService unit)
	{
		_unit = unit;
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
	public async Task<BaseResponse<int>> Add([FromBody] AddUnitRequest model)
	{
		var result = await _unit.CreateUnitAsync(model.Name);
		return new BaseResponse<int>(result?.Id ?? 0);
	}

	/// <summary>
	///     Получить список всех факультетов
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<GetUnitsResponse>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetUnitsResponse>> GetAll([FromQuery] Page request)
	{
		var result = await _unit.GetAllUnitAsync(new GetUnitsRequest {Page = request});
		return new BaseResponse<GetUnitsResponse>(result);
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
		var result = await _unit.GetUnitAsync(id);
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
		await _unit.RenameUnitAsync(id,name);
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
		await _unit.DeleteUnitAsync(id);
		return new BaseResponse();
	}
}