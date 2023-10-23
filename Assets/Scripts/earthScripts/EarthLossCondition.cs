using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EarthLossCondition : MonoBehaviour
{
   
    [SerializeField] float totalTime;
    int remaininTime;
    private string timeRemainingText;
    [SerializeField] TextMeshProUGUI timeText;
    bool playerLost;
    private void Start()
    {

    }
    private void Update()
    {
        if(totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            timeRemainingText = totalTime.ToString();
            float min = Mathf.FloorToInt(totalTime / 60);
            float sec = Mathf.FloorToInt(totalTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }        
        else if (totalTime <= 0)
        {
            playerLost = true;
        }
    }
}
