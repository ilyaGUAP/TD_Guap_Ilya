using UnityEngine;
using PathCreation;

public class EnemyFollow : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5; 
    public int health = 100;
    public int reward = 50;
    public int damage = 1;
    public int scoreReward = 3;
    public EndOfPathInstruction Stop;
    float distanceTravelled;

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, Stop);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, Stop);
        if (distanceTravelled >= 269){
            EndPath();
        }
    }

    public void TakeDamage (int amount)
	{
		health -= amount;

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
