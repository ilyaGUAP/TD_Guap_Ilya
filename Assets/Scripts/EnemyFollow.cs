using UnityEngine;
using PathCreation;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    public PathCreator pathCreator;
    private float distanceTravelled;
    private float speed;
    public float startSpeed = 5;
    public float startHealth = 100; 
    private float health;
    public int reward = 50;
    public int damage = 1;
    public int scoreReward = 3;
    public Image healthBar;
    public EndOfPathInstruction Stop;
    private Transform gameCam;
    public Transform partToRotate;

    void Start ()
	{
		speed = startSpeed;
		health = startHealth;
        gameCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}    

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, Stop);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, Stop);
        if (distanceTravelled >= 269){
            EndPath();
        }
        partToRotate.transform.LookAt(gameCam);
    }

    public void TakeDamage (int amount)
	{
		health -= amount;
        healthBar.fillAmount = health / startHealth;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		PlayerStats.Money += reward;
        PlayerStats.score += scoreReward;

		Destroy(gameObject);
	}

    void EndPath (){
        PlayerStats.Lives -= damage;
        Destroy(gameObject);
    }
}
