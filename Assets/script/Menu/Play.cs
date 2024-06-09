using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public string mainPlayLoad;
    public string Load2;
    public string Load3;
    public string Load4;
    public GameObject PlayWindows;
    public void MainPlay()
    {
        SceneManager.LoadScene(mainPlayLoad);
    }
    public void PLay2()
    {
        SceneManager.LoadScene(Load2);
    }
    public void Play3()
    {
        SceneManager.LoadScene(Load3);
    }
    public void Play4()
    {
        SceneManager.LoadScene(Load4);
    }
    public void ClosePlayWindow()
    {
        PlayWindows.SetActive(false);
    }
}