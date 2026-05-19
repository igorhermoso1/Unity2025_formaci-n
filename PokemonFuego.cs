using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PokemonFuego : Pokemon
{
    [SerializeField]
    private float grados;

    public PokemonFuego(){}
    public PokemonFuego(string nombre, int numero, string pokeball, float grados)
                        : base(nombre,  numero, pokeball)
    {
        this.grados = grados;
    }
    public float GetGrados()
    {
        return grados;
    }
    public void SetGrados(float grados)
    {
        this.grados = grados;
    }

    public override string cualEsTuPokeball()
    {
        return "Soy de tipo fuego. Me capturas con : " + GetTipoPokeball();
    }

    public override void AtaqueEspecial()
    {
        Debug.Log("Perro Sánchez");
    }
}
