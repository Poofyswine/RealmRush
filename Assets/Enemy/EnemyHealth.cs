using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int Health = 100;
    [SerializeField] int CurrentHealth = 0;
    [SerializeField] int DamageTaken = 10;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = Health;
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
            Destroy(gameObject);
        }
    }


}
