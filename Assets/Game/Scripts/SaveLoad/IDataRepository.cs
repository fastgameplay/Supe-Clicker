namespace SupeClicker.Save
{
    public interface IDataRepository
    {
        void Save<T>(SaveKey key, T value);
        T Load<T>(SaveKey key, T defaultValue);
    }
}