using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RebelHavoc
{
    [System.Serializable]
    public class PlayerData
    {
        public string position; // This is a vector3 string format
    }

    [System.Serializable]

    public class SaveGameManager
    {
        public static SaveGameManager instance = null;

        private SaveGameManager() {}

        public static SaveGameManager Instance()
        {
            return instance ??= new SaveGameManager();
        }

        // Method to SaveGame

        public void SaveGame(Transform playerTransform)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            var file = File.Create(Application.persistentDataPath + "/SaveData.txt");
            PlayerData data = new PlayerData 
            {
                 position = JsonUtility.ToJson(playerTransform)
            };

            formatter.Serialize(file, data);
            file.Close();
            Debug.Log("Data was save at" + Application.persistentDataPath);
        }

        // Method to LoadGame

        public PlayerData LoadGame()
        {
            string path = Application.persistentDataPath + "/SaveData.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                PlayerData data = formatter.Deserialize(file) as PlayerData;
                file.Close();
                return data;
            }
            return null;
        }
    }
}
