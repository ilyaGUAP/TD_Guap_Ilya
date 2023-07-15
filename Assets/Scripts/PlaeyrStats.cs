using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;
	public static int score;
	public static int Lives;
	public int startLives = 20;

	void Start ()
	{
		Lives = startLives;
		score = 0;
		Money = startMoney;
	}

}
