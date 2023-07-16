using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuFromGameScene : MonoBehaviour
{
    public GameObject qw;
    public string sceneToLoad = "MenuScene";

    public void Menu(){
        qw.SetActive(true);
    }

    public void Yes(){
        SceneManager.LoadScene(sceneToLoad);
    }

    public void No(){
        qw.SetActive(false);
    }
}
