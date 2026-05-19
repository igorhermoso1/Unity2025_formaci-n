using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NaturalezBoton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image btnEste;
    public TMP_Text textEste;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Color original = btnEste.color;
        btnEste.color= textEste.color;
        textEste.color= original;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color original = btnEste.color;
        btnEste.color = textEste.color;
        textEste.color = original;
    }
}
