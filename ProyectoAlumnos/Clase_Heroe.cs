using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class Clase_Heroe 
{
    [SerializeField]
    private string nombre;
    [SerializeField]
    private int id;
    [SerializeField]
    private Sprite foto;
    [SerializeField]
    private string descripcion;

    public Clase_Heroe() { }
    public Clase_Heroe(string nombre, int id, Sprite foto, string descripcion)
    {
        this.nombre = nombre;
        this.id = id;
        this.foto = foto;
        this.descripcion = descripcion;
    }

    public Clase_Heroe(Heroe scriptableHeroe)
    {
        this.nombre = scriptableHeroe.nombre;
        this.id = scriptableHeroe.id;
        this.foto = scriptableHeroe.foto;
        this.descripcion = scriptableHeroe.descripcion;
    }

    public string GetNombre()
    {
     return this.nombre;
    }
    public int GetId()
    {
        return this.id;
    }
    public Sprite GetFoto() {
        return this.foto;
    }
    public string GetDescripcion()
    {
        return this.descripcion;
    }

    public void SetNombre(string nombre)
    {
        this.nombre = nombre;
    }
    public void SetId(int id)
    {
        this.id=id;
    }
    public void SetDescripcion(string descripcion)
    {
        this.descripcion=descripcion;
    }
    public void SetSprite(Sprite sprite)
    {
        this.foto = sprite;
    }


}
