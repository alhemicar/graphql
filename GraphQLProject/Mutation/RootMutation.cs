using GraphQL.Types;
using GraphQLProject.Mutation;

namespace GraphQLProject.Type
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<MenuMutation>("menuMutation", resolve: context => new { });
            Field<ReservationMutation>("reservationMutation", resolve: context => new { });
            Field<CategoryMutation>("categoryMutation", resolve: context => new { });

        }
    }
}