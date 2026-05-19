using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]


public class Chiste
{
    public string textoChiste;
    public enum Tipo {negro, verde, blanco};
    public Tipo tipo;

    //Constru

    public Chiste() { }
    public Chiste(string textoChiste, Tipo tipo)
    {
        this.textoChiste = textoChiste;
        this.tipo = tipo;
    }



}
