using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class NameCheck : MonoBehaviour
{
    public string sceneToLoad = "GameScene";
    public Button playButton;
    public GameObject nameEnter;
    public static string playerName = null;
    public TextMeshProUGUI playerNameField;
        
    public void Play(){
        nameEnter.SetActive(true);
    }

    public void DoublePlay(){
        SceneManager.LoadScene(sceneToLoad);
    }

    void Start(){
        playButton.interactable = false;
    }

    public void Cansel(){
        nameEnter.SetActive(false);
    }

    public void NameEntered(){
        playerName = playerNameField.text.ToString();
        if (playerName != null)
        {
            playButton.interactable = true;
        }
    }
}
