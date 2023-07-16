using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	

	public string sceneToLoad = "GameScene";
	public string recToLoad = "RecordScene";	

	public void Play ()
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	public void Records(){
		SceneManager.LoadScene(recToLoad);
	}

}
