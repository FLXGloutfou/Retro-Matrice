using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public string mainPlayLoad;
    public string protoypeLoad;
    public void MainPlay()
    {
        SceneManager.LoadScene(mainPlayLoad);
    }
    public void ProtoPlay()
    {
        SceneManager.LoadScene(protoypeLoad);
    }

}