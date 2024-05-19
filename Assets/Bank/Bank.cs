using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{

    [SerializeField] int startingAmmount = 150;
    [SerializeField] int currentAmmount;

    [SerializeField] TextMeshProUGUI tmPro;

    void Awake(){
        currentAmmount = startingAmmount;
        UpdateDisplay();
    }

    public void AddMoney(int Ammount){
        currentAmmount += Mathf.Abs(Ammount);
        UpdateDisplay();
    }

    public void RemoveMoney(int Ammount){
        currentAmmount -= Mathf.Abs(Ammount);
        UpdateDisplay();
        if(currentAmmount < 0 )
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public int CheckBalance{ get { return currentAmmount; } }

    void UpdateDisplay(){
        tmPro.text = $"Gold: {currentAmmount}";
    }
}
