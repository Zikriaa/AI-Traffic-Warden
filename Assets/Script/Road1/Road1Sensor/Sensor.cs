using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField]CarAILane1 carAI;
    int counts = 0;

    public static int vehicleCount;
    // Start is called before the first frame update
    void Start()
    {
        carAI = GetComponentInParent<CarAILane1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            //Debug.Log("trigred");
            carAI.move = false;
        }
        if (other.CompareTag("Signal"))
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
           // Debug.Log("SignalCheck");

        }
        if (other.CompareTag("Detector"))
        {
          
                gameObject.transform.parent.GetChild(4).gameObject.SetActive(true);
                vehicleCount++;
            
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Signal"))
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
            //Debug.Log("SignalCheck");
        }
    }
    void wait()
    {
        carAI.move = true;
    }
    private void OnTriggerExit(Collider other)
    {
        carAI.move = true;
        if (other.CompareTag("Signal"))
        {
            gameObject.transform.parent.GetChild(4).gameObject.SetActive(false);
            if (vehicleCount != 0) { vehicleCount--; }
            else { vehicleCount = 0; }
        }
    }

}
