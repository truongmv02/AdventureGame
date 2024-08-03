using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Item
{
    [SerializeField] private float time = 30f;

    public float Time { set => this.time = value; get => this.time; }

    public override void Collect()
    {
        base.Collect();
        GameManager.Instance.Timer += time;
    }
}