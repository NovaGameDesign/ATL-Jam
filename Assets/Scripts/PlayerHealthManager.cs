using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    public float startingHealth = 100;
    private float _healthpoints;
    PlayerController playerController;
    public float rockDamageCooldown = 2;
    float rockDamageTImer;

    private void Update()
    {
        rockDamageTImer += Time.deltaTime;
    }

    private void Awake()
    {
        _healthpoints = startingHealth;
        playerController = this.gameObject.GetComponent<PlayerController>();
    }

    public bool TakeHit()
    {
        animator.SetTrigger("Flinch");
        _healthpoints -= 5;
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
        playerController.isDead = true;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy Bullet") && !this.tag.Equals("Attack Radius"))
        {
            TakeHit();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("Rock") && rockDamageTImer >= rockDamageCooldown)
        {
            TakeHit();
            rockDamageTImer = 0;
        }
    }
}