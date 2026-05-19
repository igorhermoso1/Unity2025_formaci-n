using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AuxFun : MonoBehaviour
{
    public TMP_Text texto;
    //Cuando se haga click en el cubo se lanza el FUNC del diablo
    void OnMouseDown()
    {
        int resultado = GestorFunc.instancia.activaOperacion(4.5f , 0.25f);
        texto.text += " " + resultado;

    }
}
