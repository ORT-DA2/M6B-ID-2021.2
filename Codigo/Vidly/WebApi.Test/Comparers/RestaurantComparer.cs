using System.Collections;
using Domain;

namespace WebApi.Test.Comparers
{
    public class RestaurantComparer : BaseComparer<Restaurant>
    {
        protected override bool ConcreteCompare(Restaurant expected, Restaurant actual)
        {
            bool equalsRestaurant = expected.Name == actual.Name;
            equalsRestaurant &= expected.Address == actual.Address;

            return equalsRestaurant;
        }
    }
}