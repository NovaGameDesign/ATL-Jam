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
            //check for if trophy state is playing
            //if (trophy state == not playing)
            //{
                //call fail state  
            //}
            //if triphy state is playing do nothing
        }
    }

}
