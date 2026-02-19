using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ApplePicker.cs will set isSecondTree = true on the Hell-mode second tree.
public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;

    // These are overridden at runtime by ApplePicker using GameManager values.
    public float speed = 6f;
    public float leftAndRightEdge = 20f;
    public float changeDirChance = 0.01f;
    public float appleDropDelay = 1.5f;

    // Set to true by ApplePicker for Hell mode's second tree (moves opposite direction)
    [HideInInspector]
    public bool isSecondTree = false;

    void Start()
    {
        // Apply difficulty settings from GameManager
        speed            = GameManager.GetTreeSpeed();
        changeDirChance  = GameManager.GetChangeDirChance();
        appleDropDelay   = GameManager.GetAppleDropDelay();

        // Second tree moves the opposite direction to start
        if (isSecondTree) speed *= -1f;

        // Stagger second tree drop so both trees don't drop at the same moment
        float initialDelay = isSecondTree ? appleDropDelay / 2f : 2f;
        Invoke("DropApple", initialDelay);
    }

    void DropApple()
    {
        // Instantiate apple at tree position
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;

        // Apply difficulty gravity scale to the apple's Rigidbody
        Rigidbody rb = apple.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
        }

        Invoke("DropApple", appleDropDelay);
    }

    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Boundary direction flip
        if (pos.x < -leftAndRightEdge)
        {
            // Move right
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            // Move left
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        // Random direction change (time-based via FixedUpdate)
        if (Random.value < changeDirChance)
        {
            speed *= -1f;
        }
    }
}