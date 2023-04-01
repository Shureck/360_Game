using UnityEngine;
using UnityEngine.XR;

public class RightLaser : MonoBehaviour
{
    public InputDeviceManager InputDeviceManager;
    public float LaserDistance = 10f;
    public LayerMask LayerMask;

    public GameObject gameObject;

    private void Reset()
    {
        InputDeviceManager = FindObjectOfType<InputDeviceManager>();
    }

    private void Update()
    {
        var inputDevice = InputDeviceManager.RightController;

        if (inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out var position) &&
            inputDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out var rotation))
        {
            var direction = rotation * Vector3.forward;
            var ray = new Ray(position, direction);

            
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
        }

        if (inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed) && isPressed)
        {
            Debug.Log("Trig");
            gameObject.tag = "Laser";
        }
        else{
            gameObject.tag = "Not Laser";
        }
    }
}