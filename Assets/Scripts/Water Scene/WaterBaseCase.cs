using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBaseCase : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject trophy;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHealthManager>().TakeHit(1000);
        }
    }

}
