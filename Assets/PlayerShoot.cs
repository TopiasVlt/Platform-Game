using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public float range = 100f;
    public float damage = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}