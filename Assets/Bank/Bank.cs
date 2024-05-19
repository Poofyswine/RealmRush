using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bank : MonoBehaviour
{

    [SerializeField] int startingAmmount = 150;
    [SerializeField] int currentAmmount;

    void Awake(){
        currentAmmount = startingAmmount;
    }

    public void AddMoney(int Ammount){
        currentAmmount += Mathf.Abs(Ammount);
    }

    public void RemoveMoney(int Ammount){
        currentAmmount -= Mathf.Abs(Ammount);
    }

    public int CheckBalance{ get { return currentAmmount; } }
}
