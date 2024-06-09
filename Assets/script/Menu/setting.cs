using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class setting : MonoBehaviour
{
    public string Menue;
    public AudioMixer audioMixer;
    public GameObject settingWindow;

    public Hero hero;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void CloseSettingsWindow()
    {
        settingWindow.SetActive(false);
    }

    public void Return()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Menue);
    }
}