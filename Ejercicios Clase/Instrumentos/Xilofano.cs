using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Xilofano : Instrumento
{
    [SerializeField]
    private int numPlacas;

    public Xilofano() : base() { }
    public Xilofano(string nom, string fam, string mat, float tam, int nuevoNumPlacas) 
                    : base(nom, fam, mat, tam)
    {
         numPlacas = nuevoNumPlacas;
    }
    public Xilofano(string nom, string fam, int nuevoNumPlacas)
                   : base(nom, fam)
    {
        numPlacas=nuevoNumPlacas;
    }
    public int GetNumPlacas() { return numPlacas; }
    public void SetNumPlacas(int nuevoNumPlacas)
    {
        this.numPlacas = nuevoNumPlacas;
    }
    public void Soporte(bool patas)
    {
        if (patas == true)
        {
            Debug.Log("Necesita soporte");
        }
        else
        {
            Debug.Log("No necesita soportes");
        }
    }
    public override void Reproducir()
    {
        Debug.Log("Soy Xilófono y punto");
    }
}
