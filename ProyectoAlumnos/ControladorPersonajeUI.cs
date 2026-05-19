using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
public class ControladorPersonajeUI : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text txtNombre;
    public Image imgFoto;
    public Clase_Heroe heroeAsignado;
    public Image borde;
    public bool seleccionado=false;

    public void recibirHeroe(Clase_Heroe clase_Heroe)
    {
        heroeAsignado = clase_Heroe;
        imgFoto.sprite = heroeAsignado.GetFoto();
        txtNombre.text = heroeAsignado.GetNombre();
    }
    public string GetTxtNombre()
    {
        return txtNombre.text;
    }
    public Sprite GetImageFoto()
    {
        return imgFoto.sprite;
    }
    public ControladorPersonajeUI GetControladorPersonaje()
    {
        return this.GetComponent<ControladorPersonajeUI>();
    }
    public bool GetSeleccionado()
    {
        return seleccionado;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
   
        //Desactivo la imagen, o al menos la posible interacción
        imgFoto.raycastTarget = false;

        //Cuando se haga lcik activamos el borde
        //gameObject.ActiveSelf no dice si un objeto está encendido(true) o apagado(false)
        borde.gameObject.SetActive(!borde.gameObject.activeSelf);

        //Controlamos la selección del personaje
        seleccionado = !seleccionado;

        //Solo guardamos la selección si el objeto NO está seleccionado
        if (seleccionado == true)
        {
            //Mando el heroe creado y asignado de este objeto
            GestorPersonajes.instance.guardarSeleccion(this.heroeAsignado);
        }
        else if (seleccionado == false) {
            //Si, al menos, una vez el heroe ha sido asignado lo elimino
            if (heroeAsignado != null) {
                //Borro la selección de la lista
                GestorPersonajes.instance.eliminarSeleccion(this.heroeAsignado);
            }
            
        
        }
        
    }
}
