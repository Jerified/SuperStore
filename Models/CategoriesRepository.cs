namespace SuperStore.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> categories = new List<Category>()
        {
            new Category{ CategoryId = 1, Name = "Electronics", Description = "Electronic devices" },
            new Category{ CategoryId = 2, Name = "Clothing", Description = "Clothings and accessories" },
            new Category{ CategoryId = 3, Name = "Home", Description = "Home furnishings" },
        };

        public static void AddCategory(Category category)
        {
            var maxId = categories.Max(c => c.CategoryId);
            category.CategoryId = maxId + 1;
            categories.Add(category);
        }

        public static List<Category> GetCategories() => categories;

        public static Category? GetCategory(int id) 
        {
        var category = categories.FirstOrDefault(c => c.CategoryId == id);
        if(category != null)
        {
            return new Category
             { 
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description 
            };
        };

        return null;
    }

    public static void UpdateCategory(int categoryId, Category category)
    {
        if (categoryId != category.CategoryId) return;

        var categoryToUpdate = categories.FirstOrDefault(c => c.CategoryId == categoryId);
        if(categoryToUpdate != null) 
        {
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
        };
    }

    public static void DeleteCategory(int categoryId)
    {
        var categoryToDelete = GetCategory(categoryId);
        if(categoryToDelete != null)
        {
            categories.Remove(categoryToDelete);
        }
    }
};
}