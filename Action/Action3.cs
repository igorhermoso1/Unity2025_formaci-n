using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action3 : MonoBehaviour
{
    public void OnMouseDown()
    {
        GestorAction.instancia.ejecutarAccionCompleja();
    }
}
