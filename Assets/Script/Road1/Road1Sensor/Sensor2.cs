using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor2 : MonoBehaviour
{
    [SerializeField] CarAILane2 carAI;
    // Start is called before the first frame update
    void Start()
    {
        carAI = GetComponentInParent<CarAILane2>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("trigred");
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
            Debug.Log("SignalCheck");
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
                    Invoke("wait", 1.5f);
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
            Debug.Log("SignalCheck");
        }
    }
    void wait()
    {
        carAI.move = true;
    }
    private void OnTriggerExit(Collider other)
    {
        carAI.move = true;
    }
}
