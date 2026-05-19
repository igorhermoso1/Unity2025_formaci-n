using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PerroSanchez : MonoBehaviour
{
    //Variables
    [SerializeField]
    private Material materialPerroSanchez;
    [SerializeField]
    private Material materialOtro;
    private Renderer renderPerroSanchez;
    private Renderer renderOtro;
    //Variable para guardar el prefab para instanciarlo cuando sea necesario
    [SerializeField]
    private GameObject prefabPerroSanchez;
    private void Start()
    {
        //This hace referencia al objeto que tiene el script
        materialPerroSanchez = this.GetComponent<Renderer>().material;
        //Guardamos el componente renderer
        renderPerroSanchez = this.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //La información del objeto contra el que colisiono collision
        //Por lo tanto collision es también un GameObject
       //1)Guardo el material del objeto colisionado
        materialOtro = collision.gameObject.GetComponent<Renderer>().material;
        //2)También guardo el componente Renderer del objeto colisionado
        renderOtro = collision.gameObject.GetComponent<Renderer>();
        //3) Intercambiamos los materiales
        renderPerroSanchez.material = materialOtro;
        renderOtro.material = materialPerroSanchez;
        //4) Crear ALGO aleatorio
        //Random.Range(min,max) devuelve un número aleatorio entre el min y el max
        
        Vector3 posicionAleatoria = new Vector3(Random.Range(-5,5), 11, Random.Range(1, 5));
        //5) Instanciar un objeto
        //Instantiate(prefab, posición, rotación)
        GameObject temporal = Instantiate(prefabPerroSanchez, posicionAleatoria, Quaternion.identity);
        //6) Cómo se desactiva un objeto?
        this.gameObject.SetActive(false);
        //7) Cómo se destruimos un objeto)
        Destroy(this.gameObject, 1f);
    }

    private void OnCollisionExit(Collision collision)
    {
        //Es parecido pero al contrario...
        //1) Le asigno su material original ya que previamente se lo he robado
        renderOtro.material = renderPerroSanchez.material;
        //2)Entonces me asigno el material que he guardado al principio
        renderPerroSanchez.material = materialPerroSanchez;
    }
}