using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PanelSeleccionFinalUI : MonoBehaviour
{
    public Image imgAvatar;
    public TMP_Text txtNombre;
    public TMP_Text txtDescripcion;

    public PanelSeleccionFinalUI GetPanelSeleccionFinalUI()
    {
        return this.GetComponent<PanelSeleccionFinalUI>();  
    }

    public void cargarDetallesHeroe(Clase_Heroe heroe)
    {
        imgAvatar.sprite = heroe.GetFoto();
        txtNombre.text = heroe.GetNombre();
        txtDescripcion.text = heroe.GetDescripcion();
    }
}
