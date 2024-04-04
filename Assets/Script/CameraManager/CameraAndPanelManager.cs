using UnityEngine;

public class CameraAndPanelManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] Camera[] cameras;

    [Header("Panels")]
    [SerializeField] GameObject[] panels;

    private void Start()
    {
        // Ensure only the main camera is enabled at start
        EnableCamera(0);
    }

    private void Update()
    {
        // Check for input key to switch cameras
        if (Input.GetKeyDown(KeyCode.Alpha0))
            EnableCamera(0);
        else if (Input.GetKeyDown(KeyCode.Alpha1))
            EnableCamera(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            EnableCamera(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            EnableCamera(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            EnableCamera(4);
    }

    private void EnableCamera(int index)
    {
        // Disable all cameras and panels
        foreach (var camera in cameras)
            camera.enabled = false;
        foreach (var panel in panels)
            panel.SetActive(false);

        // Enable the selected camera and panel
        if (index >= 0 && index < cameras.Length)
            cameras[index].enabled = true;
        if (index >= 0 && index < panels.Length)
            panels[index].SetActive(true);
    }
}
