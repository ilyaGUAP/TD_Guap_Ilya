using UnityEngine;

public class TowerPlatform : MonoBehaviour {

	public Color changedColor;
	public Vector3 positionOffset;

	private GameObject turret;

	private Renderer rend;
	private Color defaultColor;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		defaultColor = rend.material.color;
    }

	void OnMouseDown ()
	{
		if (turret != null)
		{
			Debug.Log("Can't build there!");
			return;
		}

		GameObject turretToBuild = Building.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
	}

	void OnMouseEnter ()
	{
		rend.material.color = changedColor;
	}

	void OnMouseExit ()
	{
		rend.material.color = defaultColor;
    }

}
