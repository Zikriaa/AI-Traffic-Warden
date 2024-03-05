using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TrafficSystemController : MonoBehaviour
{

    [SerializeField] Road1TrafficLight road1TrafficLight;
    [SerializeField] Road1TrafficLight road2TrafficLight;
    [SerializeField] Road1TrafficLight road3TrafficLight;
    [SerializeField] Road1TrafficLight road4TrafficLight;
    // Start is called before the first frame update
    void Start()
    {
       // road1TrafficLight.pointerForSignal = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (road1TrafficLight.pointerForSignal)
        { 
            road1TrafficLight.onRed = false;
            road1TrafficLight.onGreen = true;
            road2TrafficLight.pointerForSignal = false;
            road3TrafficLight.pointerForSignal = false;
            road4TrafficLight.pointerForSignal = false;
            if (road1TrafficLight.timerGreen <= 0)
            {
                road1TrafficLight.onGreen = false;
                road1TrafficLight.onRed = true ;
                road1TrafficLight.pointerForSignal = false;
                road2TrafficLight.pointerForSignal = true;

            }
        }
        else if (road2TrafficLight.pointerForSignal)
        {
            road2TrafficLight.onRed = false;
            road2TrafficLight.onGreen = true;
            road1TrafficLight.pointerForSignal = false;
            road3TrafficLight.pointerForSignal = false;
            road4TrafficLight.pointerForSignal = false;
            if (road2TrafficLight.timerGreen <= 0)
            {
                road2TrafficLight.onGreen = false;
                road2TrafficLight.onRed = true;
                road2TrafficLight.pointerForSignal = false;
                road3TrafficLight.pointerForSignal = true;
            }
        }
        else if (road3TrafficLight.pointerForSignal) 
        {
            road3TrafficLight.onRed = false;
            road3TrafficLight.onGreen = true;
            road1TrafficLight.pointerForSignal = false;
            road2TrafficLight.pointerForSignal = false;
            road4TrafficLight.pointerForSignal = false;
            if (road3TrafficLight.timerGreen <= 0)
            {
                road3TrafficLight.onGreen = false;
                road3TrafficLight.onRed = true;
                road3TrafficLight.pointerForSignal = false;
                road4TrafficLight.pointerForSignal = true;
            }
        }
        else if (road4TrafficLight.pointerForSignal)
        {
            road4TrafficLight.onRed = false;
            road4TrafficLight.onGreen = true;
            road1TrafficLight.pointerForSignal = false;
            road2TrafficLight.pointerForSignal = false;
            road3TrafficLight.pointerForSignal = false;
            if (road4TrafficLight.timerGreen <= 0)
            {
                road4TrafficLight.onGreen = false;
                road4TrafficLight.onRed = true;
                road4TrafficLight.pointerForSignal = false;
                road1TrafficLight.pointerForSignal = true;
            }
        }











    }
}
