using UnityEngine;
using UnityEngine.EventSystems;

public class TowePlatforms : MonoBehaviour {
	
	public Color notMoneyColor;
	public Color changedColor;
	public Vector3 positionOffset;
	public GameObject turret;
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
		if (!buildManager.CanBuild)
			return;

		if (turret != null)
		{
			Debug.Log("You Can't build there!");
			return;
		}		
		buildManager.BuildTurretOn(this);
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