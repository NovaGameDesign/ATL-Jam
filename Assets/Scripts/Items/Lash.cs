using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lash : Item
{
    public float castRadius;
    public override void Useitem()
    {
        Debug.Log("Tried to raycast");

        if(Physics.SphereCast(transform.position, castRadius, transform.forward * 10f, out RaycastHit hitInfo, 10))
        {
            //hitInfo
        }
    }
}
