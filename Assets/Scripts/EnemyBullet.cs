using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float timeToExist;
    float airTIme;
    
    void Update()
    {
        airTIme += Time.deltaTime;

        if(airTIme > timeToExist)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
    }
}
