namespace WebStore.Exceptions
{
    public class NotFoundException(string message) : Exception(message);
    public class WrongCredentialsException(string message) : Exception(message);
}
