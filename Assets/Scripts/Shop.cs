using UnityEngine;

public class Shop : MonoBehaviour {

	Building buildManager;

	void Start ()
	{
		buildManager = Building.instance;
	}

	public void PurchaseSimpleTurret ()
	{
		Debug.Log("Simple Turret Selected");
		buildManager.SetTurretToBuild(buildManager.simpleTurretPrefab);
	}

	public void PurchaseMissielTurret()
	{
		Debug.Log("missiel Turret Selected");
		buildManager.SetTurretToBuild(buildManager.missielTurretPrefab);
	}

}
