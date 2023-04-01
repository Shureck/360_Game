using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetText : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text textObject;
    public string text;

    void Start()
    {
        textObject.text = text;
    }
}
