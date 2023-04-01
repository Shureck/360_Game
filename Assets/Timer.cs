using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private void Start()
    {
        // Получаем все дочерние объекты
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        // Запускаем корутину для включения объектов через 30 секунд
        StartCoroutine(EnableObjects(5f));
    }

    private IEnumerator EnableObjects(float delay)
    {
        // Ждем определенное время
        yield return new WaitForSeconds(delay);

        // Получаем все дочерние объекты
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}