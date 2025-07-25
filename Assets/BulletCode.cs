using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce((target - transform.position) * moveSpeed, ForceMode.Impulse);
    }

}
  
        
    

