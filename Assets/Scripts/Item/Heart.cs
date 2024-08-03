using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{

    public override void Collect()
    {
        base.Collect();
        GameManager.Instance.Character.Health.Heal(1);
    }
}