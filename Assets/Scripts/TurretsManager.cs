using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretsManager {    
    public GameObject prefab;
	public int price;
    public int upgradePrice;
    public GameObject upgradePrefab;
  
    public int GetSellPrice(){
        return price / 2;
    }
}
