using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDelegado : MonoBehaviour
{
    //Creamos un singleton(una puerta para acceder a este código)
    public static GestorDelegado instancia;
    //Creación de Delegado(evento) solo creo el tipo
    public delegate void OnEventoSimple();
    //Ahora sí, creo un delegado de ESE tipo
    public OnEventoSimple eventoSimple;

    public delegate bool eventoComplejo(int edad);
    public eventoComplejo OnEventoComplejo;

    void Awake()
    {
        instancia = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            activarEventoSimple();
        }
    }

    //Cómo se activa un delegado? Para ello recurrimos a Invoke(invoca a una función)
    public void activarEventoSimple()
    {
        //Los eventos funcionan con suscriptores. Para lanzar un evento...
        //Hay que mirar que existan suscriptores.
        //Shortcut:
        eventoSimple?.Invoke();
       
    }

    public bool activarEventoComplejo(int edad)
    {
        if (OnEventoComplejo != null)
        {

             OnEventoComplejo(edad);
            return true;
        }
        return false;

    }
    
}
