using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private AnimationCurve _curve;

    private Transform _transform;
    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.forward * _rotationSpeed * _curve.Evaluate(Time.time) *  Time.fixedDeltaTime);
    }

    public void _Init_(float p_rotationSpeed, AnimationCurve p_curve)
    {
        _rotationSpeed = p_rotationSpeed;
        _curve = p_curve;
    }

    public void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
