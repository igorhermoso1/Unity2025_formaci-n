using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Guitarra : Instrumento
{
    [SerializeField]
    private string marca;
    [SerializeField]
    private string tipo;

    public Guitarra() : base() { }
    public Guitarra(string nom,string fam, string mat, float tam, string nuevaMarca,
                    string nuevoTip) :base(nom, fam, mat, tam)
    {
        this.marca = nuevaMarca;
        this.tipo = nuevoTip;
    }  
    public Guitarra(string nom, string fam, string nuevaMarca, string tipo)
                    :base(nom, fam)
    {
        this.marca = nuevaMarca;
        this.tipo = tipo;
    }

    public string GetMarca()
    {
        return this.marca;
    }
    public void SetMarca(string nuevaMarca)
    {
        this.marca= nuevaMarca;
    }
    public string GetTipo()
    {
        return this.tipo;
    }
    public void SetTipo(string nuevoTipo)
    {
        this.tipo = nuevoTipo;
    }

    public void PaquitoLusia(string textoCancion)
    {
        if (textoCancion.Contains("aguas"))
        {
            Debug.Log("TRUE");
        }
        else
        {
            Debug.Log("Not Aquas");
        }
    }

    public override void Reproducir()
    {
        Debug.Log("Soy una guitarra y tengo este sonido: crank, tocotó");
    }

}
