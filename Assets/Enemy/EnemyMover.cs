using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waittime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(printWaypointNames());

    }

    IEnumerator printWaypointNames(){
        foreach(Waypoint waypoint in path){
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waittime);
        }
    }
}
