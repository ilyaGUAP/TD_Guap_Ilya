using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour{

    public Transform cubePrefab;
    public Transform spherePrefab;
    public Transform cilinderPrefab;
    public float timeBetweenWaves = 60f;    
    public static int waveNumber = 0; 
    public int startWaveNumber = 0;   
    private float countDownForWaves = 10f;    
    private int cube = 0;
    private int sphere = 0;
    private int cilinder = 0;
    public TextMeshProUGUI waveCountDownText;
    public TextMeshProUGUI waveNumberText;
    public static bool winDetect = false;
    public static int countOfEnemys = 0;    

    void Start(){
        waveNumber = startWaveNumber;
        waveNumberText.text = "Wave number: " + waveNumber.ToString();
    }

    void Update (){
        if (waveNumber > 9)
        {
            waveCountDownText.text = "Final wave";
            if (countOfEnemys == 0)
            {
                winDetect = true;
            }
        }
        else
        {
            if (countDownForWaves <= 0f){
                waveNumberText.text = "Wave number: " + waveNumber.ToString();
                PlayerStats.score += 100;                
                SpawnWave();
                waveNumber++;            
                countDownForWaves = timeBetweenWaves;                        
            }        
            countDownForWaves -= Time.deltaTime;
            waveCountDownText.text = "Next wave: " + Mathf.Floor(countDownForWaves).ToString();
        }        
    }

    void SpawnWave(){
        NumberOfEnemys();
        StartCoroutine(SpawnEnemys());       
    }

    void NumberOfEnemys(){
        switch (waveNumber){
            case 1:
                cube = 6;
                sphere = 0;
                cilinder = 0;
                EnemyFollow.healthFactor = 1.0f;
                break;
            case 2:
                cube = 5;
                sphere = 2;
                cilinder = 0;
                EnemyFollow.healthFactor = 1.0f;
                break;
            case 3:
                cube = 6;
                sphere = 3;
                cilinder = 1;
                EnemyFollow.healthFactor = 1.2f;
                break;
            case 4:
                cube = 10;
                sphere = 6;
                cilinder = 3;
                EnemyFollow.healthFactor = 1.2f;
                break;
            case 5:
                cube = 7;
                sphere = 7;
                cilinder = 5;
                EnemyFollow.healthFactor = 1.5f;
                break;
            case 6:
                cube = 4;
                sphere = 10;
                cilinder = 8;
                EnemyFollow.healthFactor = 1.5f;
                break;            
            case 7:
                cube = 10;
                sphere = 10;
                cilinder = 10;
                EnemyFollow.healthFactor = 1.5f;
                break;
            case 8:
                cube = 12;
                sphere = 12;
                cilinder = 12;
                EnemyFollow.healthFactor = 2.0f;
                break;
            case 9:
                cube = 15;
                sphere = 15;
                cilinder = 15;
                EnemyFollow.healthFactor = 2.0f;                
                break;
            default:
                cube = 0;
                sphere = 0;
                cilinder = 0;                
                break;
        }
    }

    IEnumerator SpawnEnemys(){
        int cu = 0;
        int sph = 0;
        int cl = 0;
        int numBefore = 0;
        int numAfter = 0;

        while (true)
        {
            numBefore = numAfter;
            if (cu < cube){
                Instantiate(cubePrefab);
                cu++;
                numAfter++;
                countOfEnemys++;                
            }
                if (cl < cilinder){
                Instantiate(cilinderPrefab);
                cl++;
                numAfter++;
                countOfEnemys++;
            }
                if (sph < sphere){
                Instantiate(spherePrefab);
                sph++;
                numAfter++;
                countOfEnemys++;
            }
            if (numBefore == numAfter){
                break;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
