using UnityEngine;
using System.Collections;
using TMPro;

public class MoneyUI : MonoBehaviour {

	public TextMeshProUGUI moneyText;

	void Update () {
		moneyText.text = "Money: " + PlayerStats.Money.ToString();
	}
}
