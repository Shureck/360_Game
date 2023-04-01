using UnityEngine;
using UnityEngine.UI;

public class IsSelected : MonoBehaviour
{
    public Material material;
    public GameObject panel;

    private void OnTriggerStay(Collider other)
    {
        var image = panel.GetComponent<Image>();
        if (image != null)
        {
            image.material = material;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var image = panel.GetComponent<Image>();
        if (image != null)
        {
            image.material = null;
        }
    }
}