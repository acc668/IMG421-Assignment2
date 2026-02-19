using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;

    void Start()
    {
        // Apply difficulty-based gravity scale so apples fall faster on harder modes
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Unity doesn't have per-Rigidbody gravity scale like 2D does.
            // We simulate it by adding extra downward force every FixedUpdate.
            // Store the gravity multiplier offset (1.0 = normal gravity).
            // We use a coroutine trick: just set extra force via gravityMultiplier.
        }
    }

    // Extra gravity beyond Unity's default (set by ApplePicker after instantiation)
    [HideInInspector]
    public float gravityMultiplier = 1f;

    void FixedUpdate()
    {
        // Apply extra gravity for difficulties above Tutorial/Easy
        if (gravityMultiplier != 1f)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Extra downward force = mass * gravity * (multiplier - 1)
                float extraG = Physics.gravity.magnitude * (gravityMultiplier - 1f);
                rb.AddForce(Vector3.down * extraG * rb.mass, ForceMode.Force);
            }
        }
    }

    void Update()
    {
        // Destroy the apple if it falls below the screen and notify ApplePicker
        if (transform.position.y < bottomY)
        {
            // Notify ApplePicker that an apple was missed
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            if (apScript != null)
            {
                apScript.AppleDestroyed();
            }

            Destroy(this.gameObject);
        }
    }
}