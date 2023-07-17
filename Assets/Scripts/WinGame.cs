using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//using UnityEngine.CoreModule;

public class WinGame : MonoBehaviour {

	public TextMeshProUGUI scoreText;
	public string sceneToLoad = "MenuScene";	

	void OnEnable ()
	{
		scoreText.text = PlayerStats.score.ToString();
	}

	public void Menu ()
	{
		int count = 0;
		string lastKey;
		string key = "0";

		if (NameCheck.playerName != null)
		{
			do
			{	
				lastKey = key;	
				count++;
				key = count.ToString();
			} while (PlayerPrefs.HasKey(key));

			if (lastKey == "0" )
			{
				PlayerPrefs.SetString("1", NameCheck.playerName);
			}
			else
			{
				PlayerPrefs.SetString(key, NameCheck.playerName);
			}

			PlayerPrefs.SetInt(NameCheck.playerName, PlayerStats.score);
		}
		PlayerPrefs.Save();		

		SceneManager.LoadScene(sceneToLoad);
	}	
}
