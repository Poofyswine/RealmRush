using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isplaceable = false;

    [SerializeField] GameObject balista;
    public bool Isplaceable{ get { return isplaceable; } }

    void OnMouseDown() {
        if(isplaceable){
            Instantiate(balista, transform.position, Quaternion.identity);
            isplaceable = false;
        }
    }
}
