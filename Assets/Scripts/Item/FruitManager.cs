using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    private void Start()
    {
        int totalScore = 0;
        for (var i = 0; i < transform.childCount; i++)
        {
            totalScore += transform.GetChild(i).GetComponent<Fruit>().Value;
        }

        GameManager.Instance.TotalScore = totalScore;
    }
}