using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {

	private Transform target;    
	public float range = 5f;
	public float reload = 1f;
	public float turnSpeed = 10f;
	private float reloadCountdown = 0f;

	public string enemyTag = "Enemy";

	public Transform partToRotate;

	public GameObject bulletPrefab;	
	public Transform firePoint;
	
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		} else
		{
			target = null;
		}

	}
	
	void Update () {
		if (target == null)
			return;		
        
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (rotation.x, rotation.y, 0f);
		
		if (reloadCountdown <= 0f){
			Shoot();
			reloadCountdown = reload;
		}
		reloadCountdown -= Time.deltaTime; 
	}

	void Shoot(){
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seeking(target);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}