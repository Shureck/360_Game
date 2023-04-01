using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputDeviceManager : MonoBehaviour
{
    private HashSet<string> _loadedControllerInputDevices;

    public InputDevice LeftController;
    public InputDevice RightController;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _loadedControllerInputDevices = new HashSet<string>();

        InputDevices.deviceConnected += OnDeviceConnected;
        InputDevices.deviceDisconnected += OnDeviceDisconnected;

        TryInitializeDevices();
    }

    private void OnDestroy()
    {
        InputDevices.deviceConnected -= OnDeviceConnected;
        InputDevices.deviceDisconnected -= OnDeviceDisconnected;
    }

    private void TryInitializeDevices()
    {
        var listDevices = new List<InputDevice>();
        InputDevices.GetDevices(listDevices);
        foreach (var inputDevice in listDevices)
        {
            OnDeviceConnected(inputDevice);
        }
    }

    private void OnDeviceConnected(InputDevice inputDevice)
    {
        Debug.Log($"Connected {inputDevice.name}");
        if (_loadedControllerInputDevices.Contains(GetUniqueName(inputDevice)))
        {
            return;
        }

        if (inputDevice.characteristics.HasFlag(InputDeviceCharacteristics.Controller))
        {
            InitController(inputDevice);
        }
    }

    private void OnDeviceDisconnected(InputDevice inputDevice)
    {
        var uniqueName = GetUniqueName(inputDevice);
        _loadedControllerInputDevices.Remove(uniqueName);
    }

    private void InitController(InputDevice inputDevice)
    {
        var isLeftController = inputDevice.characteristics.HasFlag(InputDeviceCharacteristics.Left);
        if (isLeftController)
        {
            LeftController = inputDevice;
        }
        else
        {
            RightController = inputDevice;
        }

        _loadedControllerInputDevices.Add(GetUniqueName(inputDevice));
    }

    private static string GetUniqueName(InputDevice inputDevice)
    {
        return $"{inputDevice.name}_{inputDevice.characteristics}";
    }
}