using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorPokimon : MonoBehaviour
{
    public PokemonAgua Squirtle;
    public PokemonFuego Charmeleon;

    //public List<Pokemon> lista = new List<Pokemon>();

    void Start()
    {
        Squirtle = new PokemonAgua("Squirtle", 9, "BuceoBall", 10, "Planta");
        Charmeleon = new PokemonFuego("Charmeleon", 5, "FlamaBall", 50);

        print(Squirtle.cualEsTuPokeball());
        Squirtle.saludoPokemon();
        Charmeleon.saludoPokemon();

        print("El total de pokemones creado " + Pokemon.GetTotalPokemones());

        //La clase pokedex es static, por lo tanto, no necesita ser "creada" para ser utilizada
        Pokedex.analizarPokemon(Charmeleon);

        Squirtle.AtaqueEspecial();
        Charmeleon.AtaqueEspecial();
        print(Squirtle.ratioCaptura(23));
    }

  
}
