using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int Health = 1;

    [Tooltip("Add ammount to max hitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    
    [SerializeField] int KillReward = 100;

    int CurrentHealth = 0;

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
        CurrentHealth --;
        if (CurrentHealth <= 0)
        {
            enemyScript.RewardGold();
            Health += difficultyRamp;
            gameObject.SetActive(false);
        }
    }


}
