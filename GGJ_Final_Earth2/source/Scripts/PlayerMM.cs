using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMM : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            // then force is applied to Rigidbody2D component to make Player jump
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
