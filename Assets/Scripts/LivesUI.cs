using UnityEngine;
using System.Collections;
using TMPro;

public class LivesUI : MonoBehaviour {

	public TextMeshProUGUI livesText;

	void Update () {
		livesText.text = "Lives: " + PlayerStats.Lives.ToString() + "\t";
	}
}
