//using Microsoft.AspNetCore.Mvc;
//using PointOfSale.Api.DataAccess;
//using PointOfSale.Shared.DTOs;

//namespace PointOfSale.Api.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class MaterialCategoryController : ControllerBase
//{
//    private readonly IMaterialCategoryData _materialCategoryData;

//    public MaterialCategoryController(IMaterialCategoryData materialCategoryData)
//    {
//        _materialCategoryData = materialCategoryData;
//    }

//    // GET: api/MaterialCategory
//    [HttpGet]
//    [ProducesResponseType(StatusCodes.Status200OK)]
//    public async Task<ActionResult<IEnumerable<MaterialCategoryDTO>>> GetCategories()
//    {
//        var categories = await _materialCategoryData.GetMaterialCategoriesAsync();
//        return Ok(categories);
//    }

//    // GET api/MaterialCategory/5
//    [HttpGet("{id}")]
//    [ProducesResponseType(StatusCodes.Status200OK)]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    public async Task<ActionResult<MaterialCategoryDTO>> GetCategory(int id)
//    {
//        try
//        {
//            var category = await _materialCategoryData.GetMaterialCategoryAsync(id);
//            return Ok(category);
//        }
//        catch (KeyNotFoundException)
//        {
//            return NotFound($"Category with ID {id} not found");
//        }
//    }

//    // POST api/MaterialCategory
//    [HttpPost]
//    [ProducesResponseType(StatusCodes.Status201Created)]
//    [ProducesResponseType(StatusCodes.Status400BadRequest)]
//    public async Task<ActionResult<MaterialCategoryDTO>> CreateCategory([FromBody] MaterialCategoryDTO category)
//    {
//        try
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var createdCategory = await _materialCategoryData.AddMaterialCategoryAsync(category);
//            return CreatedAtAction(
//                nameof(GetCategory),
//                new { id = createdCategory.Id },
//                createdCategory);
//        }
//        catch (ArgumentException ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }

//    // PUT api/MaterialCategory/5
//    [HttpPut("{id}")]
//    [ProducesResponseType(StatusCodes.Status200OK)]
//    [ProducesResponseType(StatusCodes.Status400BadRequest)]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    public async Task<ActionResult<MaterialCategoryDTO>> UpdateCategory(int id, [FromBody] MaterialCategoryDTO category)
//    {
//        try
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            if (id != category.Id)
//                return BadRequest("ID in URL does not match ID in request body");

//            var updatedCategory = await _materialCategoryData.UpdateMaterialCategoryAsync(category);
//            return Ok(updatedCategory);
//        }
//        catch (KeyNotFoundException)
//        {
//            return NotFound($"Category with ID {id} not found");
//        }
//        catch (ArgumentException ex)
//        {
//            return BadRequest(ex.Message);
//        }
//    }

//    // DELETE api/MaterialCategory/5
//    [HttpDelete("{id}")]
//    [ProducesResponseType(StatusCodes.Status204NoContent)]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    public async Task<ActionResult> DeleteCategory(int id)
//    {
//        try
//        {
//            await _materialCategoryData.DeleteMaterialCategoryAsync(id);
//            return NoContent();
//        }
//        catch (KeyNotFoundException)
//        {
//            return NotFound($"Category with ID {id} not found");
//        }
//    }
//}