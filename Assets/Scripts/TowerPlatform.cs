using UnityEngine;
using UnityEngine.EventSystems;

public class TowePlatforms : MonoBehaviour {

	public Color changedColor;
	public Vector3 positionOffset;
	private GameObject turret;
	private Renderer rend;
	private Color defaultColor;

	Building buildManager;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		defaultColor = rend.material.color;

		buildManager = Building.instance;
    }

	void OnMouseDown ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (buildManager.GetTurretToBuild() == null)
			return;

		if (turret != null)
		{
			Debug.Log("You Can't build there!");
			return;
		}
		
		GameObject turretToBuild = buildManager.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	void OnMouseEnter ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (buildManager.GetTurretToBuild() == null)
			return;

		rend.material.color = changedColor;
	}

	void OnMouseExit ()
	{
		rend.material.color = defaultColor;
    }
}