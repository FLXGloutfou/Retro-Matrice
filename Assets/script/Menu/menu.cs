using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject playWindow;
    public GameObject settingWindow;
    public void startgame()
    {
        Debug.Log("oui");
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