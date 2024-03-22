using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TrafficSystemController : MonoBehaviour
{

    [SerializeField] Road1TrafficLight road1TrafficLight;
    [SerializeField] Road1TrafficLight road2TrafficLight;
    [SerializeField] Road1TrafficLight road3TrafficLight;
    [SerializeField] Road1TrafficLight road4TrafficLight;

    public static bool road1_countVehicles = false;

    public static bool timerChanged = false;
    public static bool timerChanged_Road3= false;
    public static bool timerChanged_Road2= false;
    public static bool timerChanged_Road4= false;
    // Start is called before the first frame update
    void Start()
    {
        road2TrafficLight.pointerForSignal = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (road1TrafficLight.pointerForSignal)
        {
            Road1_Settings();
        }
        else if (road2TrafficLight.pointerForSignal)
        {
            Road2_Settings();
        }
        else if (road3TrafficLight.pointerForSignal) 
        {
            Road3_Setiings();
        }
        else if (road4TrafficLight.pointerForSignal)
        {
            Road4_Settigns();
        }
    } 
   void Road1_Settings()
    {
        road1TrafficLight.onRed = false;
        road1TrafficLight.onYellow = true;
        road1TrafficLight.onGreen = false;
        
       
        if (!timerChanged)
        {
            int totalVehicle = Sensor.vehicleCount + Sensor2.vehiclecount + Sensor3.vehiclecount;
            road1TrafficLight.SetGreenTimer(totalVehicle);
            timerChanged = true;
           
        }

        if (road1TrafficLight.timerYellow <= 0 && road1TrafficLight.onYellow)
        {
            road1TrafficLight.onYellow = false;
            road1TrafficLight.onGreen = true;
            
        }
        if (road1TrafficLight.timerGreen <= 0)
        {
            road1TrafficLight.onGreen = false;
            road1TrafficLight.onRed = true;
       
            
            timerChanged_Road3 = false;

            // road1TrafficLight.onYellow = false;
            road1TrafficLight.pointerForSignal = false;
            road3TrafficLight.pointerForSignal = true;
            if (road1TrafficLight.onGreen == false)
            {
                road1TrafficLight.ResetYellowTimer();
               
            }

        }
    }
    void Road2_Settings()
    {
        road2TrafficLight.onRed = false;
        road2TrafficLight.onYellow = true;
        road2TrafficLight.onGreen = false;
       

        if (!timerChanged_Road2)
        {
            int _totalVehicles = SensorForOtherCars.vehicleCount_Road2;
            Debug.Log("road vehicles : " +  _totalVehicles);
            road2TrafficLight.SetGreenTimer(_totalVehicles);
            timerChanged_Road2 = true;
        }

        if (road2TrafficLight.timerYellow <= 0 && road2TrafficLight.onYellow)
        {
            road2TrafficLight.onGreen = true;
            road2TrafficLight.onYellow = false;
           
        }
        if (road2TrafficLight.timerGreen <= 0)
        {
            road2TrafficLight.onGreen = false;
            road2TrafficLight.onRed = true;
            road2TrafficLight.onYellow = false;

            road2TrafficLight.pointerForSignal = false;
            road4TrafficLight.pointerForSignal = true;
            timerChanged_Road4 = false;

            if (road2TrafficLight.onGreen == false)
            {
                road2TrafficLight.ResetYellowTimer();
            }
        }
    }
    void Road3_Setiings()
    {
        road3TrafficLight.onRed = false;
        road3TrafficLight.onYellow = true;
        road3TrafficLight.onGreen = false;
      
        if (!timerChanged_Road3)
        {
            int _totalVehicles = SensorForOtherCars.vehicleCount_Road3;
            road3TrafficLight.SetGreenTimer(_totalVehicles);
            timerChanged_Road3 = true;
        }
        if (road3TrafficLight.timerYellow <= 0 && road3TrafficLight.onYellow)
        {
            road3TrafficLight.onGreen = true;
            road3TrafficLight.onYellow = false;
        }
        if (road3TrafficLight.timerGreen <= 0)
        {
            road3TrafficLight.onGreen = false;
            road3TrafficLight.onRed = true;
            road3TrafficLight.onYellow = false;
            road3TrafficLight.pointerForSignal = false;
            road2TrafficLight.pointerForSignal = true;
            timerChanged_Road2 = false;
            if (road3TrafficLight.onGreen == false)
            {
                road3TrafficLight.ResetYellowTimer();
            }
        }
    }
    void Road4_Settigns()
    {
        road4TrafficLight.onRed = false;
        road4TrafficLight.onYellow = true;
        road4TrafficLight.onGreen = false;


        if (!timerChanged_Road4)
        {
            int _totalVehicles = SensorForOtherCars.vehicleCount_Road4;
            road4TrafficLight.SetGreenTimer(_totalVehicles);
            timerChanged_Road4 = true;
        }
        if (road4TrafficLight.timerYellow <= 0 && road4TrafficLight.onYellow)
        {
            road4TrafficLight.onGreen = true;
            road4TrafficLight.onYellow = false;
        }
        if (road4TrafficLight.timerGreen <= 0)
        {
            road4TrafficLight.onGreen = false;
            road4TrafficLight.onRed = true;
            road4TrafficLight.onYellow = false;

            road4TrafficLight.pointerForSignal = false;
            road1TrafficLight.pointerForSignal = true;
            timerChanged = false;
            if (road4TrafficLight.onGreen == false)
            {
                road4TrafficLight.ResetYellowTimer();
            }
        }
    }
}
