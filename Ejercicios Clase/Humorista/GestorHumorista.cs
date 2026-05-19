using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestorHumorista : MonoBehaviour
{
    public Humorista Humorista;
    [SerializeField]
    private Humorista Humorista2;
    public TMP_Text texto;

    // Start is called before the first frame update
    void Start()
    {
        Humorista2= new Humorista("Jofra Eugenio","Eugenio",7000,80);
        Humorista2.CrearChiste("¿Saben aquel que diu que había un hombre tan feo, pero tan feo, que cuando nació el que lloró fue el médico?", Chiste.Tipo.blanco);
        Humorista2.CrearChiste("¿Saben aquel que diu que un hombre está rezando y dice: Dios mío, dame paciencia. ¡¡¡Pero dámela ya!!!", Chiste.Tipo.negro);
        Humorista2.CrearChiste("¿Saben aquel que diu que una señor va a ver a una adivina, y esta le dice: su marido será alto, guapo, rico y generoso. Y ella le contesta: Uy, qué bien. ¿Y qué hago con el que tengo?", Chiste.Tipo.verde);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
           Chiste chisteActual =  Humorista2.ContarChistes();
            texto.text = chisteActual.textoChiste;
        }
    }
}
