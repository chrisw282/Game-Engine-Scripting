using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI label;

    public void PrintMessage(string msg)
    {
        label.text = msg;
    }

    public void Add(int number)
    {
        label.text = (number).ToString();
    }
}