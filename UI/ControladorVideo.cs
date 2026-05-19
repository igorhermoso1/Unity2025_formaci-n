using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControladorVideo : MonoBehaviour
{
    //Variable para guardar el vídeo
    public VideoPlayer video;
    //Vairable para conocer el progreso
    public float progreso;
    //NOTAS:
    //video.time: video.time el momento actual de la reproducción del vídeo
    //video.length:  video.length la duración total del vídeo
    //video.clip:  video.clip.name el clip que se está reproduciendo o que está cargado en el Video Player

    private void Start()
    {
        //VideoPlayer tiene un evento para cargar el vídeo al comienzo: PrepareCompleted.
        //Nos suscribimos a este evento para que al comienzo suceda algo(lo que sea)
        //Por lo tanto, crearemos una función(inicioVideo) que se suscribirá al evento
        video.prepareCompleted += inicioVideo;
        //.Prepare() fuerza al vídeo a estar listo
        video.Prepare();
        //Cuando el video llega al final se lanza el evento loopPointReached, es decir, el final...
        //cuando llega al final, lanzaré la función que vaya a otra escena
        video.loopPointReached += finVideo;

  
    }
    private void Update()
    {
        /*
         * Sacar el progreso del vídeo player
        progreso = (float)(video.time / video.length);
        print("Progreso " + (progreso * 100) + "%");
        */
    }
    public void inicioVideo(VideoPlayer video)
    {
        /*Para ir a un segundo determinado del vídeo utilizaremos .time*/
        video.time = video.length - 50f;
    }
    public void finVideo(VideoPlayer video)
    {
        //Ahora que ya hemos llegado al final iremos a la escena oportuna
        SceneManager.LoadScene("GestionAlumnos");
    }
}
