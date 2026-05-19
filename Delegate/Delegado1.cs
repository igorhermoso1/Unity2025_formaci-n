using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegado1 : MonoBehaviour
{
    
    void Start()
    {
        //Me surcribo al delegado a través del singleton....
        //...le paso la FUNCIÓN que yo quiero vincular
        GestorDelegado.instancia.eventoSimple += suscriptorSimple;
        GestorDelegado.instancia.OnEventoComplejo += suscriptorComplejo;
    }

    public void suscriptorSimple()
    {
        print("HOLA, SOY SUSCRIPTOR DEL DELEGADO");
    }

    public bool suscriptorComplejo(int edad)
    {
        if (edad > 18)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnMouseDown()
    {
        print(GestorDelegado.instancia.activarEventoComplejo(12));
    }
}
