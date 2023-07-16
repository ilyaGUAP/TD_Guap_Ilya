using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject exitQu;    

    public void ExitFromGame(){
        exitQu.SetActive(true);
    }

    public void Yes(){
        Application.Quit();
    }

    public void No(){
        exitQu.SetActive(false);
    }
}

