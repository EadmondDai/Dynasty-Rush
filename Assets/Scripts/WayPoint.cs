using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable = false;
    public bool IsPlaceable { get { return isPlaceable; } }

    private Bank playerBank;

    private void Start()
    {
        playerBank = GameObject.FindObjectOfType<Bank>();
    }


    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Tower towObj = towerPrefab.CreateTower(towerPrefab, transform.position);
            playerBank.Withdraw(towObj.GoldNeed);
            isPlaceable = towObj == null;
        }   
    }
}
