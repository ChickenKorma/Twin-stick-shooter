using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [System.NonSerialized] public bool active = true;

    [SerializeField] private float movementSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Normalises input if necessary and applies to the transform
    public void Move(Vector3 input)
    {
        if (active)
        {
            if (input.magnitude > 1.0f)
            {
                input.Normalize();
            }

            Vector2 movementInput = input * movementSpeed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + movementInput);
        }
    }
}
