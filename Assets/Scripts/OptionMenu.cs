using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Slider backgroundMusicSlider;

    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/option.data"))
        {
            Load();
        }
        else
        {
            Save();
        }
    }

    public void Save()
    {
        SaveSystem.Save(this);
    }

    public void Load()
    {
        OptionData optionData = SaveSystem.Load();
        backgroundMusicSlider.value = optionData.volume;
    }
}
