using UnityEngine;
public class Building : MonoBehaviour {

	public static Building instance;
	public GameObject upgradeEffect;
	
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

	private TowerPlatforms selectedNode;

	public TurretUI turretUI;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.price; } }
	
	public void SelectNode (TowerPlatforms node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		turretUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		turretUI.Hide();
	}

	public void SelectTurretToBuild (TurretsManager turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public TurretsManager GetTurretToBuild ()
	{
		return turretToBuild;
	}

}
