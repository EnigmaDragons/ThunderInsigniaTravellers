namespace ThunderInsigniaTravellers.Engine
{
    public interface IGame
    {
        T Load<T>(string resourceName);
    }
}
