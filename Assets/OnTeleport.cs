using System;
using UnityEngine;

namespace Display
{
    public class OnTeleport: MonoBehaviour
    {
        private DisplayWithDelay[] _childDisplays;
        private void OnTriggerEnter(Collider other)
        {
            if (_childDisplays is null)
            {
                _childDisplays = GetComponentsInChildren<DisplayWithDelay>();
            }

            foreach (var display in _childDisplays)
            {
                display.HideAndShow();
            }
        }
    }
}