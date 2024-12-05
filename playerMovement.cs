using UnityEngine;



public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float deathHeight = -1f;
    [SerializeField] private float deathAnimation = 0.5f;
    [SerializeField] private Transform cameraTarget;
    private Rigidbody2D body;
    public GameObject gameEndCanvas;
    private bool grounded;
    float horizontalInput;

    private void Awake()
    {

        //grab reference for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();


    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        CheckFallDeath();



        //horizontally

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //flip player
        if (horizontalInput > 0.01f && transform.localScale.x < 0)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f && transform.localScale.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);


        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
        }




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.collider.CompareTag("ground"))
        {
            grounded = true;
        }


    }
    private void HandleDeath()
    {


        Die();
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is no longer grounded
        if (collision.collider.CompareTag("ground"))
        {
            grounded = false;
        }
    }
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        grounded = false;
    }





    private void CheckFallDeath()
    {


        if (transform.position.y < deathHeight)
        {
            Invoke("HandleDeath", deathAnimation);
            Die();
        }
    }

    private void Die()
    {


        gameObject.SetActive(false);
        gameEndCanvas.SetActive(true);

    }



}