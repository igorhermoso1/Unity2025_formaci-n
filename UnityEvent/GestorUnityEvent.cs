using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Tenemos que importar la cabecera UnityEngine.Events;
public class GestorUnityEvent : MonoBehaviour
{
    //Creamos el singleton(puerta) para acceder a los eventos
    public static GestorUnityEvent puerta;
    
    //Creamos un Unity Event simple
    public UnityEvent OnUnityEventSimple;

    //Creamos un Unit Event complejo
    public UnityEvent<float> OnUnityEventComplejo;
    void Awake()
    {
        puerta = this;    
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            activaUnityEvent();
        }
    }
    //Funcón para activar el evento
    public void activaUnityEvent()
    {
        //Activamos el evento
        OnUnityEventSimple?.Invoke();
       
    }
    //Función para activar el complejo
    public void activarUnityEventComplejo(float escala)
    {
        OnUnityEventComplejo?.Invoke(escala);
    }
}
