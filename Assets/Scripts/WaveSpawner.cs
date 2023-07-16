using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour{

    public Transform cubePrefab;
    public Transform spherePrefab;
    public Transform cilinderPrefab;
    public float timeBetweenWaves = 60f;    
    public int waveNumber = 0;    
    private float countDownForWaves = 10f;    
    private int cube = 0;
    private int sphere = 0;
    private int cilinder = 0;
    public TextMeshProUGUI waveCountDownText;
    public TextMeshProUGUI waveNumberText;

    void Update (){
        waveNumberText.text = "Wave number: " + waveNumber.ToString();
        if (countDownForWaves <= 0f){
            PlayerStats.score += 100;
            SpawnWave();
            countDownForWaves = timeBetweenWaves;             
        }
        countDownForWaves -= Time.deltaTime;
        waveCountDownText.text = "Next wave: " + Mathf.Floor(countDownForWaves).ToString();
    }

    void SpawnWave(){
        waveNumber++;
        NumberOfEnemys();
        StartCoroutine(SpawnEnemys());
    }

    void NumberOfEnemys(){
        switch (waveNumber){
            case 1:
                cube = 3;
                sphere = 0;
                cilinder = 0;
                break;
            case 2:
                cube = 4;
                sphere = 1;
                cilinder = 0;
                break;
            case 3:
                cube = 5;
                sphere = 2;
                cilinder = 0;
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
            yield return new WaitForSeconds(2f);
        }
    }
}
