using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Receta 
{//atributo
    [SerializeField]
    private string nombre;
    [SerializeField]
    private string ingrediente1;
    [SerializeField]
    private string ingrediente2;
    [SerializeField]
    private int duracion;

    //constructor
    public Receta() { }
    public Receta(string nombre, string ingrediente1, string ingrediente2, int duracion)
    {
        this.nombre = nombre;
        this.ingrediente1 = ingrediente1;
        this.ingrediente2 = ingrediente2;
        this.duracion = duracion;
    }
    //getters, setters
    public string GetNombre()
    { return nombre; }
    public void SetNombre(string nombre) {  this.nombre = nombre; }

    public string GetIngrediente1()
    { return ingrediente1; }
    public void SetIngrediente1(string ingrediente1) { this.ingrediente1 = ingrediente1; }
    public string GetIngrediente2()
    { return ingrediente2; }
    public void SetIngrediente2(string ingrediente2) { this.ingrediente2 = ingrediente2; }

    public int GetDuracion() { return duracion; }
    public void SetDuracion(int d) { this.duracion = d;}
    public override bool Equals(object obj)
    {
        if (obj == null||!(obj is Receta))
        {
        return false;
        }
        return this.duracion==((Receta)obj).duracion;
    }
    public override int GetHashCode()
    {
        return duracion.GetHashCode();
    }

}
