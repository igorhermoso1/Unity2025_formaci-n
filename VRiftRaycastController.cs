using UnityEngine;
using UnityEngine.Windows;
using BNG;


//Este Script hay que arrastrarlo a la mano y ésta debe tener el componente Line Renderer!!!
public class VRiftRaycastController : MonoBehaviour
{
    public Transform objectToMove; // Asigna el objeto que quieres mover hacia el objeto detectado
    public float maxDistance = 10f; // La distancia máxima del raycast
    private LineRenderer lineRenderer;
    public LayerMask layerEstrellas;
    private RaycastHit hit;
   
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
   
    }
    public void tratamientoLineRenderer()
    {
        // Renderiza la línea
        lineRenderer.SetPosition(0, transform.position);
        Vector3 endPoint = transform.position + transform.forward * maxDistance;
        lineRenderer.SetPosition(1, endPoint);
    }

    void Update()
    {
        tratamientoLineRenderer();

        Debug.DrawRay(transform.position, transform.forward*10000, Color.yellow);
        // Lanza el raycast al presionar el botón de disparo del controlador de VRift
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerEstrellas))
        {
            //if (InputBridge.Instance.LeftTrigger > 0)
          //  estrellaApuntada = hit.transform.GetComponent<ObjetoEstrella>();
           
            if (InputBridge.Instance.LeftTriggerDown )
            {
               

                    // Aplica un outline al objeto señalado
                    OutlineObject(hit.collider.gameObject);
                
            }
        }
       
    }

    // Función para aplicar un outline al objeto señalado
    void OutlineObject(GameObject obj)
    {
        // Implementa el efecto de outline en el objeto señalado
        // Puedes usar el componente Outline Effect de VRift o un asset similar
    }
}
