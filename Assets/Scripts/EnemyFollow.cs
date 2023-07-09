using UnityEngine;
using PathCreation;

public class EnemyFollow : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public EndOfPathInstruction Stop;
    
    float distanceTravelled;

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, Stop);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, Stop);
        if (distanceTravelled >= 269){
            Destroy(gameObject);
        }
    }
}
