using UnityEngine;

public class HoverText : MonoBehaviour
{
    public string hoverText; // Текст, который нужно вывести

    private TextMesh textMesh; // Компонент TextMesh

    private bool isHovering; // Флаг, указывающий, что луч наведен на объект

    private void Start()
    {
        // Получаем компонент TextMesh
        textMesh = GetComponentInChildren<TextMesh>();
        // Выключаем текст по умолчанию
        textMesh.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Not Laser"))
        {   
            // Включаем текст и устанавливаем его значение
            textMesh.gameObject.SetActive(true);
            textMesh.text = hoverText;
            isHovering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, что луч ушел из зоны столкновения
        if (other.gameObject.CompareTag("Not Laser"))
        {
            // Выключаем текст
            textMesh.gameObject.SetActive(false);
            isHovering = false;
        }
    }
}