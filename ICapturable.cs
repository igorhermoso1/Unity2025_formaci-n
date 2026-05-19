using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Un Interface nos permite crear una plantilla de método o utilidades...
//que deberán ser redefinidas desde los scripts que lo implementen
public interface ICapturable 
{
    //Creamos un método que define cómo de complicado es capturar a este mandangón
    public float ratioCaptura(float ratio);

    public void decirWenceslao();
}
