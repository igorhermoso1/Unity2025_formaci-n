using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action2 : MonoBehaviour
{
    
    void Start()
    {
        //Nos suscribimos la action simple
        GestorAction.instancia.OnActionSimple += soySuscriptor2;
    }

    public void soySuscriptor2()
    {
        print("Estoy suscrito al action simple. Soy : " + this.gameObject.name);
    }
   
    public void OnDisable()
    {
        GestorAction.instancia.OnActionSimple -= soySuscriptor2;
    }
}
