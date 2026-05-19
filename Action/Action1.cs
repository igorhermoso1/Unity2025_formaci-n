using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action1 : MonoBehaviour
{

    void Start()
    {
        //De esta forma suscribo un método a un action
        GestorAction.instancia.OnActionSimple += escalarObjeto;
        //Nos suscribimos al actionComplejo
        GestorAction.instancia.OnActionComplejo += accionesComplejasDeActionComplejoDificilNoEntiendoPatioYa;
    }

    //Esta función se ejecutará cuando se invoque el action
    public void escalarObjeto()
    {
        
        this.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
    //Los métodos suscritos tienen que corresponder con los parámetros del Action
    public void accionesComplejasDeActionComplejoDificilNoEntiendoPatioYa(string texto,
                                                                          Material mat)
    {
        this.gameObject.name = texto;
        this.GetComponent<Renderer>().material = mat;   
    }

}
