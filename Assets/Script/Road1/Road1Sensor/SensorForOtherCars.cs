using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorForOtherCars : MonoBehaviour
{
    [SerializeField] CarAI carAI;
    public static int vehicleCount_Road3;
    public static int vehicleCount_Road2;
    public static int vehicleCount_Road4;
    // Start is called before the first frame update
    void Start()
    {
        carAI = GetComponentInParent<CarAI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
          //  Debug.Log("trigred");
            carAI.move = false;
        }
        if (other.CompareTag("Signal2") || other.CompareTag("Signal3") || other.CompareTag("Signal4"))
        {
            Road1TrafficLight _road1TrafficLight = other.GetComponentInParent<Road1TrafficLight>();
            if (_road1TrafficLight != null)
            {
                if (_road1TrafficLight.onGreen)
                {
                    carAI.move = true;
                }
                else if (_road1TrafficLight.onYellow)
                {
                    carAI.move = false;
                }
                else if (_road1TrafficLight.onRed)
                {
                    carAI.move = false;
                }
            }
            //Debug.Log("SignalCheck");

        }
        if (other.CompareTag("Detector3"))
        {
            gameObject.transform.parent.GetChild(4).gameObject.SetActive(true);
            vehicleCount_Road3++;
           
        }
        if (other.CompareTag("Detector2"))
        {
            gameObject.transform.parent.GetChild(4).gameObject.SetActive(true);
            vehicleCount_Road2++;
        } 
        if (other.CompareTag("Detector4"))
        {
            gameObject.transform.parent.GetChild(4).gameObject.SetActive(true);
            vehicleCount_Road4++;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Signal2") || other.CompareTag("Signal3") || other.CompareTag("Signal4"))
        {
            Road1TrafficLight _road1TrafficLight = other.GetComponentInParent<Road1TrafficLight>();
            if (_road1TrafficLight != null)
            {
                if (_road1TrafficLight.onGreen)
                {
                    Invoke("wait", 0.5f);
                }
                else if (_road1TrafficLight.onYellow)
                {
                    carAI.move = false;
                }
                else if (_road1TrafficLight.onRed)
                {
                    carAI.move = false;

                }
            }
           
        }
    }
    void wait()
    {
        carAI.move = true;
    }
    private void OnTriggerExit(Collider other)
    {
        carAI.move = true;
        if (other.CompareTag("Signal3"))
        {
            gameObject.transform.parent.GetChild(4).gameObject.SetActive(false);
            if (vehicleCount_Road3 != 0) { vehicleCount_Road3--; }
            else vehicleCount_Road3 = 0;
            
        }
        if (other.CompareTag("Signal2"))
        {
            gameObject.transform.parent.GetChild(4).gameObject.SetActive(false);
            if (vehicleCount_Road2 != 0) { vehicleCount_Road2--; }
            else vehicleCount_Road2 = 0;
            
        }if (other.CompareTag("Signal4"))
        {
            gameObject.transform.parent.GetChild(4).gameObject.SetActive(false);
            if (vehicleCount_Road4 != 0) { vehicleCount_Road4--; }
            else vehicleCount_Road4 = 0;
            
        }
    }
}
