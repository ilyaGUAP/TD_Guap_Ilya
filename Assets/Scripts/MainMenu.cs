using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "GameScene";

	public void Play ()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void Exit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

}
