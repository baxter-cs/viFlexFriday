using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public Transform relativeTransform;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        if(Input.GetKey(KeyCode.W)) moveDirection += relativeTransform.forward;
        if(Input.GetKey(KeyCode.S)) moveDirection += -relativeTransform.forward;
        if(Input.GetKey(KeyCode.A)) moveDirection += -relativeTransform.right;
        if(Input.GetKey(KeyCode.D)) moveDirection += relativeTransform.right;
        moveDirection.y = 0f;
        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (moveDirection * moveSpeed);

        if(moveDirection != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider)
    {
        ItemPickup itemPickup = collider.GetComponent <ItemPickup>();
        if (itemPickup)
        {
            itemPickup.Pickup(this);
        }
    }
}
