using UnityEngine;

public class Shop : MonoBehaviour {

	Building buildManager;

	public TurretsManager simpleTurret;
	public TurretsManager missielTurret;

	void Start ()
	{
		buildManager = Building.instance;
	}

	public void SelectSimpleTurret ()
	{
		Debug.Log("Simple Turret Selected");
		buildManager.SelectTurretToBuild(simpleTurret);
	}

	public void SelectMissielTurret()
	{
		Debug.Log("missiel Turret Selected");
		buildManager.SelectTurretToBuild(missielTurret);
	}

}
