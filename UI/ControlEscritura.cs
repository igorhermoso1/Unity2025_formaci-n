using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlEscritura : MonoBehaviour
{
    public TMP_Text txtFrase;

    public Coroutine coroutineActual;

    public AudioSource reproductorEfectoEscritura;

    [TextArea(6,10)]
    public string palabra;

    [Range(0.1f,0.3f)]
    public float velocidadEscritura;

    private void Start()
    {
        //Asigno y lanzo la corutine actual. EfectoEscritura recibe un lapso entra letra y lera
        coroutineActual = StartCoroutine(efectoEscritura(velocidadEscritura));
    }

    //Corutina que despedaza una cadena de texto y muestra letra a letra a una velocidad determinada
    public IEnumerator efectoEscritura(float velocidadEscritura)
    {
        //Limpio el texto
        txtFrase.text = "";
        //Recorro cada char de la cadena de texto(string)
        //Por cada char en la palabra X:
        foreach (char letra in palabra)
        {
            //Añado la letra que toca
            txtFrase.text += letra;
            //Reproducir el efecto una vez
            if (!reproductorEfectoEscritura.isPlaying) { 
                 reproductorEfectoEscritura.PlayOneShot(reproductorEfectoEscritura.clip);
            }
            //Espero un poco o el tiempo especificado para ir a la siguiente letra
            yield return new WaitForSeconds(velocidadEscritura);
        }
        //Como ha terminado, desvinculo la corutina actual de coroutineActual
        coroutineActual = null;
     }


}
