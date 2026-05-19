using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gestorrecetas : MonoBehaviour
{
    public List<Receta> recetario=new List<Receta>();
        // Start is called before the first frame update
    void Start()
    {
        //recetario.Sort(); 
        for(int i = 0; i < recetario.Count-1; i++)
        {
            for(int j = 0; j < recetario.Count-i-1; j++)
            {
                if (recetario[j].GetDuracion() >= recetario[j + 1].GetDuracion())
                {
                    Receta rec = recetario[j];
                    recetario[j] = recetario[j + 1];
                    recetario[j] = rec;
                }
                
            }
        }
    }

   
    void Update()
    {
        
    }
}
