using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting.FullSerializer;

[Serializable]
//Para indicar herencia tenemos que escribir : y la clase de la que heredamos
//Heredamos para compartir atributos, métodos, constructores, etc...
public class PokemonAgua : Pokemon, ICapturable
{
    //Atributo de clase que indica los metros que puede bucear
    [SerializeField]
    private float metrosBuceo;
    [SerializeField]
    private string debilidad;
    //Constructor
    //base hace referenciar a la clase padre
    //Este constructor vacío hereda de el constructor vacío del padre
    public PokemonAgua() { }
    //Constructor con todos los atributos y con :base hacemos referencia O MANDAMOS
    // al constructor del padre los campos que le correspondan
    public PokemonAgua(string nuevoNombre, int nuevoNumero, string nuevoTipoPoke, 
                       float nuevosMetrosBuceo, string nuevaDebilidad ) 
                       : base(nuevoNombre, nuevoNumero, nuevoTipoPoke)
    {
        this.metrosBuceo = nuevosMetrosBuceo;
        this.debilidad = nuevaDebilidad;
    }
    //Getters y Setters
    public float GetMetrosBuceo()
    {
        return metrosBuceo;
    }
    public void SetMetrosBuceo(float metrosBuceo)
    {
        this.metrosBuceo= metrosBuceo;
    }
    public string GetDebilidad() {
        return this.debilidad;

    }
    public void SetDebilidad(string debilidad)
    {
        this.debilidad = debilidad;
    }
    
    //Hacemos override del método virtual del padre(opcional)
    public override string cualEsTuPokeball()
    {
        return "Soy de tipo agua. Me capturas con : " + GetTipoPokeball() ;
    }

    public override void AtaqueEspecial()
    {
       Debug.Log("ATAQUE ESPCIAL DE AGUA. Daño " +  this.metrosBuceo/2f);
    }

    public  float ratioCaptura(float ratio)
    {
        return ratio * (this.GetNumero()%100);
    }
    public void decirWenceslao()
    {
        Debug.Log("Wenceslao"); 
    }
}

