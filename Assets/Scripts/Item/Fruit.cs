using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Item
{
    [SerializeField] private int value = 5;

    public int Value { set => this.value = value; get => this.value; }

    public override void Collect()
    {
        base.Collect();
        GameManager.Instance.Score += value;
    }
}