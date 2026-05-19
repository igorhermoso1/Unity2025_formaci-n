using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="Heroe", menuName ="Scriptables/Heroe")]

public class Heroe : ScriptableObject, IComparable<Heroe>
{
    public string nombre;
    public Sprite foto;
    [TextArea(5,7)]
    public string descripcion;
    public int id;

    //Función para poder comparar un objeto con otro(en base al ID) y ordenar la lista


    public int CompareTo(Heroe other)
    {
      return this.id.CompareTo(other.id);
    }
}
