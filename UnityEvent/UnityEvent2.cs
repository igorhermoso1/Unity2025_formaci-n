using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GestorUnityEvent.puerta.OnUnityEventSimple.AddListener(otroSuscriptor);
    }
    

    public void otroSuscriptor()
    {
        this.gameObject.SetActive(false);
    }
}
