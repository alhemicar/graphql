using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;

namespace GraphQLProject.Type
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuRepository menuRepository)
        {
            Field<ListGraphType<MenuType>>("Menus").Resolve(context => {
                return menuRepository.GetAllMenus();
            });

            Field<MenuType>("Menu").Arguments(new QueryArgument<IntGraphType> { Name = "id"}).Resolve(context => {
                return menuRepository.GetMenuById(context.GetArgument<int>("id"));
            });
        }
    }
}