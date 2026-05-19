using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Humorista
{
    [SerializeField]
    private string Name;
    [SerializeField]
    private string ArtisticName;
    [SerializeField]
    private float Cache;
    [SerializeField]
    private int ShowsNumbers;
    [SerializeField]
    private List <Chiste> chistes = new List<Chiste>();
    

//Constructores

    public Humorista() { }
    public Humorista( string name, string artisticName, float chache, int showsnumbers) 
    { 
        Name = name;
        ArtisticName = artisticName;
        Cache = chache;
        ShowsNumbers = showsnumbers;
    }


    //Getters y Setters

    public string GetNombre() 
    {
        return Name;

    }
    public void SetNombre(string n)
    {
        Name = n;
    }
    public string GetArtisticName() 
    { 
     return ArtisticName;
    }
    public void SetArtisticName(string a)
    {
        ArtisticName = a;
    }
    public float GetCache()
    {
        return Cache;

    }
    public void SetCache(float c)
    {
        Cache = c;
    }
    public int GetShowNumbers()
    {
        return ShowsNumbers;

    }
    public void SetShowsNumbers(int s)
    {
        ShowsNumbers = s;
    }

    //Métodos

    public Chiste ContarChistes()
    {
        int aleatorio = UnityEngine.Random.Range(0, chistes.Count);

        Chiste nuevoChiste = chistes[aleatorio];

        return nuevoChiste;
    }
    
    public void CrearChiste( string textoChiste, Chiste.Tipo tipo)
    {
        Chiste c = new Chiste(textoChiste, tipo);
        chistes.Add(c);
    }


}
