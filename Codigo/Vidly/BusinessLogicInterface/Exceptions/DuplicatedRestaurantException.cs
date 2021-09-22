using System;

namespace BusinessLogicInterface.Exceptions
{
    public class DuplicatedRestaurantException : Exception
    {
        public DuplicatedRestaurantException(string name) : base($"There is another restaurant with the name {name}") { }
    }
}