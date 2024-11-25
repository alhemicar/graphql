using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private GraphQLDbContext dbContext;

        public CategoryRepository(GraphQLDbContext context)
        {
            dbContext = context;
        }

        public List<Category> GetAllCategories()
        {
            return dbContext.Categories.ToList();
        }

        public Category AddCategory(Category Category)
        {
            dbContext.Categories.Add(Category);
            dbContext.SaveChanges();

            return Category;
        }

        public Category UpdateCategory(int id, Category Category)
        {
            var result = dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (result != null) {
                result.Name = Category.Name;
                result.ImageUrl = Category.ImageUrl;
                result.Menus = Category.Menus;
                dbContext.SaveChanges();
            }
            return Category;
        }

        public void DeleteCategory(int id)
        {
            var result = dbContext.Categories.FirstOrDefault(x => x.Id == id);
            dbContext.Categories.Remove(result);
            dbContext.SaveChanges();
        }
    }
}