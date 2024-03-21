using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDetector1 : MonoBehaviour
{
    public Color rectangleColor = Color.red;
    public float rectangleWidth = 2f;

    private Rect rectangle;

    private void Start()
    {
        // Set the initial position and size of the rectangle
        float width = 100f;
        float height = 50f;
        float x = (Screen.width - width) / 2f;
        float y = (Screen.height - height) / 2f;
        rectangle = new Rect(x, y, width, height);
    }

    private void OnGUI()
    {
        // Set the color of the rectangle
        GUI.color = rectangleColor;

        // Draw the rectangle
        GUI.Box(rectangle, "");
    }
}
