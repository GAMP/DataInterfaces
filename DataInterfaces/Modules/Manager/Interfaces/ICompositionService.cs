namespace Manager.Services
{
    public interface ICompositionService
    {
        T GetExportedValue<T>();
    }
}