using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static string path = Application.persistentDataPath + "/option.data";
    public static void Save(OptionMenu optionMenu)
    {
        BinaryFormatter formatter = new();
        FileStream stream = new(path, FileMode.Create);

        OptionData optionData = new(optionMenu);

        formatter.Serialize(stream, optionData);

        stream.Close();
    }

    public static OptionData Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);
            OptionData optionData = formatter.Deserialize(stream) as OptionData;
            stream.Close();
            return optionData;
        }

        Debug.LogError("File not found.");
        return null;
    }
}
