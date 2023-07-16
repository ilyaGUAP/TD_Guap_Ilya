using UnityEngine;
using System.Collections;
using TMPro;

public class MoneyUI : MonoBehaviour {

	public TextMeshProUGUI moneyText;

	void Start(){
		StartCoroutine(AddMoney());
	}

	void Update () {
		moneyText.text = "Money: " + PlayerStats.Money.ToString();
	}

	IEnumerator AddMoney()
    {
        while (true)
        {
            PlayerStats.Money += 2;
            yield return new WaitForSeconds(1f);
        }
    }
}
