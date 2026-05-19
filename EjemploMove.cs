using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploMove : MonoBehaviour
{
    public Transform miTransform;
    //Variable para almacenar el destino del movimiento
    public Transform destino;
    //Variable para la velocidad de movimiento
    public float velocidadMovimiento;
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Ahora nos moveremos de punto a punto
        //Necesitamos (origen, destino, velocidad*Time.deltaTime)
        miTransform.position = Vector3.MoveTowards(miTransform.position,
                                                  destino.position,
                                                  velocidadMovimiento * Time.deltaTime);

    }
}
