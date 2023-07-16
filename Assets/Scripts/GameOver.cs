using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	
	public string sceneToLoad = "MenuScene";	

	public void Menu ()
	{
		SceneManager.LoadScene(sceneToLoad);
	}

}
