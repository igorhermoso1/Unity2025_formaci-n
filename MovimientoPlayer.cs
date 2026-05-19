using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    // Referencias a componentes importantes
    public CharacterController controller;  // Controlador del personaje para gestionar el movimiento físico
    public Animator animator;               // Controlador de animaciones
    public Transform cameraTransform;       // Transform de la cámara para determinar la dirección del movimiento

    // Configuraciones de movimiento
    [Header("Movement Settings")]
    public float walkSpeed = 2.0f;          // Velocidad de caminar
    public float runSpeed = 6.0f;           // Velocidad de correr
    public float crouchSpeed = 1.0f;        // Velocidad al agacharse
    public float turnSmoothTime = 0.1f;     // Tiempo de suavizado para la rotación
    private float turnSmoothVelocity;       // Velocidad de suavizado para el giro
    private float speed;                    // Variable para almacenar la velocidad actual
    private float turn;                     // Variable para controlar el giro (izquierda/derecha)

    // Configuraciones del salto
    [Header("Jump Settings")]
    public float jumpHeight = 1.5f;         // Altura que alcanzará el salto
    public float gravity = -9.81f;          // Aceleración de la gravedad
    private Vector3 velocity;               // Almacena la velocidad vertical para aplicar la gravedad
    private bool isGrounded;                // Indicador para saber si el personaje está en el suelo

    // Configuraciones del agacharse
    [Header("Crouch Settings")]
    public bool isCrouching = false;        // Indica si el personaje está agachado
    public float crouchHeight = 1.0f;       // Altura cuando está agachado
    private float originalHeight;           // Altura original del CharacterController para restaurar al levantarse

    // Detección de suelo
    [Header("Ground Detection")]
    public Transform groundCheck;           // Objeto que detecta el suelo bajo el personaje
    public float groundDistance = 0.4f;     // Radio para la detección de suelo
    public LayerMask groundMask;            // Máscara para definir qué capas se consideran suelo

    // Inicialización
    private void Start()
    {
        // Obtener el componente CharacterController en el objeto
        controller = GetComponent<CharacterController>();

        // Obtener el componente Animator en el objeto
       // animator = GetComponent<Animator>();

        // Guardar la altura original del CharacterController (usada para restaurarla al levantarse)
        originalHeight = controller.height;
    }

    // Método que se ejecuta cada frame
    private void Update()
    {
        // Comprobar si el personaje está tocando el suelo usando un "GroundCheck"
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Si el personaje está en el suelo y tiene velocidad negativa (cayendo), reseteamos la velocidad vertical
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Asegurarse de que el personaje esté en contacto con el suelo
        }

        // Obtener los inputs de movimiento del teclado
        float horizontal = Input.GetAxisRaw("Horizontal");  // Input de izquierda/derecha (A/D o flechas)
        float vertical = Input.GetAxisRaw("Vertical");      // Input de adelante/atrás (W/S o flechas)

        // Normalizar el vector de dirección para evitar valores mayores a 1 en diagonal
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Almacena el valor del giro basado en el input horizontal (izquierda/derecha)
        turn = horizontal;

        // Solo mover si hay input de movimiento (mayor a 0.1 en alguna dirección)
        if (direction.magnitude >= 0.1f)
        {
            // Determinar el ángulo de giro basado en la dirección y la orientación de la cámara
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            // Suavizar el giro del personaje con el ángulo objetivo
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            // Aplicar la rotación suave al personaje
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Mover el personaje en la dirección determinada, en relación con la cámara
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Si se mantiene presionado Shift, cambiamos la velocidad a correr
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;  // Correr
            }
            else
            {
                speed = walkSpeed; // Caminar
            }

            // Mover el personaje usando el CharacterController
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

            // Normaliza la velocidad y se asegura de que los valores entre Walk y Run sean claros
            float normalizedSpeed = Mathf.Clamp(speed / runSpeed, 0f, 1f);
           // float normalizedSpeed = Mathf.InverseLerp(0, runSpeed, speed);
            animator.SetFloat("Speed", normalizedSpeed);  // Controla andar/correr
            animator.SetFloat("Turn", turn);              // Controla el giro (izquierda/derecha)
        }
        else
        {
            // Si no hay input, detenemos el movimiento
            animator.SetFloat("Speed", 0f);
            animator.SetFloat("Turn", 0f);
        }

        // Controlar el salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Calcular la velocidad de salto usando la fórmula de física
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            // Activar la animación de salto
            animator.SetTrigger("Jump");
        }

        // Aplicar la gravedad progresivamente (física)
        velocity.y += gravity * Time.deltaTime;

        // Mover al personaje hacia abajo aplicando la gravedad
        controller.Move(velocity * Time.deltaTime);

        // Controlar el agacharse
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ToggleCrouch();  // Alternar entre agacharse y levantarse
        }
    }

    // Método para alternar entre agacharse y levantarse
    private void ToggleCrouch()
    {
        isCrouching = !isCrouching;  // Cambiar el estado de agachado

        // Si está agachado, ajustar la altura del CharacterController
        if (isCrouching)
        {
            controller.height = crouchHeight;  // Cambiar a la altura de agachado
            speed = crouchSpeed;               // Reducir la velocidad al agacharse
        }
        else
        {
            controller.height = originalHeight; // Restaurar la altura original
        }

        // Ajustar la velocidad en función de si está agachado o no
        animator.SetBool("isCrouching", isCrouching);
    }
   }

