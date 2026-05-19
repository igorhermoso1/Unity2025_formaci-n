using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


//Una clase static permite utilizar métodos o funciones sin la necesidad
// de crear elementos/objetos de esta clase
public static class Pokedex
{
    //Esta clase tiene un método que devuelve la información del Pokemon recibido
    public static void analizarPokemon(Pokemon poke)
    {
        // Debug.Log("Entrada" + poke.ToString());
        //Con is podemos preguntar por el tipo de objeto específico dentro de una jerarquía de clases
        if (poke is PokemonAgua)
        {

            Debug.Log("Entrada: Pokemon de tipo Agua. " + poke.ToString());
        }
        else if (poke is PokemonFuego) {
            Debug.Log("Entrada: Pokemon de tipo Fuego. " + poke.ToString());
        }
    }
    
}
