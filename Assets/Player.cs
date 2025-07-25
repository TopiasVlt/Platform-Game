//using System.Diagnostics;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public Vector3 groundCheckSize = new Vector3(0.5f, 0.05f, 0);
    public LayerMask groundLayer;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
  
    private int count;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Count" + count.ToString();
        if (count >= 8)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
        Jump();
        Debug.Log("toka");
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(horizontalInput * moveSpeed, rb.linearVelocity.y, 0);

        // Vector2 movement = new(horizontalInput * moveSpeed, rb.angularVelocity.y);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("eka");
        if (other.gameObject.CompareTag("PickUp"))
        {
           
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    void Jump()          
    {
        if (isGrounded())
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0);
                //isGrounded() = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheck.position, groundCheckSize);
    }

    bool isGrounded()
    {
        //Debug.DrawRay(transform.position, Vector3.down, Color.magenta);

        LayerMask layerMask = LayerMask.GetMask("Ground");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, layerMask))
        {
            
            return true;
        }
        else
        {
            
            return false;
        }
    }
}

