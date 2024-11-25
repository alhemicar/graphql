using System.ComponentModel;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
    public class MenuMutation: ObjectGraphType
    {
        public MenuMutation(IMenuRepository menuRepository)
        {
            Field<MenuType>("CreateMenu").Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context => {
                return menuRepository.AddMenu(context.GetArgument<Menu>("menu"));
            });

            Field<MenuType>("UpdateMenu").Arguments(
              new QueryArguments(
                  new QueryArgument<IntGraphType> { Name = "id" },
                  new QueryArgument<MenuInputType> { Name = "menu" }
              )
            ).Resolve(context => {
                return menuRepository.UpdateMenu(
                  context.GetArgument<int>("id"),
                  context.GetArgument<Menu>("menu")
                );
            });

            Field<StringGraphType>("DeleteMenu").Arguments(
              new QueryArgument<IntGraphType> { Name = "id" }).Resolve(context => {
                menuRepository.DeleteMenu(context.GetArgument<int>("id"));
                return "The menu item has been removed.";
            });
        }
    }
}