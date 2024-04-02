using PriceState.Data.Models;
using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Model.PriceOrganization;

namespace PriceState.Interfaces;

public interface IPriceOrganizationService
{
    Task<PriceOrganization?> CreatePriceOrganizationAsync(int organizationId, decimal Price, DateTime Date, long productId);

    Task<GetPriceOrganizationsResponse> GetAllPriceOrganizationAsync(GetPriceOrganizationsRequest request);

    Task<GetPriceOrganizationsResponse?> GetPriceOrganizationAsync(GetPriceOrganizationRequest request);

    Task RenamePriceOrganizationAsync(int organizationId, decimal price, DateTime date, long productId);

    Task DeletePriceOrganizationAsync(int organizationId, DateTime date, long productId);
}