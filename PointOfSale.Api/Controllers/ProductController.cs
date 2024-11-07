using Microsoft.AspNetCore.Mvc;
using PointOfSale.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PointOfSale.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private List<ProductDTO> _products;

    public ProductController()
    {
        _products = new List<ProductDTO>
        {
            // Sheet Metal Examples
            new ProductDTO
            {
                Id = 1,
                Name = "Galvanized Sheet Metal",
                Description = "Corrosion-resistant galvanized steel sheet",
                ProductCategory = new ProductCategoryDTO { Id = 1, Name = "Sheet Metal" },
                ProductSubCategory = new ProductSubCategoryDTO { Id = 1, Name = "Galvanized" },
                UnitOfMeasure = new UnitOfMeasureDTO { Id = 1, Name = "Sheet" },
                Specifications = new SheetMetalSpecifications
                {
                    AvailableGauges = new() { "22ga", "24ga", "26ga" },
                    AvailableSizes = new() { "4x8", "4x10" },
                    Material = "Galvanized Steel",
                    WeightPerUnit = 40.5m
                }
            },
            new ProductDTO
            {
                Id = 2,
                Name = "Aluminum Sheet",
                Description = "Lightweight aluminum sheet metal",
                ProductCategory = new ProductCategoryDTO { Id = 1, Name = "Sheet Metal" },
                ProductSubCategory = new ProductSubCategoryDTO { Id = 2, Name = "Aluminum" },
                UnitOfMeasure = new UnitOfMeasureDTO { Id = 1, Name = "Sheet" },
                Specifications = new SheetMetalSpecifications
                {
                    AvailableGauges = new() { "0.025\"", "0.032\"", "0.040\"" },
                    AvailableSizes = new() { "4x8", "4x12" },
                    Material = "Aluminum",
                    WeightPerUnit = 12.8m
                }
            },

            // Structural Examples
            new ProductDTO
            {
                Id = 3,
                Name = "Steel Angle Iron",
                Description = "Hot-rolled steel angle iron",
                ProductCategory = new ProductCategoryDTO { Id = 2, Name = "Structural" },
                ProductSubCategory = new ProductSubCategoryDTO { Id = 3, Name = "Angles" },
                UnitOfMeasure = new UnitOfMeasureDTO { Id = 2, Name = "Length" },
                Specifications = new StructuralSpecifications
                {
                    AvailableThicknesses = new() { "1/8\"", "3/16\"", "1/4\"" },
                    AvailableLengths = new() { "20'", "24'" },
                    AvailableWidths = new() { "2\"", "3\"", "4\"" },
                    Material = "A36 Steel",
                    WeightPerUnit = 2.35m
                }
            },
            new ProductDTO
            {
                Id = 4,
                Name = "Steel Channel",
                Description = "Standard steel channel",
                ProductCategory = new ProductCategoryDTO { Id = 2, Name = "Structural" },
                ProductSubCategory = new ProductSubCategoryDTO { Id = 4, Name = "Channels" },
                UnitOfMeasure = new UnitOfMeasureDTO { Id = 2, Name = "Length" },
                Specifications = new StructuralSpecifications
                {
                    AvailableThicknesses = new() { "3/16\"", "1/4\"" },
                    AvailableLengths = new() { "20'", "24'" },
                    AvailableWidths = new() { "3\"", "4\"", "6\"" },
                    Material = "A36 Steel",
                    WeightPerUnit = 4.1m
                }
            },

            // Piping Examples
            new ProductDTO
            {
                Id = 5,
                Name = "Black Steel Pipe",
                Description = "Schedule 40 black steel pipe",
                ProductCategory = new ProductCategoryDTO { Id = 3, Name = "Piping" },
                ProductSubCategory = new ProductSubCategoryDTO { Id = 5, Name = "Steel Pipe" },
                UnitOfMeasure = new UnitOfMeasureDTO { Id = 2, Name = "Length" },
                Specifications = new PipingSpecifications
                {
                    AvailableDiameters = new() { "1/2\"", "3/4\"", "1\"", "1-1/2\"" },
                    AvailableSchedules = new() { "40", "80" },
                    Material = "Black Steel",
                    WeightPerUnit = 1.68m
                }
            },
            new ProductDTO
            {
                Id = 6,
                Name = "Copper Pipe",
                Description = "Type L copper pipe",
                ProductCategory = new ProductCategoryDTO { Id = 3, Name = "Piping" },
                ProductSubCategory = new ProductSubCategoryDTO { Id = 6, Name = "Copper Pipe" },
                UnitOfMeasure = new UnitOfMeasureDTO { Id = 2, Name = "Length" },
                Specifications = new PipingSpecifications
                {
                    AvailableDiameters = new() { "1/2\"", "3/4\"", "1\"" },
                    AvailableSchedules = new() { "Type L", "Type M" },
                    Material = "Copper",
                    WeightPerUnit = 0.64m
                }
            },

            // Hardware Examples
            new ProductDTO
            {
                Id = 7,
                Name = "Hex Bolts",
                Description = "Grade 5 hex bolts",
                ProductCategory = new ProductCategoryDTO { Id = 4, Name = "Hardware" },
                ProductSubCategory = new ProductSubCategoryDTO { Id = 7, Name = "Bolts" },
                UnitOfMeasure = new UnitOfMeasureDTO { Id = 3, Name = "Each" },
                Specifications = new HardwareSpecifications
                {
                    Size = "3/8\"-16",
                    Thread = "UNC",
                    Grade = "Grade 5",
                    Finish = "Zinc",
                    WeightPerUnit = 0.05m
                }
            },
            new ProductDTO
            {
                Id = 8,
                Name = "Carriage Bolts",
                Description = "Grade 2 carriage bolts",
                ProductCategory = new ProductCategoryDTO { Id = 4, Name = "Hardware" },
                ProductSubCategory = new ProductSubCategoryDTO { Id = 7, Name = "Bolts" },
                UnitOfMeasure = new UnitOfMeasureDTO { Id = 3, Name = "Each" },
                Specifications = new HardwareSpecifications
                {
                    Size = "1/4\"-20",
                    Thread = "UNC",
                    Grade = "Grade 2",
                    Finish = "Plain",
                    WeightPerUnit = 0.025m
                }
            }
        };
    }


    // GET: api/Product
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProductDTO>> Get()
    {
        return Ok(_products);
    }

    // GET api/Product/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProductDTO> Get(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // POST api/Product
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProductDTO> Post([FromBody] ProductDTO product)
    {
        if (product == null)
        {
            return BadRequest();
        }

        // Simple validation - check if ID already exists
        if (_products.Any(p => p.Id == product.Id))
        {
            return BadRequest("Product with this ID already exists");
        }

        _products.Add(product);

        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    // PUT api/Product/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Put(int id, [FromBody] ProductDTO product)
    {
        if (product == null || id != product.Id)
        {
            return BadRequest();
        }

        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        var index = _products.IndexOf(existingProduct);
        _products[index] = product;

        return NoContent();
    }

    // DELETE api/Product/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        _products.Remove(product);
        return NoContent();
    }

    // Optional: Add filtering endpoint
    // GET: api/Product/category/{categoryId}
    [HttpGet("category/{categoryId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProductDTO>> GetByCategory(int categoryId)
    {
        var products = _products.Where(p => p.ProductCategory?.Id == categoryId);
        return Ok(products);
    }


}
