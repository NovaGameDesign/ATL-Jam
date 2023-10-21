using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
<<<<<<<< HEAD:Assets/Scripts/PlayerHealthManager.cs
    [SerializeField] Animator animator;

    private int _healthpoints;
========
    [SerializeField] float health;
    [SerializeField] float weaponDamage;
    bool withinRadius;
>>>>>>>> Earth:Assets/Scripts/EnemyManager.cs

    public void takeDamage(float amount)
    {
        if (withinRadius)
        {
            health -= amount;
        }   
    }

    private void Update()
    {
<<<<<<<< HEAD:Assets/Scripts/PlayerHealthManager.cs
        print("hit");
        
        //run flinch animation

        _healthpoints -= 10;
        bool isDead = _healthpoints <= 0;
        if (isDead) _Die();
        return isDead;
========
        if (health <= 0)
        {
            //run animation

            //destroy this enemy
            Destroy(this.gameObject);
        }
>>>>>>>> Earth:Assets/Scripts/EnemyManager.cs
    }

    private void OnTriggerEnter(Collider other)
    {
<<<<<<<< HEAD:Assets/Scripts/PlayerHealthManager.cs
        transform.Translate(new Vector3(0,-0.3f,0));
        print("you died");
        animator.SetBool("Dead", true);
        //Destroy(gameObject);
========
        if(other.tag.Equals("Attack Radius"))
        {
            withinRadius = true;
        }
        if (other.tag.Equals("Sword"))
        {
            takeDamage(weaponDamage);
        }
>>>>>>>> Earth:Assets/Scripts/EnemyManager.cs
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Attack Radius"))
        {
            withinRadius = false; ;
        }
    }
}
