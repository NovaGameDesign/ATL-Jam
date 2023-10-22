using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LashAbility : Item
{
    [Header("Lash Stats")]
    public float castRadius;
    public float maxDistance;
    private bool shouldCast;
    RaycastHit hit;
    public LayerMask layerToHit;
    public Transform raycastStart;

    private void Update()
    { 
        if (shouldCast)
        { 
            Debug.Log("Tried to raycast");
            if (Physics.SphereCast(raycastStart.position, castRadius, raycastStart.forward, out hit, maxDistance, layerToHit))
            {
                var lashPoint = hit.collider?.GetComponent<LashPoint>(); // Checks if the thing we hit is a lash point or not. 
                lashPoint?.movePoint();
            }
        }
   
    }
    public override void Useitem()
    {        
        shouldCast = true;
        StartCoroutine(waitFor(.25f));        
    }
    IEnumerator waitFor(float waitTime = 1)
    {
        yield return new WaitForSeconds(waitTime);
        shouldCast = false;
    }
}
