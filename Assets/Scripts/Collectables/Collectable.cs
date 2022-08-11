using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using Random = UnityEngine.Random;

public class Collectable : MonoBehaviour
{
    [SerializeField] private IntVariable playerTotalMoney;
    [SerializeField] private IntVariable playerCollectedMoney;
    [SerializeField] private int moneyValue;
    [SerializeField] private CollectedSet collectedList;
    
     public int CoinID;
    
    public event Action<GameObject> OnCollected;

    private void Awake()
    {
        //if (collectedList.HasBeenCollected(CoinID))
        //{
        //    Debug.Log($"Destroying Coin with ID: {CoinID}");
        //    Destroy(gameObject);
        //}
    }

    public void Start()
    {
        if (collectedList.HasBeenCollected(CoinID))
        {
            Debug.Log($"Destroying Coin with ID: {CoinID}");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collected();
        }
    }

    private void Collected()
    {
        playerTotalMoney.AddValue(moneyValue);
        playerCollectedMoney.AddValue(moneyValue);
        collectedList.AddIDToCollected(CoinID);
        AudioManager.PlaySound("CoinSound1");
        OnCollected?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
