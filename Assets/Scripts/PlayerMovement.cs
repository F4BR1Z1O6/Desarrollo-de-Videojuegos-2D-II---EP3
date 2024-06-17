using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento del jugador
    public float speed = 5f;

    // Fuerza de salto del jugador
    public float jumpForce = 10f;

    // Verifica si el jugador está en el suelo
    private bool isGrounded;

    // Capa para detectar el suelo
    public LayerMask groundLayer;

    // Tamaño del rayo para detectar el suelo
    public float groundCheckRadius = 0.2f;

    // Referencia al Transform del objeto del suelo
    public Transform groundCheck;

    // Rigidbody2D del jugador
    private Rigidbody2D rb;

    void Start()
    {
        // Obtener el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verificar si el jugador está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Obtener la entrada del jugador para movimiento horizontal
        float horizontal = Input.GetAxis("Horizontal");

        // Crear un vector de movimiento
        Vector2 movement = new Vector2(horizontal, 0f);

        // Aplicar movimiento horizontal
        transform.Translate(movement * speed * Time.deltaTime);

        // Verificar si el jugador presiona la tecla de salto (por ejemplo, la tecla de espacio)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Aplicar fuerza de salto al Rigidbody2D del jugador
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Dibujar gizmos para visualizar el chequeo del suelo
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}



