namespace MTOGO.Web.Exceptions;

public class MenuNotFoundException : Exception
{
    public MenuNotFoundException(long id) : base($"Menu with restaurant id {id} was not found.")
    {
    }
}