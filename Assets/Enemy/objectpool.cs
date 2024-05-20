using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpool : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] [Range(0.1f, 30f)] float TimeToWait = 1f;
    [SerializeField] [Range(0, 50)] int poolSize = 5;

    GameObject[] pool;
    
    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++){
            pool[i] = Instantiate(Enemy, transform);
            pool[i].SetActive(false);
        }
    }

        void EnableObjectInPool()
    {
        foreach(GameObject gameObject in pool){
            if(gameObject.activeInHierarchy == false){
            gameObject.SetActive(true);
            return;
            }
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemyxSecconds());
    }

    IEnumerator SpawnEnemyxSecconds(){
        while(true){
            EnableObjectInPool();
            yield return new WaitForSeconds(TimeToWait);
        }
    }


}
