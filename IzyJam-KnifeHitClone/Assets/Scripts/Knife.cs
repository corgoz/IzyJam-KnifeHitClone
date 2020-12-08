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
        //Se o rigidbody for kinematic, então a faca já colidiu com o alvo e portanto este if não deve ser executado.
        if (collision.transform.CompareTag("Knife") & !_rigidBody.isKinematic)
        {
            _rigidBody.useGravity = true;
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.AddForce(collision.contacts[0].normal * 10, ForceMode.Impulse);
            HitKnife();
            Destroy(gameObject, 3.0f);
        }
    }

    public void Launch()
    {
        _rigidBody.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }
}
