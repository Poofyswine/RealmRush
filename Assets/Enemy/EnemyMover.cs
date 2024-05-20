using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5)] float speed = 1f;

    Enemy enemyScript;
    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturntoStart();
        StartCoroutine(FollowPath());
    }

    void Start(){
        enemyScript = GetComponent<Enemy>();
    }

    void FindPath(){
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform){
            Waypoint waypointInChild = child.GetComponent<Waypoint>();
            if(waypointInChild != null){
                path.Add(waypointInChild);
            }
        }
    }

    void ReturntoStart(){
        transform.position = path[0].transform.position;
    }

    void FinishPath(){
        enemyScript.StealGold();
        gameObject.SetActive(false);
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
        
        FinishPath();
    }
}
