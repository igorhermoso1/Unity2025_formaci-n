using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploVectores : MonoBehaviour
{

    //Un Vector3 es un punto en el mapa
    public Vector3 punto;
    //Guardo el transform del objeto
    private Transform miTransform;
    //Variable para la velocidad
    [SerializeField]
    private float velocidadMovimiento;
    
    void Start()
    {
        //Para guardar el transform directamente accedemos desde this. o el objeto correspondiente
        miTransform = this.transform;
        //Asigno el Vector3, la posición, a mi position
        //miTransform.position = punto;
    }

    // Update is called once per frame
    void Update()
    {
        //Para moverlo accederemos al Update.
        //Translate nos permite mover objetos siguiendo la siguiente relga:
        //Y aplicamos la siguiente regla: dirección * velocidad * Time.deltaTime;
        //Vector3 YA tiene una colección de direcciones
         miTransform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);
        
    }
}
