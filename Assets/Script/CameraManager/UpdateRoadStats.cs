using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRoadStats : MonoBehaviour
{
    public static UpdateRoadStats instance;

    [Header("Road1_details")]
    [SerializeField] Text lastVehicles_text; 
    [SerializeField] Text LastTimer_text; 
    [SerializeField] Text updatedVehicles_text; 
    [SerializeField] Text updatedTimer_text;
    
     //Road1 Detail var to store previous couts
    int StorePreviousvehical_Road1;
    float StorePreviousTimer_Road1;
    public bool StoreDetails=false;
    public bool loadDetails=false;
    public bool vehicalupdated = false;
    int totalVehicles;

    [Header("Road2_details")]
    [SerializeField] Text lastVehiclesRoad2_text;
    [SerializeField] Text LastTimerRoad2_text;
    [SerializeField] Text updatedVehiclesRoad2_text;
    [SerializeField] Text updatedTimerRoad2_text;

    //Road2 Detail var to store previous couts
    int StorePreviousvehical_Road2;
    float StorePreviousTimer_Road2;
    public bool StoreDetails_road2 = false;
    public bool loadDetails_road2=false;
    public bool vehicalupdated_road2 = false;
    int totalVehicles_road2;

    [Header("Road3_details")]
    [SerializeField] Text lastVehiclesRoad3_text;
    [SerializeField] Text LastTimerRoad3_text;
    [SerializeField] Text updatedVehiclesRoad3_text;
    [SerializeField] Text updatedTimerRoad3_text;
    //Road3 Detail var to store previous couts
    int StorePreviousvehical_Road3;
    float StorePreviousTimer_Road3;
    public bool StoreDetails_road3 = false;
    public bool loadDetails_road3 = false;
    public bool vehicalupdated_road3 = false;
    int totalVehicles_road3;


    [Header("Road4_details")]
    [SerializeField] Text lastVehiclesRoad4_text;
    [SerializeField] Text LastTimerRoad4_text;
    [SerializeField] Text updatedVehiclesRoad4_text;
    [SerializeField] Text updatedTimerRoad4_text;
    //Road4 Detail var to store previous couts
    int StorePreviousvehical_Road4;
    float StorePreviousTimer_Road4;
    public bool StoreDetails_road4 = false;
    public bool loadDetails_road4 = false;
    public bool vehicalupdated_road4 = false;
    int totalVehicles_road4;


    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (TrafficSystemController.timerChanged && !StoreDetails) { updateRoad1Details_NOW(); }
        if (TrafficSystemController.getGreenTimer1 <= 0) { StoreDetails = true; }

        if(TrafficSystemController.timerChanged_Road2 && !StoreDetails_road2) { updateRoad2Details_NOW();}
        if(TrafficSystemController.getGreenTimer2 <= 0) { StoreDetails_road2 = true;}

        if(TrafficSystemController.timerChanged_Road3 && !StoreDetails_road3) { updateRoad3Details_NOW(); }
        if (TrafficSystemController.getGreenTimer3 <= 0) { StoreDetails_road3 = false; }
        
        if(TrafficSystemController.timerChanged_Road4 && !StoreDetails_road4) { updateRoad4Details_NOW(); }
        if (TrafficSystemController.getGreenTimer4 <= 0) { StoreDetails_road4 = false; }

        
    }

    void updateRoad1Details_NOW()
    {


        float timer = TrafficSystemController.getGreenTimer1;
        updatedTimer_text.text = "Signal Timer : " + timer.ToString("0");
      
        // LoadRoad1Details_LAST(); // This line is commented out because it's not clear what it does

        if (!vehicalupdated)
        {
            int total_vehicles = Sensor.vehicleCount + Sensor2.vehiclecount + Sensor3.vehiclecount;
            updatedVehicles_text.text = "UpdatedVehicles: " + total_vehicles.ToString();
            totalVehicles = total_vehicles;
            vehicalupdated = true;
        }



        if (loadDetails == false)
        {
            StorePreviousTimer_Road1 = timer;
            StorePreviousvehical_Road1 = totalVehicles;
            LastTimer_text.text = "LastTimer: " + StorePreviousTimer_Road1.ToString("0");
            lastVehicles_text.text = "Last Vehicles: " + StorePreviousvehical_Road1.ToString();
            loadDetails = true;
        }

       
    }
    void updateRoad2Details_NOW()
    {


        float timer = TrafficSystemController.getGreenTimer2;
        updatedTimerRoad2_text.text = "Signal Timer : " + timer.ToString("0");
      
        // LoadRoad1Details_LAST(); // This line is commented out because it's not clear what it does

        if (!vehicalupdated_road2)
        {
            int total_vehicles = SensorForOtherCars.vehicleCount_Road2;
            updatedVehiclesRoad2_text.text = "UpdatedVehicles: " + total_vehicles.ToString();
            totalVehicles_road2 = total_vehicles;
            vehicalupdated_road2 = true;
        }



        if (loadDetails_road2 == false)
        {
            StorePreviousTimer_Road2 = timer;
            StorePreviousvehical_Road2 = totalVehicles_road2;
            LastTimerRoad2_text.text = "LastTimer: " + StorePreviousTimer_Road2.ToString("0");
            lastVehiclesRoad2_text.text = "Last Vehicles: " + StorePreviousvehical_Road2.ToString();
            loadDetails_road2 = true;
        }

       
    }  
    void updateRoad3Details_NOW()
    {


        float timer = TrafficSystemController.getGreenTimer3;
        updatedTimerRoad3_text.text = "Signal Timer : " + timer.ToString("0");
      
        // LoadRoad1Details_LAST(); // This line is commented out because it's not clear what it does

        if (!vehicalupdated_road3)
        {
            int total_vehicles = SensorForOtherCars.vehicleCount_Road3;
            updatedVehiclesRoad3_text.text = "UpdatedVehicles: " + total_vehicles.ToString();
            totalVehicles_road3 = total_vehicles;
            vehicalupdated_road3 = true;
        }



        if (loadDetails_road3 == false)
        {
            StorePreviousTimer_Road3 = timer;
            StorePreviousvehical_Road3 = totalVehicles_road3;
            LastTimerRoad3_text.text = "LastTimer: " + StorePreviousTimer_Road3.ToString("0");
            lastVehiclesRoad3_text.text = "Last Vehicles: " + StorePreviousvehical_Road3.ToString();
            loadDetails_road3 = true;
        }

       
    }    
    void updateRoad4Details_NOW()
    {


        float timer = TrafficSystemController.getGreenTimer4;
        updatedTimerRoad4_text.text = "Signal Timer : " + timer.ToString("0");
      
        // LoadRoad1Details_LAST(); // This line is commented out because it's not clear what it does

        if (!vehicalupdated_road4)
        {
            int total_vehicles = SensorForOtherCars.vehicleCount_Road4;
            updatedVehiclesRoad4_text.text = "UpdatedVehicles: " + total_vehicles.ToString();
            totalVehicles_road4 = total_vehicles;
            vehicalupdated_road4 = true;
        }



        if (loadDetails_road4 == false)
        {
            StorePreviousTimer_Road4 = timer;
            StorePreviousvehical_Road4 = totalVehicles_road4;
            LastTimerRoad4_text.text = "LastTimer: " + StorePreviousTimer_Road4.ToString("0");
            lastVehiclesRoad4_text.text = "Last Vehicles: " + StorePreviousvehical_Road4.ToString();
            loadDetails_road4 = true;
        }

       
    }


}
