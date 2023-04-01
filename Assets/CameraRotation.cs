using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public bool allowXRotation = true; // Позволяет вращать камеру по оси X
    public bool allowYRotation = true; // Позволяет вращать камеру по оси Y
    public bool allowZRotation = false; // Позволяет вращать камеру по оси Z

    void Update()
    {
        // Проверяем, зажата ли кнопка мыши
        if (Input.GetMouseButton(0))
        {
            // Получаем значение вращения мыши по осям
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            float mouseZ = Input.GetAxis("Mouse ScrollWheel") * rotationSpeed;

            float currentZRotation = transform.rotation.eulerAngles.z;

            // Вращаем камеру по оси X (вертикальное вращение)
            if (allowXRotation)
            {
                transform.Rotate(-mouseY, 0f, 0f);
            }

            // Вращаем камеру по оси Y (горизонтальное вращение)
            if (allowYRotation)
            {
                transform.Rotate(0f, mouseX, 0f);
            }

            // Вращаем камеру по оси Z (вращение камеры вокруг себя)
            if (allowZRotation)
            {
                transform.Rotate(0f, 0f, mouseZ);
            }

            if (currentZRotation != 0)
            {
                transform.Rotate(0f, 0f, -currentZRotation);
            }
        }
    }
}