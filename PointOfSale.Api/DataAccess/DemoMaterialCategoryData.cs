//using PointOfSale.Shared.DTOs;
//using System.Collections.Concurrent;

//namespace PointOfSale.Api.DataAccess;

//public class DemoMaterialCategoryData : IMaterialCategoryData
//{
//    private static readonly ConcurrentDictionary<int, MaterialCategoryDTO> _categories = new();
//    private static int _nextId = 1;

//    public DemoMaterialCategoryData()
//    {
//        // Initialize with some demo data if empty
//        if (_categories.IsEmpty)
//        {
//            AddMaterialCategoryAsync(new MaterialCategoryDTO { Name = "Raw Materials" }).Wait();
//            AddMaterialCategoryAsync(new MaterialCategoryDTO { Name = "Packaging" }).Wait();
//            AddMaterialCategoryAsync(new MaterialCategoryDTO { Name = "Finished Goods" }).Wait();
//            AddMaterialCategoryAsync(new MaterialCategoryDTO { Name = "Supplies" }).Wait();
//        }
//    }

//    public async Task<MaterialCategoryDTO> AddMaterialCategoryAsync(MaterialCategoryDTO materialCategory)
//    {
//        if (string.IsNullOrWhiteSpace(materialCategory.Name))
//            throw new ArgumentException("Category name cannot be empty", nameof(materialCategory));

//        // Simulate network delay
//        await Task.Delay(100);

//        materialCategory.Id = Interlocked.Increment(ref _nextId);

//        if (!_categories.TryAdd(materialCategory.Id, materialCategory))
//            throw new InvalidOperationException($"Failed to add category with ID {materialCategory.Id}");

//        return materialCategory;
//    }

//    public async Task DeleteMaterialCategoryAsync(int id)
//    {
//        // Simulate network delay
//        await Task.Delay(100);

//        if (!_categories.TryRemove(id, out _))
//            throw new KeyNotFoundException($"Category with ID {id} not found");
//    }

//    public async Task<IEnumerable<MaterialCategoryDTO>> GetMaterialCategoriesAsync()
//    {
//        // Simulate network delay
//        await Task.Delay(100);

//        return _categories.Values.OrderBy(c => c.Name).ToList();
//    }

//    public async Task<MaterialCategoryDTO> GetMaterialCategoryAsync(int id)
//    {
//        // Simulate network delay
//        await Task.Delay(100);

//        if (!_categories.TryGetValue(id, out var category))
//            throw new KeyNotFoundException($"Category with ID {id} not found");

//        return category;
//    }

//    public async Task<MaterialCategoryDTO> UpdateMaterialCategoryAsync(MaterialCategoryDTO materialCategory)
//    {
//        if (materialCategory == null)
//            throw new ArgumentNullException(nameof(materialCategory));

//        if (string.IsNullOrWhiteSpace(materialCategory.Name))
//            throw new ArgumentException("Category name cannot be empty", nameof(materialCategory));

//        // Simulate network delay
//        await Task.Delay(100);

//        if (!_categories.TryGetValue(materialCategory.Id, out _))
//            throw new KeyNotFoundException($"Category with ID {materialCategory.Id} not found");

//        _categories[materialCategory.Id] = materialCategory;
//        return materialCategory;
//    }
//}