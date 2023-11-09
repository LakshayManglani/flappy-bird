using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Slider backgroundMusicSlider;

    public void Start()
    {
        OptionData optionData = SaveSystem.Load();
        backgroundMusic.volume = optionData.volume;
    }

    public void Update()
    {
        backgroundMusicSlider.onValueChanged.AddListener(delegate { backgroundMusic.volume = backgroundMusicSlider.value; });
    }

    public void Resume()
    {
        Time.timeScale = 1;
        backgroundMusic.UnPause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        backgroundMusic.Pause();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
