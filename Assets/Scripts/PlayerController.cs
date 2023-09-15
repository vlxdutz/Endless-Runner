using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float forwardSpeed = 5f;
    public float movementSpeed = 20f;

    public float maxPositionX = 2f;
    public float minPositionX = -2f;

    private Rigidbody playerRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Detectam axa orizontala
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculam noua pozitie
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * movementSpeed * Time.deltaTime;

        // Limitam Pozitia X
        newPosition.x = Mathf.Clamp(newPosition.x, minPositionX, maxPositionX);

        playerRigidbody.MovePosition(newPosition);
    }

    void FixedUpdate() {
        playerRigidbody.velocity = Vector3.forward * forwardSpeed;
    }
}
