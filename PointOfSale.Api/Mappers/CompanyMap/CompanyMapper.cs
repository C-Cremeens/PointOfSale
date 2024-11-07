using PointOfSale.Shared.DTOs;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Mappers.CompanyMap;

public static class CompanyMapper
{
    public static CompanyDTO MapToDto(this Company company)
    {
        return new CompanyDTO
        {
            Id = company.Id,
            Name = company.Name,
            Address = company.Address
        };
    }
}
