using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Func1 : MonoBehaviour
{
    
    void Start()
    {
        //Suscripción al Func
        GestorFunc.instancia.OnMaterial += suscripcionSimple;
    }

    public Material suscripcionSimple()
    {
        //Tenemos que devolver un Material
        return this.GetComponent<Renderer>().material;
    }
}
