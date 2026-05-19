using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegado2 : MonoBehaviour
{

    void Start()
    {
        GestorDelegado.instancia.eventoSimple += mandangaSuscritor;
    }

    public void mandangaSuscritor()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                new Vector3(this.transform.position.x,
                                                            this.transform.position.y+0.5f,
                                                            this.transform.position.z),
                                                5*Time.deltaTime);
    }
}
