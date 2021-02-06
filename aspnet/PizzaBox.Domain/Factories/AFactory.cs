namespace PizzaBox.Domain.Factories
{
    public interface AFactory<T> where T : class, new()
    {
        T Create();
    }
}