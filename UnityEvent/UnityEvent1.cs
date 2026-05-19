using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent1 : MonoBehaviour
{
    private bool meMuevo= false;
    void Start()
    {
        //Los suscriptores a UnityEvent se realizan mediante AddListener(nombre de función)
        GestorUnityEvent.puerta.OnUnityEventSimple.AddListener(movimiento);
        GestorUnityEvent.puerta.OnUnityEventComplejo.AddListener(escalarComplejo);
        //RemoveListener eliminar un suscriptor específico
        //GestorUnityEvent.puerta.OnUnityEventComplejo.RemoveListener(escalarComplejo);   
    }

    public void movimiento()
    {
        meMuevo = true;
    }

    public void escalarComplejo(float valor)
    {
        this.transform.localScale = new Vector3(valor, valor, valor);
    }
    void Update()
    {
        //Si la variable meMueve es true...me muevo
        if (meMuevo == true)
        {
            this.transform.Translate(Vector3.up * 5 * Time.deltaTime);
        }
    }
}
