using UnityEngine;

public class Building : MonoBehaviour {

	public static Building instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("too much BildingManagers !");
			return;
		}
		instance = this;
	}

	public GameObject correctTurretPrefab;

	void Start ()
	{
		turretToBuild = correctTurretPrefab;
	}

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild ()
	{
		return turretToBuild;
	}

}
