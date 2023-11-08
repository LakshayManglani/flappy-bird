using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static string path = Application.persistentDataPath + "/option.json";
    public static void Save(OptionMenu optionMenu)
    {
        OptionData optionData = new(optionMenu);
        File.WriteAllText(path, JsonUtility.ToJson(optionData));
    }

    public static OptionData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            OptionData optionData = JsonUtility.FromJson<OptionData>(json);
            return optionData;
        }

        Debug.LogError("File not found.");
        return null;
    }
}
