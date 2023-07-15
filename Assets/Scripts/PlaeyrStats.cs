using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;
	public static int score;

	void Start ()
	{
		score = 0;
		Money = startMoney;
	}

}
