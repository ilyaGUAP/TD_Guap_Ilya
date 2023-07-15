using UnityEngine;
public class Building : MonoBehaviour {
	public static Building instance;
	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one ''Building'' in scene!");
			return;
		}
		instance = this;
	}

	public GameObject simpleTurretPrefab;
	
	public GameObject missielTurretPrefab;

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild ()
	{
		return turretToBuild;
	}

	public void SetTurretToBuild (GameObject turret)
	{
		turretToBuild = turret;
	}

}
