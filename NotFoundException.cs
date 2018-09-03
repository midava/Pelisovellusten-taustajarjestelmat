using System;
namespace Assignment_1
{
    public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
}