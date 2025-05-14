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
    [SerializeField]
    Rigidbody playerRB;

    void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("usable") || hit.CompareTag("Player"))
            {
                Rigidbody rbHit = hit.GetComponent<Rigidbody>();
                if (rbHit != rb)
                {
                    rbHit.AddExplosionForce(explosionPower, transform.position, explosionRadius);
                }
                else if (rb == playerRB)
                {
                    rbHit.AddExplosionForce(explosionPower *4, transform.position, explosionRadius);
                }
            }
        }
        Destroy(gameObject);
    }
}
