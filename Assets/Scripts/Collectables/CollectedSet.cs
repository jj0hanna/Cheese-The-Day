using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new CollectedSet", menuName = "Sets")]
public class CollectedSet : ScriptableObject
{
    [SerializeField] private List<int> CollectedIDs;

    private void OnEnable()
    {
        ClearIDs();
    }

    public void AddIDToCollected(int value)
    {
        CollectedIDs.Add(value);
    }

    public bool HasBeenCollected(int value)
    {
        foreach (int ID in CollectedIDs)
        {
            if (ID == value)
            {
                return true;
            }
        }

        return false;
    }
    
    public void ClearIDs()
    {
        CollectedIDs = new List<int>();
    }
}
