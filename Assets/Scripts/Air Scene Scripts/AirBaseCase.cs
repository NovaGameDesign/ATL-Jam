using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AirBaseCase : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] float timer;
    [SerializeField] PlayerHealthManager player;

    // Start is called before the first frame update
    //void Awake()
    //{
    //    timer = 180f;
    //}

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            TimeDisplay();
        }
        else
        {
            //return to main menu, level failed
        }
    }

    void TimeDisplay()
    {
        if (timer > 0)
        {
            float min = Mathf.FloorToInt(timer / 60);
            float sec = Mathf.FloorToInt(timer % 60);
            timeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            timeText.text = "0:00";
            player.TakeHit(1000);
        }
    }
}
