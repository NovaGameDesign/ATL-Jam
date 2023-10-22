using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlant : Item
{

    public PlayerHealthManager playerHealth;

    public override void Useitem()
    {
        playerHealth.IncreaseHealth(15);
    }
}
