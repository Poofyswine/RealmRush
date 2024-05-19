using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isplaceable = false;
    [SerializeField] GameObject balista;
    [SerializeField] int PlacementCost = 200;
    
    Bank bankScript;

    void Start(){
        bankScript = FindObjectOfType<Bank>();
    }
    public bool Isplaceable{ get { return isplaceable; } }

    void OnMouseDown() {
        if(isplaceable){
            if(bankScript.CheckBalance >= PlacementCost){
                bankScript.RemoveMoney(PlacementCost);
                Instantiate(balista, transform.position, Quaternion.identity);
                isplaceable = false;
            }
        }
    }
}
