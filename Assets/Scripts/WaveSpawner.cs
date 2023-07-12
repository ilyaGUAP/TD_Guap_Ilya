using UnityEngine;

public class WaveSpawner : MonoBehaviour{

    public Transform cubePrefab;

    public Transform spherePrefab;

    public Transform cilinderPrefab;

    public float timeBetweenWaves = 60f;

    public float timeBetweenSpawns = 2f;

    public int waveNumber = 1;
    
    private float countDownForWaves = 10f;

    private float countDownForSpawns = 2f;

    private int cube = 0;

    private int sphere = 0;

    private int cilinder = 0;

    void Update (){
        if (countDownForWaves <= 0f){
            SpawnWave();
            countDownForWaves = timeBetweenWaves;             
        }
        countDownForWaves -= Time.deltaTime;
    }

    void SpawnWave(){

        NumberOfEnemys();
        SpawnEnemys();
        waveNumber++;
    }

    void NumberOfEnemys(){
        switch (waveNumber){
            case 1:
                cube = 3;
                sphere = -1;
                cilinder = -1;
                break;
            case 2:
                cube = 4;
                sphere = 1;
                cilinder = -1;
                break;
            case 3:
                cube = 5;
                sphere = 2;
                cilinder = -1;
                break;
            case 4:
                cube = 4;
                sphere = 3;
                cilinder = 1;
                break;
            case 5:
                cube = 3;
                sphere = 3;
                cilinder = 3;
                break;
            case 6:
                cube = 5;
                sphere = 5;
                cilinder = 3;
                break;            
            case 7:
                cube = 6;
                sphere = 6;
                cilinder = 3;
                break;
            case 8:
                cube = 10;
                sphere = 1;
                cilinder = 2;
                break;
            case 9:
                cube = 8;
                sphere = 8;
                cilinder = 8;
                break;
        }
    }

    void SpawnEnemys(){
        int cu = 0;
        int sph = 0;
        int cl = 0;
        int numBefore = 0;
        int numAfter = 0;

        while (true)
        {

            if (countDownForSpawns <= 0f)
            {
                numBefore = numAfter;
                if (cu < cube){
                    Instantiate(cubePrefab);
                    cu++;
                    numAfter++;
                }
                    if (cl < cilinder){
                    Instantiate(cilinderPrefab);
                    cl++;
                    numAfter++;
                }
                    if (sph < sphere){
                    Instantiate(spherePrefab);
                    sph++;
                    numAfter++;
                }
                if (numBefore == numAfter){
                    break;
                }
                countDownForSpawns = timeBetweenSpawns;                
            }
            countDownForSpawns -= Time.deltaTime;
        }
    }
}
