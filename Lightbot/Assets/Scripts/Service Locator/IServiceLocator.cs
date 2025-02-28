namespace Service_Locator
{
    public interface IServiceLocator
    {
        void RegisterService<T>(T service);
        T GetService<T>();
    }
}