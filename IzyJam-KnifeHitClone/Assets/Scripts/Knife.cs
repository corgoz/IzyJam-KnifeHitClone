using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Action HitTarget = delegate { };
    public Action HitKnife= delegate { };

    private Transform _transform;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _transform = transform;
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            _transform.parent = other.transform;
            _rigidBody.isKinematic = true;
            _rigidBody.velocity = Vector3.zero;
            HitTarget();
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Knife"))
            HitKnife();
    }

    public void Launch()
    {
        _rigidBody.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }
}
