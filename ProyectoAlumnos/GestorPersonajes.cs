using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorPersonajes : MonoBehaviour
{
    //Action para lanzar una función suscrita a el cambio de panel
    public Action OnPanelSeleccionFinal;

    //Puerta de acceso al gestor(singleton)
    public static GestorPersonajes instance;
   //Lista para almacenar los cachutos de memoria
   public List<Heroe> scriptablesHeroes = new List<Heroe>(); 
    //Lista de objeto de la clase Clase_Heroe creado desde cada scriptable de Heroe
    public List<Clase_Heroe> listaHeroes = new List<Clase_Heroe>();
    //Lista para almacenar los heroes seleccionados
    public List<Clase_Heroe> heroeSeleccionados = new List<Clase_Heroe>();
    //Lista para almacenar dinámicamente los elementos seleccionados
    public List<ControladorPersonajeUI> listaPersonajesUI = new List<ControladorPersonajeUI>();
    
    
    //Elemento, prefab, de la imagen con el texto. Crearemos tantos como heroes tengamos
    public GameObject prefabHeroeUI;
    //Elemento, prefab, de la imagen con el texto del nombre y la descripción
    public GameObject prefabSeleccionFinalUI;

    //Variable para almacenar el panel en el que instanciaremos los recursos de UI heroes
    public Transform panelPersonajes;
    //Variable para almacenar el panel(scrollView) en el que instanciaremos...
    //...los recursos de UI selección final
    public Transform panelMuestraSeleccion;
    //Panel de la selección final
    public GameObject panelSeleccion;

    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        //Ordenamos al comienzo la lista de los scriptables
        scriptablesHeroes.Sort();
        //Al comienzo cargamos y creamos la lista de heroes
        cargaListaHeroes();
    }

    //Función para cargar y crear heroes en base al scriptable
    public void cargaListaHeroes()
    {
        for (int i = 0; i < scriptablesHeroes.Count; i++)
        {
            //Por cada scriptable de tipo heroe creo un nuevo heroe utilizando el constructor...
            //...que recibe un scriptable y crea uno nuevo teniendo en cuenta sus atributos de clase
            Clase_Heroe heroe = new Clase_Heroe(scriptablesHeroes[i]);
            listaHeroes.Add(heroe);

        }
        //Llamo, ahora, a cargar los elementos de UI
        cargaHeroesUI();
    }

    public void cargaHeroesUI()
    {
        //Recorremos la lista de heroes para cargar en pantalla los objetos de forma dinámica
        foreach (Clase_Heroe heroe in listaHeroes)
        {
            //Por cada heroe en la lista instaciaré un objeto en pantalla
            //Utilizaremos Instantiate con la sobrecarga de el qué y dónde(el panel)
            GameObject auxHeroe = Instantiate(prefabHeroeUI, panelPersonajes);
            //Cambiamos el nombre del objeto instanciado
            auxHeroe.name = heroe.GetNombre();
            //Llamo a la función de mostrar la información de cada ControladorPersonjeUI
            ControladorPersonajeUI controladoHeroeAux = auxHeroe.GetComponent<ControladorPersonajeUI>();
            //Envio el heroe que toca de la lista y lo mostramos(también lo creamos en el otro script)
            controladoHeroeAux.recibirHeroe(heroe);
            //Guardo en la lista el elemento creado
            listaPersonajesUI.Add(controladoHeroeAux);
        }
    }
    //Función para guardar el heroe recibido en la lista de selección final
    public void guardarSeleccion(Clase_Heroe heroeAGuardar)
    {
        //Mientras que no tengamos 3 heroes seleccionados podemos añadir...
        if(heroeSeleccionados.Count < 3)
        {
            //El heroe recibido lo asigno a la lista
            heroeSeleccionados.Add(heroeAGuardar);
        }
        //...Si es 3 o más mostraremos el resumen.
        if (heroeSeleccionados.Count == 3)
        {
            //Invokamos el action
            OnPanelSeleccionFinal?.Invoke();
            //Ahora, de la lista de seleccionados mostramos uno en pantalla por cada elemento seleccionado
            leerHeroesSeleccionFinal();
        }
    }
    //Función para eliminar la selección recibiendo el Clase_Heroe a eliminar
    public void eliminarSeleccion(Clase_Heroe heroeAEliminar)
    {
        //Si la lista está vacía NO elimino pero si Sí hay algo....
        if (heroeSeleccionados.Count > 0) {
            //Eliminamos el heroe
            heroeSeleccionados.Remove(heroeAEliminar);
        }
    }
    //Mostrar en pantalla la selección final
    public void leerHeroesSeleccionFinal()
    {
        for (int i = 0; i < heroeSeleccionados.Count; i++) {
            //Instancion una copia del objeto panelSeleccionFinalUI
            GameObject aux = Instantiate(prefabSeleccionFinalUI, panelMuestraSeleccion);
            //De cada uno de ellos almaceno su script para editar la imagen y los textos
            PanelSeleccionFinalUI auxPanelSeleccionUI = aux.GetComponent<PanelSeleccionFinalUI>();
            //A cada uno de ellos le paso un heroe de la selección para que lo muestre
            auxPanelSeleccionUI.cargarDetallesHeroe(heroeSeleccionados[i]);
        }
    }
}
