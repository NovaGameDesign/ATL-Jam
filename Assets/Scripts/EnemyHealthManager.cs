using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float weaponDamage;
    bool withinRadius;
    PlayerController playerController;
    [SerializeField] float damageCooldown = 1.5f;
    float currentTime = 0;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();

    }


    private void Update()
    {
        currentTime += Time.deltaTime;

        if (health <= 0)
        {
            //run animation

            //destroy this enemy
            Destroy(this.gameObject);

            
        }
        bool playerAttacking = playerController.getAttacking();

        

        if (withinRadius && playerAttacking && currentTime >= damageCooldown)
            StartCoroutine(takeDamage());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Sword"))
        {
            withinRadius = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Sword"))
        {
            withinRadius = false; ;
        }
    }

    IEnumerator takeDamage()
    {
        currentTime = 0;
        yield return new WaitForSeconds(damageCooldown);
        health -= weaponDamage;
        
    }
}
