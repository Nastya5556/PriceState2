using PriceState.Data.Models;
using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Model.Product;

namespace PriceState.Interfaces;

public interface IOrganizationService
{
   Task<long> AddOrganizationAsync(int regionId, string name);

    Task<GetOrganizationsResponse> GetOrganizations(GetOrganizationsRequest request);

    Task<GetOrganizationsResponse?> GetOrganization(GetOrganizationRequest request);

    Task RenameOrganization(long organizationId, string name);

    Task DeleteOrganization(long organizationId);
}