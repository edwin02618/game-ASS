using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer1 : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public int secondleft = 3;
    public bool takeingAway = false;

    IEnumerator TimerTake()
    {
        takeingAway = true;
        yield return new WaitForSeconds(1);
        secondleft -= 1;
        timerText.text = "00:0" + secondleft;
        takeingAway = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:0" + secondleft;
    }

    // Update is called once per frame
    void Update()
    {
        if(takeingAway == false && secondleft > 0)
        {
            StartCoroutine(TimerTake());
        }

        
    }
}
