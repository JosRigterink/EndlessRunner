using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;

    public bool alive = true;
    public float speed = 5;
    public Rigidbody rb;
    public GameObject gameOverScreen;
    public int jumpCounter;

    public float speedIncreasePerPoint = 0.1f;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        horizontalInput = Input.GetAxis("Horizontal");

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y, transform.position.z);

        if (Input.GetButton("Jump"))
        {
            Jump();
        }
    }

    public void Die()
    {
        alive = false;
        //restart game GameOverscreen active
        Invoke("GameOverScreen", 1);
    }

    public void GameOverScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        gameOverScreen.SetActive(true);
    }

    public void Jump()
    {
        //check if we grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.01f, groundMask);
        if (!isGrounded)
        {
            return;
        }

        if (alive == false)
        {
            return;
        }

        //if we are, jump
        rb.AddForce(Vector3.up * jumpForce);
        anim.SetTrigger("Jump");
        jumpCounter++;
    }
}
