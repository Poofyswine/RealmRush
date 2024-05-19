using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isplaceable = false;
    [SerializeField] Tower towerPrefab;
    
    public bool Isplaceable{ get { return isplaceable; } }

    void OnMouseDown() {
        if(isplaceable){
        bool towerPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
        isplaceable = !towerPlaced;
        }
    }
}
