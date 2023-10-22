using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float weaponDamage;
    bool withinRadius;
    PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void takeDamage(float amount)
    {
        if (withinRadius)
        {
            health -= amount;
        }   
    }

    private void Update()
    {
        if (health <= 0)
        {
            //run animation

            //destroy this enemy
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Attack Radius"))
        {
            withinRadius = true;
        }
        if (other.tag.Equals("Sword"))
        {
            takeDamage(weaponDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Attack Radius"))
        {
            withinRadius = false; ;
        }
    }
}
