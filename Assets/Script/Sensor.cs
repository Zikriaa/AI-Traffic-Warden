using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField]CarAILane1 carAI;
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
            Debug.Log("trigred");
            carAI.move = false;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        carAI.move = true;   
    }
}
