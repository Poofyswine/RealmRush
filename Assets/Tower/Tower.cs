using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    [SerializeField] int TowerCost = 150;
    Bank bankScript;

    public bool CreateTower(Tower towerPrefab, Vector3 tilePosition){
        bankScript = FindObjectOfType<Bank>();
        
        if(bankScript == null){
            return false;
        }

        if(bankScript.CheckBalance >= TowerCost){
            bankScript.RemoveMoney(TowerCost);
            Instantiate(towerPrefab, tilePosition, Quaternion.identity);
            return true;
        }
        return false;

    }
}
