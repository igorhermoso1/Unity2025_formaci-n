using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ControladorDiccionarios : MonoBehaviour
{
    //Variable del texto
    public TMP_Text texto;
    public string situacional;
    //Cómo creamos un diccionario:
    public Dictionary<string, string> animales = new Dictionary<string, string>()
     {
         {"Capibara", "Roedor gurdo, feo, tonto y pestilente" },
         {"Zebra" , "Equino exótico blanco y negro" }
     };


    private void Start()
    {
        //Añadir entradas al diccionario
        animales.Add("Perro", "Mamífero bonito o no, de la familia del canis lupus familiaris");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            accederSimple(situacional);
            //accesoComplejo(situacional);
            //recorrerDiccionario();
        }
    }


    //1) Acceder a un elemento
    public void accederSimple(string claveABuscar)
    {
        //Try fuerza a contemplar ciertos errores que pueden surgir en el código
        try
        {
            texto.text = animales[claveABuscar];

        }catch(Exception e)
        {
            //En catch aplicamos un tratamiento ante el error
            texto.text = "ERROR. Animal desconocido";
        }
        
    }
    
    //2) Acceder a un elemento con cuidado y con validación
    public void accesoComplejo(string claveABuscar)
    {
        //Variable para almacenar el valor/significado
        string animalEncontrado;

        //Preguntar si existe la clave
        if(animales.TryGetValue(claveABuscar, out animalEncontrado))
        {
            texto.text = animalEncontrado;
        }
        else
        {
            texto.text = "ANIMAL NO ENCONTRADO";
        }
    }
    //3) Recorremos el diccionario
    public void recorrerDiccionario()
    {
        //Vaciamos el texto
        texto.text = "";
        //Recorremos una lista con FOREACH
        //Por cada elemento(entrada) en el diccionario los mostraremos en el texto
        foreach (KeyValuePair<string, string> entrada in animales)
        {
            //Para acceder a la clave pondremos entrada.key
            //Para acceder al valor pondremos entrada.value
            texto.text += "Clave "  + entrada.Key  + ": " + entrada.Value + "\n";
        }

    }
    //3) Recorrer solo valor
    public void recorrerSoloValor()
    {
        foreach(string significado in animales.Values)
        {
            //print(significado);
        }
    }
    //3) Recorrer solo key
    public void recorrerSoloKey()
    {
        foreach (string clave in animales.Keys)
        {
            //print(clave);
        }
    }

    //4) Comprobar si contiene clave
    public void comprobarSiTieneClave(string preguntaPorClave)
    {
        //ConstainsKey nos permite mirar si existe una clave específica
        if (animales.ContainsKey(preguntaPorClave) == true)
        {
            print("Existe");
        }
        else
        {
            print("NO existe la clave "+ preguntaPorClave); 
        }
        //ContainsValue pregunta por un valor
        //animales.ContainsValue(valorAPreguntar);
    }

    //5) Eliminar un entrada
    public void eliminarEntrada()
    {
        //Eliminamos con Remove la clave que va entre paréntesis
        animales.Remove("Perro");
    }

}
