using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string recToLoad = "RecordScene";


	public void Records(){
		SceneManager.LoadScene(recToLoad);
	}

}
