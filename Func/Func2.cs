using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Func2 : MonoBehaviour
{
    
    void Start()
    {
        //Suscripción al evento complejo
        GestorFunc.instancia.OnCalculo += calcular; 
    }

    //Función calcular: calcula
    public int calcular(float num1, float num2)
    {
        return Mathf.RoundToInt(num1 + num2);

    }
}
