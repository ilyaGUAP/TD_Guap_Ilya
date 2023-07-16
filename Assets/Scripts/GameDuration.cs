using UnityEngine;

public class GameDuration : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUILoos;
	public GameObject gameOverUIWin;

	void Start ()
	{
		GameIsOver = false;
	}

	void Update () {
		if (GameIsOver)
			return;

		if (WaveSpawner.winDetect){
			EndGameWin();
		}
		if (PlayerStats.Lives <= 0){
			EndGameLoos();
		}
	}

	void EndGameWin ()
	{
		GameIsOver = true;		
		gameOverUIWin.SetActive(true);
	}

	void EndGameLoos ()
	{
		GameIsOver = true;		
		gameOverUILoos.SetActive(true);
	}

}
