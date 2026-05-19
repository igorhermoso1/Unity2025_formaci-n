using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestorPrincipal : MonoBehaviour
{
    //Variable para el panel de Personajes
    public GameObject panelPersonajes;
    //Variable para el canvas group del panel de personajes
    public CanvasGroup canvasGroupPanelPersonajes;
    //Variable para el canvas groupd del panel de la selección final
    public CanvasGroup canvasGroupPanelSeleccionFinal;
    //Variable para editar la duración de la interpolación de los objetos
    [Range(0.1f, 2f)]
    public float duracion;
    private void Start()
    {
        //Suscripción a la corutina
        GestorPersonajes.instance.OnPanelSeleccionFinal += mostrarPanelSeleccionFinal;
    }

    public CanvasGroup GetCanvasGroupPanelSeleccion()
    {
        return canvasGroupPanelSeleccionFinal;
    }

    public CanvasGroup GetCanvasGroupPanelPersonajes()
    {
        return canvasGroupPanelPersonajes;
    }
   
    //Función para mostrar la selección final
    public void mostrarPanelSeleccionFinal()
    {
        //Llamamos a corutina que muestra un panel(cambia el alpha) y...
        //...el parámetro true indica que detectará el click
        StartCoroutine(Corutine_gestionarPanelPersonajes(canvasGroupPanelSeleccionFinal,
                                                          duracion, 0f, 1f, true));
    }


    //Función que recibe un bool(estado) y llama a la Corutine para gestionar el panel
    public void gestionarPanelPersonajes(bool estado)
    {
        //Si el estado es true sé que tengo que ir de 0 en alpha a 1 en alpha
        if (estado == true)
        {
            //Llamamos a la Corutine
            StartCoroutine(Corutine_gestionarPanelPersonajes(canvasGroupPanelPersonajes,
                                                            duracion, 0f, 1f, estado));
        }
        else if (estado == false) {

            //Llamamos a la Corutine
            StartCoroutine(Corutine_gestionarPanelPersonajes(canvasGroupPanelPersonajes,
                                                           duracion, 1f, 0f, estado));
        }
    }
    //Corutine para interpolar de un valor a otro(copy&paste my rey)
    public IEnumerator Corutine_gestionarPanelPersonajes(CanvasGroup canvasGroup,
                                                         float duracion, float origen, float destino,
                                                         bool estado)
    {
        float elapsed = 0f;
        while (elapsed < duracion) { 
            elapsed += Time.deltaTime;
            float tiempoTranscurrido = elapsed / duracion;
            //Modificamos el atributo que sea necesario. En este caso el alpha
            canvasGroup.alpha = Mathf.Lerp(origen, destino, tiempoTranscurrido);
            yield return null; 
        }
        //Una vez que ya hemos hecho la transición....ahora decimos que SÍ detecte el click
        canvasGroup.blocksRaycasts = estado;
    }

    //Ejemplo: Corutina que espera unos segundos entre varias acciones
    /*
    public IEnumerator ejemplo(float segundo)
    {
        print("HOLA");
        yield return new WaitForSeconds(segundo);
        print("ADIOS");
    }
    */
}
