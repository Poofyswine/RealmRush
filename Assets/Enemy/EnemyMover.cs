using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5)] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        ReturntoStart();
        StartCoroutine(FollowPath());

    }

    void FindPath(){
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypoint in waypoints){
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void ReturntoStart(){
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath(){
        foreach(Waypoint waypoint in path){
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0;

            transform.LookAt(endPosition);

            while(travelPercent < 1){
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        Destroy(gameObject);
    }
}
