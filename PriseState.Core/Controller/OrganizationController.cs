using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Pagination;
using PriseState.Core.Models;

namespace PriseState.Core.Controller;

public class OrganizationController: Microsoft.AspNetCore.Mvc.Controller
{
	private readonly IOrganizationService _organizationService;

	public OrganizationController(IOrganizationService organizationService)
	{
		_organizationService = organizationService;
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
	public async Task<BaseResponse<long>> Add([FromBody] AddOrganizationRequest request)
	{
		var result = await _organizationService.AddOrganizationAsync(request.RegionId, request.OrganizationName);
		return new BaseResponse<long>(result);
	}

	/// <summary>
	///     Получить список всех кафедр
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetAll)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<OrganizationModel>>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetOrganizationsResponse>> GetAll([FromQuery] GetOrganizationsRequest request)
	{
		var result = await _organizationService.GetOrganizations(request);
		return new BaseResponse<GetOrganizationsResponse>(result);
	}

	/// <summary>
	///     Получить название кафедры и факультета
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route($"{nameof(GetOrganization)}")]
	[ProducesResponseType(200, Type = typeof(BaseResponse<IReadOnlyCollection<OrganizationModel>>))]
	[ProducesResponseType(400, Type = typeof(BaseResponse))]
	public async Task<BaseResponse<GetOrganizationsResponse>> GetOrganization([FromQuery] GetOrganizationRequest request)
	{
		var result = await _organizationService.GetOrganization(request);
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
		await _organizationService.RenameOrganization(id, name);
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
		await _organizationService.DeleteOrganization(id);
		return new BaseResponse();
	}
}