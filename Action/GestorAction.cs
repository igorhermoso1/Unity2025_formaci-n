using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestorAction : MonoBehaviour
{
    //Singleton(acceso static a un atributo de la clase)
    public static GestorAction instancia;
    //Creación de Action
    public Action OnActionSimple;
    //Creación de Action Complejo
    public Action<string, Material> OnActionComplejo;
    //Variable para el material a mandar
    public Material materialAzul;
    void Awake()
    {
        instancia = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            ejecutarAccionSimple();

        }
    }
    //Método encargado de lanzar la action
    public void ejecutarAccionSimple()
    {
       
        //Invocamos la action y realizamos el check de si es null o no
        OnActionSimple?.Invoke();   
    }
    //Método encargado de lanza la action complejo
    public void ejecutarAccionCompleja()
    {
        //Invocamos la action compleja
        OnActionComplejo?.Invoke("Azul", materialAzul);
    }

}
