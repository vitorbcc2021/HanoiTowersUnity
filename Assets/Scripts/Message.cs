using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.enabled = false;
    }
}
