using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 3;
    [SerializeField] float avoidRadius;
    [SerializeField] float shootRadius;
    [SerializeField] GameObject enemyShotPrefab;
    [SerializeField] Transform shotLoc;
    [SerializeField] float shotCooldown;
    float shotTImer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        shotTImer += Time.deltaTime;


        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            transform.LookAt(player.transform);

            if (Vector3.Distance(this.transform.position, player.transform.position) >= avoidRadius)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position + new Vector3(0f,1.5f,0f) , speed * Time.deltaTime);
            }

            if (Vector3.Distance(this.transform.position, player.transform.position) <= shootRadius)
            {
                if(shotTImer >= shotCooldown)
                {
                    if(Random.value > .7)
                    {
                        shotTImer = 0;
                        shoot();
                    }


                    
                }
            }


        }
    }


    void shoot()
    {
        GameObject bullet = Instantiate(enemyShotPrefab, shotLoc.position ,shotLoc.rotation);
    }

}
