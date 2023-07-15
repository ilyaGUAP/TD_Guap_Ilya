using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public TextMeshProUGUI scoreText;

	void OnEnable ()
	{
		scoreText.text = PlayerStats.score.ToString();
	}

	public void Menu ()
	{
		Debug.Log("Go to menu.");
	}

}
