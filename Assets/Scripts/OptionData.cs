[System.Serializable]
public class OptionData
{
    public float volume;

    public OptionData(OptionMenu optionMenu)
    {
        volume = optionMenu.backgroundMusicSlider.value;
    }
}
