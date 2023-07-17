using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RecordManager : MonoBehaviour
{
    public TextMeshProUGUI recordsField;
    public string sceneToLoad = "MenuScene";

    void Start(){

        int count = 0;
		string lastKey;
		string key = "0";
        string recPlayerName = null;
        string recKey;

		do
		{	
			lastKey = key;	
			count++;
			key = count.ToString();
		} while (PlayerPrefs.HasKey(key));

        for (int i = 0; i < count; i++)
        {
            recKey = i.ToString();
            recPlayerName = PlayerPrefs.GetString(recKey);
            recordsField.text += "\n" + recPlayerName + " " + PlayerPrefs.GetInt(recPlayerName).ToString();
        }
    }

    public void Menu(){
        SceneManager.LoadScene(sceneToLoad);
    }

    public void DelRec(){
        PlayerPrefs.DeleteAll();
    }
}
