using UnityEngine;

public class AddTextMesh : MonoBehaviour
{
    private void Start()
    {
        // Создаем дочерний объект для текста
        GameObject textObject = new GameObject("Text");

        // Добавляем компонент TextMesh на дочерний объект
        TextMesh textMesh = textObject.AddComponent<TextMesh>();

        // Настраиваем параметры текста
        textMesh.text = "Hello World!";
        textMesh.fontSize = 24;
        textMesh.color = Color.white;

        // Перемещаем дочерний объект на нужное место
        textObject.transform.position = new Vector3(0f, 1f, 0f);

        // Родительский объект должен иметь компонент Mesh Filter
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        // Присваиваем дочерний объект в качестве дочернего объекта родительскому объекту
        textObject.transform.parent = transform;
    }
}