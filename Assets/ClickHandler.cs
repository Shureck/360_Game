using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public GameObject cameraObject; // Камера

    public Transform target; // Объект, к которому нужно переместить камеру

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {               
            // Поворачиваем камеру в сторону цели
            cameraObject.transform.LookAt(target);

            // Вычисляем расстояние между камерой и целью
            float distance = Vector3.Distance(cameraObject.transform.position, target.position);

            // Перемещаем камеру в центр цели
            cameraObject.transform.Translate(0f, 0f, distance);
        }
    }
}