using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] GameObject textCanvas;
    private int runeProgress;
    bool gateOpen;
    [SerializeField] GameObject leftGate;
    [SerializeField] GameObject rightGate;
    [SerializeField] Transform leftGateNew;
    [SerializeField] Transform rightGateNew;
    private void OnTriggerEnter(Collider other)
    {
        if(!gateOpen)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                textCanvas.SetActive(true);
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            textCanvas.SetActive(false);
        }
    }
    private void OpenGate()
    {
        leftGate.transform.rotation = leftGateNew.rotation;
        leftGate.transform.localScale = leftGateNew.localScale;
        rightGate.transform.rotation = rightGateNew.rotation;
        rightGate.transform.localScale = rightGateNew.localScale;

        textCanvas.SetActive(false);
    }

    public void ActivateRune()
    {
        runeProgress++;
        if(runeProgress >= 5)
        {
            gateOpen = true;
            OpenGate();
        }
    }
}
