using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class MenuRepository : IMenuRepository
    {
        private GraphQLDbContext dbContext;

        public MenuRepository(GraphQLDbContext context)
        {
            dbContext = context;
        }

        public List<Menu> GetAllMenus()
        {
            return dbContext.Menus.ToList();
        }

        public Menu GetMenuById(int id)
        {
            return dbContext.Menus.FirstOrDefault(x => x.Id == id);
        }

        public Menu AddMenu(Menu menu)
        {
            dbContext.Menus.Add(menu);
            dbContext.SaveChanges();

            return menu;
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var result = dbContext.Menus.FirstOrDefault(x => x.Id == id);
            if (result != null) {
                result.Name = menu.Name;
                result.Description = menu.Description;
                result.Price = menu.Price;
                dbContext.SaveChanges();
            }
            return menu;
        }

        public void DeleteMenu(int id)
        {
            var result = dbContext.Menus.FirstOrDefault(x => x.Id == id);
            dbContext.Menus.Remove(result);
            dbContext.SaveChanges();
        }
    }
}