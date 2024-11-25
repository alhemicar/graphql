using GraphQL.Types;
using GraphQLProject.Interfaces;

namespace GraphQLProject.Type
{
    public class CategoryQuery : ObjectGraphType
    {
        public CategoryQuery(ICategoryRepository CategoryRepository)
        {
            Field<ListGraphType<CategoryType>>("Categories").Resolve(context => {
                return CategoryRepository.GetAllCategories();
            });
        }
    }
}