using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int KillReward = 50;
    [SerializeField] int GoldPenality = 200;

    Bank bankScript;
    // Start is called before the first frame update
    void Start(){
        bankScript = FindObjectOfType<Bank>();
    }

    public void RewardGold() {
        if(bankScript == null){ return; }
        bankScript.AddMoney(KillReward);
    }

    public void StealGold() {
        if(bankScript == null){ return; }
        bankScript.RemoveMoney(GoldPenality);
    }
}
