using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LashPoint : MonoBehaviour
{
    [SerializeField] Transform lerpPoint;
    private bool alreadyMoved = false;
    private bool moving;
    bool runeActivated;
    /// <summary>
    /// When true the item is static
    /// </summary>
    public bool isRune;

    [SerializeField] GameObject[] particles;
    [SerializeField] Gate gate;
    [SerializeField] AudioSource sfx;

    private void Update()
    {
        if(moving)
        {
            transform.position = Vector3.Lerp(transform.position, lerpPoint.position, Time.deltaTime);
           
            if (Vector3.Distance(transform.position, lerpPoint.position) < .25f)
            {
                moving = false;
            }
        }
    }

    public void activatePoint()
    {
        if(isRune)
        {
            if (!runeActivated)
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    particles[i].SetActive(true);
                }
                gate.ActivateRune();
                runeActivated = true;
                sfx.Play();
            }
            
        }
        else if(!alreadyMoved)
        {
            moving = true;            
            alreadyMoved = true;
        }
        
    }
}
