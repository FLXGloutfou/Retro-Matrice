using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject settingWindow;
    public GameObject playWindow;
    public void startgame()
    {
        playWindow.SetActive(true);
    }
    public void settingbutton()
    {
        settingWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingWindow.SetActive(false);
    }

    public void leavegame()
    {
        Application.Quit();
    }
}