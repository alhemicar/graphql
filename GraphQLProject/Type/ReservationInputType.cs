using GraphQL.Types;

namespace GraphQLProject.Type
{
    public class ReservationInputType : InputObjectGraphType
    {
        public ReservationInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("email");
            Field<StringGraphType>("customerName");
            Field<IntGraphType>("partySize");
            Field<StringGraphType>("phoneNumber");
            Field<StringGraphType>("specialRequest");
            Field<DateGraphType>("reservationDate");
        }
    }
}