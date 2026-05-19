using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Agregamos la cabecera System para, entre otros, poder editar desde Unity

//De esta forma creamos una clase simple
//Serializable nos permite editar desde el inspector de Unity la info de la clase
[Serializable]
public abstract class Pokemon 
{
    //Atributos de clase, formados por: ámbito(private/public) + tipo + nombre;
    //=========================================================================
    [SerializeField]
    private string nombre;
    [SerializeField]
    private int numero;
    [SerializeField]
    private string tipoPokeball;
    //Static indica que algo puede ser editado o consultado sin ser instanciado(no crear variable)
    public static int totalPokemons = 0;

    //Constructores:
    //==============
    //Indica cómo se va a crear un objeto de esta clase
    //Podemos tener un constructor vacío...
    public Pokemon() { }
    //Podemos crear un constructor con toda la información necesaria:
    //Entre paréntesis recibira los parámetros necesarios para rellenar su información
    public Pokemon(string nuevoNombre, int nuevoNumero, string nuevoTipoPokeball)
    {
        //Asignamos los parámetros a los atributos de la clase
        nombre = nuevoNombre;
        numero = nuevoNumero;
        tipoPokeball = nuevoTipoPokeball;
        totalPokemons++;
    }
    //===============================================================================
    //Getters y Setters
    //Puertas de acceso a los atributos privados de la clase
    //Get para consultar y Set para escribir o editar
    public string GetNombre()
    {
        return nombre;
    }
    public void SetNombre(string nuevoNuevo)
    {
        this.nombre = nuevoNuevo;
    }
    public int GetNumero()
    {
        return numero;
    }
    public void SetNumero(int nuevoNumero)
    {
        this.numero = nuevoNumero;
    }
    public string GetTipoPokeball()
    {
        return tipoPokeball;
    }
    public void SetTipoPokeball(string tipoPokeball)
    {
        this.tipoPokeball = tipoPokeball;  
    }
    //Métodos
    //ámbito + valor de retorno + nombreFuncion(tipoParametro + nombreParametro){
    //  Código que toque.
    //  return (si es que tiene que devolver algo, es decir, NO es void)
    //} 
    public void saludoPokemon()
    {   //Mostramos por consolda su nombre
       Debug.Log(this.GetNombre() + "-" + this.GetNombre()+ " (está saludando)");
    }
     //La cabecera virtual indica que este método puede ser sobreescrito
    public virtual string cualEsTuPokeball()
    {
        return "";
    }
    //Abstract obliga a los hijos de esta clase a redefiniar OBLIGATORIAMENTE el método
    //Este método será redefinido desde los hijos
    public abstract void AtaqueEspecial();


    public static int GetTotalPokemones()
    {
        return totalPokemons;
    }
    //Equals nos permite comparar elementos de la misma clase ¿Cómo?
    //Creando una regla de comparación o comparativa
    public override bool Equals(object obj)
    {
        if(obj == null || !(obj is Pokemon))
        {
            return false;
        }
        //Este atributo es el que vamos a utilizar para comparar
        return this.numero == ((Pokemon)obj).numero;
       
    }
    public override int GetHashCode()
    {
        return numero.GetHashCode();
    }
    //Método que se empleada para devolver la información de un objeto en TEXTO
    //Podemos editarlo a nuestro gusto
    public override string ToString()
    {
        return "Información del Pokemon: " +this.nombre + " " + this.numero;
    }
}
