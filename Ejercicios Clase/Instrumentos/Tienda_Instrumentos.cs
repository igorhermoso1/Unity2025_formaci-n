using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda_Instrumentos : MonoBehaviour
{

    public Guitarra guitarra1;
    public Guitarra guitarra2;
    public Xilofano xilo;
    public string letraCancion;
    // Start is called before the first frame update
    void Start()
    {
        guitarra1 = new Guitarra("Stratocaster", "Cuerda", "Madera", 120f,
                                    "Eléctrica", "Fender");
        guitarra2 = new Guitarra("Ellamaja", "Cuerda", "Resina", 160f,
                                  "Eléctrica", "Ellamaja");
        xilo = new Xilofano();

        //print(Instrumento.totalInstrumento);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
        
            guitarra1.PaquitoLusia(letraCancion);
        }
    }
}
