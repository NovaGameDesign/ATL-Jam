using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    private int _healthpoints;

    private void Awake()
    {
        _healthpoints = 30;
    }

    public bool TakeHit()
    {
        print("hit");
        
        //run flinch animation

        _healthpoints -= 10;
        bool isDead = _healthpoints <= 0;
        if (isDead) _Die();
        return isDead;
    }

    private void _Die()
    {
        transform.Translate(new Vector3(0,-0.3f,0));
        print("you died");
        animator.SetBool("Dead", true);
        //Destroy(gameObject);
    }
}