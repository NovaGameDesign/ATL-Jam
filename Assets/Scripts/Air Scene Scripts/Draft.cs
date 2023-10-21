using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Draft : MonoBehaviour
{
    [Header("Draft Settings")]
    [SerializeField] float draftStrength;
    [SerializeField] float draftDist;
    [Header("Draft Collider")]
    [SerializeField] Collider collider;

    [Header("Player Components")]
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody rb_player;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.BoxCast(collider.bounds.center, transform.localScale/2, transform.up, out hit, transform.rotation, draftDist))
        {
            if (hit.collider.gameObject == player)
            {
                rb_player.AddForce(transform.up*draftStrength);
                playerController.EnableGlide();
            }
        }
    }
}
