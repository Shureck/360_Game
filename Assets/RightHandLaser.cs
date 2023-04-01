// using UnityEngine;
// using UnityEngine.XR;

// public class RightHandLaser : MonoBehaviour
// {
//     public InputDeviceManager InputDeviceManager;
//     public float LaserDistance = 10f;
//     public LayerMask LayerMask;

//     public GameObject cube;

//     private void Reset()
//     {
//         InputDeviceManager = FindObjectOfType<InputDeviceManager>();
//     }

//     private void Update()
//     {
//         var inputDevice = InputDeviceManager.RightController;

//         if (inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out var position) &&
//             inputDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out var rotation))
//         {
//             var direction = rotation * Vector3.forward;
//             var ray = new Ray(position, direction);

            
//             cube.transform.position = position;
//             cube.transform.rotation = rotation;
//         }
//     }
// }