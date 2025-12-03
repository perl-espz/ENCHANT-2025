using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento clásico
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        rb.velocity = moveInput.normalized * moveSpeed;

        // Animaciones
        bool isWalking = moveInput.sqrMagnitude > 0.01f;
        animator.SetBool("isWalking", isWalking);
        animator.SetFloat("horizontal", moveInput.x);
        animator.SetFloat("vertical", moveInput.y);
    }
}
