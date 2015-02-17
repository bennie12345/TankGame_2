using UnityEngine;
using System.Collections;

public class Player : Tank {
    public float rotationSpeed = 4f;
    public float moveSpeed = 0.3f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMovement();
    }
    void FixedUpdate() 
    {
        UndoVelocity();
    }

    
    void DetermineWorldPos()
    {

        Vector3 mousePos = Input.mousePosition;  //(x.y.z)
        mousePos.z = camera.transform.position.y - turret.transform.position.y;
  
        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
  
        targetPos = worldPos;

    }
    

    void UndoVelocity() 
    {
        if (rb.velocity != Vector3.zero) //(0,0,0)
        {
            rb.velocity = Vector3.zero;
        }
        if (rb.angularVelocity != Vector3.zero)
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
    
    void PlayerMovement() { 
		if (Input.GetKey (KeyCode.W)) 
		{

			transform.Translate(Vector3.forward * moveSpeed);

		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate(-Vector3.forward * moveSpeed);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate(-Vector3.up * rotationSpeed);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate(Vector3.up * rotationSpeed);
		}

	}

	
}
