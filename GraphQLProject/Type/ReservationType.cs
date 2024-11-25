using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type
{
    public class ReservationType : ObjectGraphType<Reservation>
    {
        public ReservationType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Email);
            Field(x => x.CustomerName);
            Field(x => x.PartySize);
            Field(x => x.PhoneNumber);
            Field(x => x.SpecialRequest);
            Field(x => x.ReservationDate);
        }
    }
}