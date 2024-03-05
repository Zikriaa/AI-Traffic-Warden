using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road1TrafficLight : MonoBehaviour
{
    [SerializeField] GameObject[] signalLights;
    public bool onRed, onGreen, onYellow = false;
    float timerRed = 10; 
    public float timerGreen = 5;
    public bool pointerForSignal = false;
    public bool timerCompleted = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        onRed = true;

    }

    // Update is called once per frame
    void Update()
    {
       
        
            TurnLightOn();
            TimerForSignal();
            
       
    }
    void OnStaringPoint()
    {
        onGreen = true;
        onYellow = false;
        onRed = false;
    }
    void TimerForSignal()
    {
        if (pointerForSignal && onGreen)
        {
            timerGreen -= Time.deltaTime;
            Debug.Log("timergreen : " + timerGreen);
            if(timerGreen <= 0)
            {
                Invoke("Reset", 2f);
            }
           
        }
      
    }
    private void Reset()
    {
        timerGreen = 5;
    }
    void TurnLightOn()
    {
        if (onRed) 
            { signalLights[0].gameObject.SetActive(true);
            signalLights[1].SetActive(false);
            signalLights[2].gameObject.SetActive(false);
          
        }
        else if (onGreen) 
            {
            signalLights[1].SetActive(true);
            signalLights[2].gameObject.SetActive(false);
            signalLights[0].gameObject.SetActive(false);
           
        }
        //else if(onYellow)
        //    { signalLights[2].gameObject.SetActive(true);
        //    signalLights[0].gameObject.SetActive(false);
        //    signalLights[1].gameObject.SetActive(false);
        //    onGreen = false;
        //    onRed = false;
        //}
    } 
}
