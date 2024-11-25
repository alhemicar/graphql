using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the Menu.");
            Field(x => x.Name).Description("The Name of the Menu.");
            Field(x => x.Description).Description("The Description of the Menu.");
            Field(x => x.Price).Description("The Price of the Menu.");
            Field(x => x.ImageUrl).Description("The Image of the Menu.");
            Field(x => x.CategoryId).Description("Category Id of the Menu.");
        }
    }
}