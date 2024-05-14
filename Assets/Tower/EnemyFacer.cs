using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacer : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        weapon.transform.LookAt(target);
    }
}
