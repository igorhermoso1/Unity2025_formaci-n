using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestorFunc : MonoBehaviour
{
    //Singleton(puerta) para acceder a este script
    public static GestorFunc instancia;
    //Cómo creamos un func
    //Siempre tendrá valor de retorno(si solo hay uno será ese el que devolvamos)
    public Func<Material> OnMaterial;
    //Objeto sobre el que aplicar cambios
    public GameObject auxiliar;
    //Func con parámetros: Los parámetros son los que van por delante del último(éste es un valor de retorno)
    public Func<float, float, int> OnCalculo;


    void Awake()
    {
        instancia = this;
    
    }

    private void Update()
    {
        //Activo el evento que aplica un material
        //El material se aplicará al objeto que yo decida
        if (Input.GetKeyDown(KeyCode.F))
        {
            auxiliar.GetComponent<Renderer>().material = cambioMaterial();
        }
    }

    //Creamos una función para activar el evento
    public Material cambioMaterial()
    {
        //Retornamos null si no hay suscriptores
        return OnMaterial?.Invoke() ?? null;
    }

    //Función que activa el evento
    public int activaOperacion(float num1, float num2)
    {
     

       //Versión larga para checkear si hay suscriptores
       if(OnCalculo != null)
        {
            return OnCalculo(num1, num2);
        }
        else
        {
            Debug.LogWarning("No hay suscriptores");
            return 0;
        }
    } 
}
