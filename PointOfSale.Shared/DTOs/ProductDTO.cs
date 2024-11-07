using System.Text.Json.Serialization;

namespace PointOfSale.Shared.DTOs;

public record ProductDTO
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public ProductSubCategoryDTO? ProductSubCategory { get; init; }
    public ProductCategoryDTO? ProductCategory { get; init; }
    public required UnitOfMeasureDTO UnitOfMeasure { get; init; }
    public required IProductSpecifications Specifications { get; init; }
}

public enum ProductType
{
    Sheet,
    Structural,
    Piping,
    Plumbing,
    Hardware,
    HVAC,
    Other
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(SheetMetalSpecifications), (int)ProductType.Sheet)]
[JsonDerivedType(typeof(StructuralSpecifications), (int)ProductType.Structural)]
[JsonDerivedType(typeof(PipingSpecifications), (int)ProductType.Piping)]
[JsonDerivedType(typeof(HardwareSpecifications), (int)ProductType.Hardware)]
public interface IProductSpecifications
{
    ProductType Type { get; }
}

public record SheetMetalSpecifications : IProductSpecifications
{
    public ProductType Type => ProductType.Sheet;
    public required List<string> AvailableGauges { get; init; }
    public required List<string> AvailableSizes { get; init; }
    public string? Material { get; init; }
    public decimal? WeightPerUnit { get; init; }
}

public record StructuralSpecifications : IProductSpecifications
{
    public ProductType Type => ProductType.Structural;
    public required List<string> AvailableThicknesses { get; init; }
    public required List<string> AvailableLengths { get; init; }
    public required List<string> AvailableWidths { get; init; }
    public string? Material { get; init; }
    public decimal? WeightPerUnit { get; init; }
}

public record PipingSpecifications : IProductSpecifications
{
    public ProductType Type => ProductType.Piping;
    public required List<string> AvailableDiameters { get; init; }
    public required List<string> AvailableSchedules { get; init; }
    public string? Material { get; init; }
    public decimal? WeightPerUnit { get; init; }
}

public record HardwareSpecifications : IProductSpecifications
{
    public ProductType Type => ProductType.Hardware;
    public required string Size { get; init; }
    public string? Thread { get; init; }
    public string? Grade { get; init; }
    public string? Finish { get; init; }
    public decimal? WeightPerUnit { get; init; }
}

public class ProductCategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ProductSubCategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class MaterialDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UnitOfMeasureDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

