using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [System.NonSerialized] public bool active = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Normalises input if necessary and applys to transform
    public void Move(Vector3 input)
    {
        if (active)
        {
            if (input.magnitude > 1.0f)
            {
                input.Normalize();
            }

            Vector2 movement = input * movementSpeed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + movement);
        }
    }
}
