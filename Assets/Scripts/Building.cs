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

	private TurretsManager turretToBuild;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.price; } }

	public void BuildTurretOn (TowePlatforms towerPlatform){
		if (PlayerStats.Money < turretToBuild.price)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		PlayerStats.Money -= turretToBuild.price;

		GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, towerPlatform.GetBuildPosition(), Quaternion.identity);
		towerPlatform.turret = turret;

		Debug.Log("Turret build! Money left: " + PlayerStats.Money);
	}

	public void SelectTurretToBuild (TurretsManager turret)
	{
		turretToBuild = turret;
	}

}
