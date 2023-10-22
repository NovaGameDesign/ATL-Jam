using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LashPoint : MonoBehaviour
{
    [SerializeField] Transform lerpPoint;
    private bool alreadyMoved = false;
    private bool moving;
    private float progress;

    private void Update()
    {
        if(moving)
        {
            transform.position = Vector3.Lerp(transform.position, lerpPoint.position, progress);
            progress += .001f;

            if (Vector3.Distance(transform.position, lerpPoint.position) < .25f)
            {
                moving = false;
            }
        }
    }
    public void movePoint()
    {
        if(!alreadyMoved)
        {
            moving = true;            
            alreadyMoved = true;
        }
        
    }
}
