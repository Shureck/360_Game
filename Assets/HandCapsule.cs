using UnityEngine;
using UnityEngine.XR;

public class HandCapsule : MonoBehaviour
{
    public bool IsLeftHand;

    public InputDeviceManager InputDeviceManager;
    public GameObject capsule;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Reset()
    {
        InputDeviceManager = FindObjectOfType<InputDeviceManager>();
    }

    private void Update()
    {
        var inputDevice = IsLeftHand ? InputDeviceManager.LeftController : InputDeviceManager.RightController;

        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out var triggerValue);
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out var gripValue);

        if (inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed) && isPressed)
        {
            capsule.tag = "Laser";
        }
        else{
            capsule.tag = "Not Laser";
        }

        _renderer.material.color = new Color(triggerValue, gripValue, 1f);
    }
}