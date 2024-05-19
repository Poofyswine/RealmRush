using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int Health = 100;
    [SerializeField] int CurrentHealth = 0;
    [SerializeField] int DamageTaken = 10;
    [SerializeField] int KillReward = 100;

    Enemy enemyScript;

    void OnEnable()
    {
        CurrentHealth = Health;
    }

    void Start(){
        enemyScript = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        CurrentHealth -= DamageTaken;
        if (CurrentHealth <= 0)
        {
            enemyScript.RewardGold();
            gameObject.SetActive(false);
        }
    }


}
