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

    public static bool timerChanged = false;
    public static bool timerChanged_Road3= false;
    public static bool timerChanged_Road2= false;
    public static bool timerChanged_Road4= false;

    public static float getGreenTimer1;
    public static float getGreenTimer2;
    public static float getGreenTimer3;
    public static float getGreenTimer4;
    // Start is called before the first frame update
    void Start()
    {
        road4TrafficLight.pointerForSignal = true;
        
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


        // Ensure that only necessary actions are performed if the timer has not been changed
        if (!timerChanged)
        {
            int totalVehicle = Sensor.vehicleCount + Sensor2.vehiclecount + Sensor3.vehiclecount;
            road1TrafficLight.SetGreenTimer(totalVehicle);
            timerChanged = true;
            UpdateRoadStats.instance.StoreDetails = false;
            UpdateRoadStats.instance.loadDetails = false;
            UpdateRoadStats.instance.vehicalupdated = false;
        }
        if (road1TrafficLight.timerGreen > 0) { 
            getGreenTimer1 = road1TrafficLight.timerGreen;
        }
        // Check if the yellow timer has elapsed and switch to green if necessary
        if (road1TrafficLight.timerYellow <= 0 && road1TrafficLight.onYellow)
        {
            road1TrafficLight.onYellow = false;
            road1TrafficLight.onGreen = true;
        }


      
        // Check if the green timer has elapsed and switch to red if necessary
        if (road1TrafficLight.timerGreen <= 0)
        {
            road1TrafficLight.onGreen = false;
            road1TrafficLight.onRed = true;

            // Reset timer changed flag for the next cycle
            timerChanged_Road3 = false;

            // Set pointers for signal control
            road1TrafficLight.pointerForSignal = false;
            road3TrafficLight.pointerForSignal = true;

            // Reset yellow timer if green has ended
            if (!road1TrafficLight.onGreen)
            {
                road1TrafficLight.ResetYellowTimer();
            }
        }
    }
    void Road2_Settings()
    {
        // Set initial signal state for road 2
        road2TrafficLight.onRed = false;
        road2TrafficLight.onYellow = true;
        road2TrafficLight.onGreen = false;

        // Ensure that timer has not been changed before performing certain actions
        if (!timerChanged_Road2)
        {
            int totalVehicles = SensorForOtherCars.vehicleCount_Road2;
            Debug.Log("Road vehicles: " + totalVehicles);
            road2TrafficLight.SetGreenTimer(totalVehicles);
            timerChanged_Road2 = true;
            UpdateRoadStats.instance.StoreDetails_road2 = false;
            UpdateRoadStats.instance.loadDetails_road2 = false;
            UpdateRoadStats.instance.vehicalupdated_road2 = false;

        }
        if (road2TrafficLight.timerGreen > 0)
        {
            getGreenTimer2 = road2TrafficLight.timerGreen;
        }
        // Check if the yellow timer has elapsed and switch to green if necessary
        if (road2TrafficLight.timerYellow <= 0 && road2TrafficLight.onYellow)
        {
            road2TrafficLight.onGreen = true;
            road2TrafficLight.onYellow = false;
        }

        // Check if the green timer has elapsed and switch to red if necessary
        if (road2TrafficLight.timerGreen <= 0)
        {
            road2TrafficLight.onGreen = false;
            road2TrafficLight.onRed = true;
            road2TrafficLight.onYellow = false;

            // Set pointers for signal control
            road2TrafficLight.pointerForSignal = false;
            road4TrafficLight.pointerForSignal = true;
            timerChanged_Road4 = false;

            // Reset yellow timer if green has ended
            if (!road2TrafficLight.onGreen)
            {
                road2TrafficLight.ResetYellowTimer();
            }
        }
    }
    void Road3_Setiings()
    {
        // Set initial signal state for road 3
        road3TrafficLight.onRed = false;
        road3TrafficLight.onYellow = true;
        road3TrafficLight.onGreen = false;

        // Ensure that timer has not been changed before performing certain actions
        if (!timerChanged_Road3)
        {
            int totalVehicles = SensorForOtherCars.vehicleCount_Road3;
            road3TrafficLight.SetGreenTimer(totalVehicles);
            timerChanged_Road3 = true;
            UpdateRoadStats.instance.StoreDetails_road3 = false;
            UpdateRoadStats.instance.loadDetails_road3= false;
            UpdateRoadStats.instance.vehicalupdated_road3 = false;

        }
        if (road3TrafficLight.timerGreen > 0)
        {
            getGreenTimer3 = road3TrafficLight.timerGreen;
        }

        // Check if the yellow timer has elapsed and switch to green if necessary
        if (road3TrafficLight.timerYellow <= 0 && road3TrafficLight.onYellow)
        {
            road3TrafficLight.onGreen = true;
            road3TrafficLight.onYellow = false;
        }

        // Check if the green timer has elapsed and switch to red if necessary
        if (road3TrafficLight.timerGreen <= 0)
        {
            road3TrafficLight.onGreen = false;
            road3TrafficLight.onRed = true;
            road3TrafficLight.onYellow = false;

            // Set pointers for signal control
            road3TrafficLight.pointerForSignal = false;
            road2TrafficLight.pointerForSignal = true;
            timerChanged_Road2 = false;

            // Reset yellow timer if green has ended
            if (!road3TrafficLight.onGreen)
            {
                road3TrafficLight.ResetYellowTimer();
            }
        }
    }
    void Road4_Settigns()
    {
        // Set initial signal state for road 4
        road4TrafficLight.onRed = false;
        road4TrafficLight.onYellow = true;
        road4TrafficLight.onGreen = false;

        // Ensure that timer has not been changed before performing certain actions
        if (!timerChanged_Road4)
        {
            int totalVehicles = SensorForOtherCars.vehicleCount_Road4;
            road4TrafficLight.SetGreenTimer(totalVehicles);
            timerChanged_Road4 = true;
            UpdateRoadStats.instance.StoreDetails_road4 = false;
            UpdateRoadStats.instance.loadDetails_road4= false;
            UpdateRoadStats.instance.vehicalupdated_road4 = false;

        }
        if (road4TrafficLight.timerGreen > 0)
        {
            getGreenTimer4 = road4TrafficLight.timerGreen;
        }

        // Check if the yellow timer has elapsed and switch to green if necessary
        if (road4TrafficLight.timerYellow <= 0 && road4TrafficLight.onYellow)
        {
            road4TrafficLight.onGreen = true;
            road4TrafficLight.onYellow = false;
        }

        // Check if the green timer has elapsed and switch to red if necessary
        if (road4TrafficLight.timerGreen <= 0)
        {
            road4TrafficLight.onGreen = false;
            road4TrafficLight.onRed = true;
            road4TrafficLight.onYellow = false;

            // Set pointers for signal control
            road4TrafficLight.pointerForSignal = false;
            road1TrafficLight.pointerForSignal = true;
            timerChanged = false;

            // Reset yellow timer if green has ended
            if (!road4TrafficLight.onGreen)
            {
                road4TrafficLight.ResetYellowTimer();
            }
        }
    }
}
