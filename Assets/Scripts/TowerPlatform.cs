using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlatforms : MonoBehaviour {
	
	public Color notMoneyColor;
	public Color changedColor;
	public Vector3 positionOffset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretsManager turretsManager;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color defaultColor;

	Building buildManager;

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	void Start ()
	{
		rend = GetComponent<Renderer>();
		defaultColor = rend.material.color;

		buildManager = Building.instance;
    }

	void OnMouseDown ()
	{		
		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;		
			BuildTurret(buildManager.GetTurretToBuild());	
	}

	void BuildTurret (TurretsManager _turretsManager)
	{
		if (PlayerStats.Money < _turretsManager.price)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		PlayerStats.Money -= _turretsManager.price;

		GameObject _turret = (GameObject)Instantiate(_turretsManager.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretsManager = _turretsManager;
		
		Debug.Log("Turret build!");
	}

	public void UpgradeTurret ()
	{
		if (PlayerStats.Money < turretsManager.upgradePrice)
		{
			Debug.Log("Not enough money to upgrade that!");
			return;
		}

		PlayerStats.Money -= turretsManager.upgradePrice;

		Destroy(turret);

		GameObject _turret = (GameObject)Instantiate(turretsManager.upgradePrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		GameObject effect = (GameObject)Instantiate(buildManager.upgradeEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 3f);

		isUpgraded = true;

		Debug.Log("Turret upgraded!");
	}

	public void SellTurret ()
	{
		PlayerStats.Money += turretsManager.GetSellPrice();

		Destroy(turret);
		turretsManager = null;
		isUpgraded = false;
	}

	void OnMouseEnter ()
	{
		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = changedColor;
		}
		else
		{
			rend.material.color = notMoneyColor;
		}		
	}

	void OnMouseExit ()
	{
		rend.material.color = defaultColor;
    }
}