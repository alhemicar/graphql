using GraphQL.Types;

namespace GraphQLProject.Type
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<MenuQuery>("menuQuery", resolve: context => new { });
            Field<ReservationQuery>("reservationQuery", resolve: context => new { });
            Field<CategoryQuery>("categoryQuery", resolve: context => new { });

        }
    }
}