using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    public float startingHealth = 100;
    private float _healthpoints;


    private void Awake()
    {
        _healthpoints = startingHealth;
    }

    public bool TakeHit()
    {
        animator.SetTrigger("Flinch");
        _healthpoints -= 10;
        bool isDead = _healthpoints <= 0;
        if (isDead) 
            _Die();
        return isDead;
    }

    private void _Die()
    {
        transform.Translate(new Vector3(0, -0.3f, 0));
        print("you died");
        animator.SetBool("Dead", true);
        //Destroy(gameObject);
    }

    public void IncreaseHealth(float heal)
    {
        _healthpoints += heal;
        if(_healthpoints > startingHealth)
        {
            _healthpoints = startingHealth;
        }
    }
}