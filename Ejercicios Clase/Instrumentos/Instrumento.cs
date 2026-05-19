using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Instrumento
{
    [SerializeField]
    private string nombre;
    [SerializeField]
    private string familia;
    [SerializeField]
    private string material;
    [SerializeField]
    private float tamanio;

    public static int totalInstrumento=0;
    public Instrumento() {
            totalInstrumento++;
    }
    public Instrumento(string nuevoNombre, string nuevaFamilia, string nuevoMaterial,
                       float nuevoTamanio)
    {
        nombre = nuevoNombre;
        familia = nuevaFamilia;
        material = nuevoMaterial;
        tamanio = nuevoTamanio;
        totalInstrumento++;
    }
    public Instrumento(string nuevoNombre, string nuevoFamilia)
    {
        nombre= nuevoNombre;
        familia = nuevoFamilia;
        totalInstrumento++;
    }

    public string GetNombre()
    {
        return nombre;
    }
    public void SetNombre(string nuevoNombre)
    {
        this.nombre = nuevoNombre;
    }
    public string GetFamilia()
    {
        return this.familia;
    }
    public void SetFamilia(string nuevaFamilia)
    {
        this.familia = nuevaFamilia;
    }
    public string GetMaterial()
    {
        return this.material;
    }
    public void SetMaterial(string nuevoMaterial)
    {
        this.material = nuevoMaterial;
    }
    public float GetTamanio()
    {
        return this.tamanio;
    }
    public void SetTamanio(float nuevoTamanio)
    {
        this.tamanio = nuevoTamanio;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Instrumento))
        {
            return false;
        }
        return this.tamanio == ((Instrumento)obj).tamanio;
    }
    public override int GetHashCode()
    {
        return tamanio.GetHashCode();
    }
    public override string ToString()
    {
        return "El instrumento se llama " + this.GetNombre() + ". Familia : " + this.GetFamilia();
    }
    public void Sonar()
    {
        Debug.Log("Sueno así: " + this.GetFamilia() + " " + this.GetMaterial());
    }
    public void CambioMaterial(string materialNuevo)
    {
        if (materialNuevo == "Metal" && this.GetFamilia() == "Cuerda")
        {
            Debug.LogError("ERROR. Un instrumento NO puede ser de metal y cuérdico");
        }
        else {
            this.SetMaterial(materialNuevo);
        }
    }

    public abstract void Reproducir();


}