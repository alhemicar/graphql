using System.ComponentModel;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
    public class CategoryMutation: ObjectGraphType
    {
        public CategoryMutation(ICategoryRepository categoryRepository)
        {
            Field<CategoryType>("CreateCategory").Arguments(
              new QueryArguments(
                new QueryArgument<CategoryInputType> { Name = "category" })).Resolve(context => {
                return categoryRepository.AddCategory(context.GetArgument<Category>("category"));
            });

            Field<CategoryType>("UpdateCategory").Arguments(
              new QueryArguments(
                  new QueryArgument<IntGraphType> { Name = "id" },
                  new QueryArgument<CategoryInputType> { Name = "category" }
              )
            ).Resolve(context => {
                return categoryRepository.UpdateCategory(
                  context.GetArgument<int>("id"),
                  context.GetArgument<Category>("category")
                );
            });

            Field<StringGraphType>("DeleteCategory").Arguments(
              new QueryArgument<IntGraphType> { Name = "id" }).Resolve(context => {
                categoryRepository.DeleteCategory(context.GetArgument<int>("id"));
                return "The category item has been removed.";
            });
        }
    }
}