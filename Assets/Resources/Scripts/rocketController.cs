using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float explosionRadius;
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float explosionPower;

    void Start()
    {

    }

    void Update()
    {
        rb.AddForce(transform.forward * moveSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("usable"))
            {
                Rigidbody rbHit = hit.GetComponent<Rigidbody>();
                if (rbHit != rb)
                {
                    rbHit.AddExplosionForce(explosionPower, transform.position, explosionRadius);
                }
            }
        }
        Destroy(gameObject);
    }
}
