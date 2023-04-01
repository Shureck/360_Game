using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Canvas))]
public class ResizeColliderToCanvas : MonoBehaviour
{
    private BoxCollider _collider;
    private Canvas parentCanvas;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        parentCanvas = GetComponentInChildren<Canvas>(true);
        ResizeCollider();
    }

    private void Update()
    {
        // Проверяем, изменился ли размер Canvas
        if (parentCanvas.transform.hasChanged)
        {
            ResizeCollider();
            parentCanvas.transform.hasChanged = false;
        }
    }

    private void ResizeCollider()
    {
        var canvasRect = parentCanvas.GetComponent<RectTransform>();
        var sizeInWorldSpace = RectTransformUtility.PixelAdjustRect(canvasRect, parentCanvas);
        _collider.size = new Vector3(sizeInWorldSpace.width, sizeInWorldSpace.height, 0.04f);
    }
}