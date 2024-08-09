namespace SupeClicker.Save
{
    using UnityEngine;
    public class PlayerPrefsRepository : IDataRepository
    {
        public void Save<T>(SaveKey key, T value)
        {
            string stringValue = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key.ToString(), stringValue);
        }

        public T Load<T>(SaveKey key, T defaultValue)
        {
            string stringValue = PlayerPrefs.GetString(key.ToString(), null);
            if (string.IsNullOrEmpty(stringValue))
                return defaultValue;

            return JsonUtility.FromJson<T>(stringValue);
        }
    }
}