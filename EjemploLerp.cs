using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploLerp : MonoBehaviour
{
    public Transform miTransform;
    public float velocidadMovimiento;
    public Transform destino;
    public float transcurrido;
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Guardo en transcurrido lo que ya tenemos más el tiempo
        transcurrido = transcurrido + Time.deltaTime;
        //Calculamos el completado
        float completado = transcurrido / velocidadMovimiento;
        //Nos movemos dentro de la línea de progreso
        miTransform.position = Vector3.Lerp(miTransform.position,
                                                destino.position,
                                                completado);
    
    
    }
}
