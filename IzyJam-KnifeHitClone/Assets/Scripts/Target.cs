using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private AnimationCurve _curve;

    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _transform.Rotate(Vector3.forward * _rotationSpeed * _curve.Evaluate(Time.time) *  Time.fixedDeltaTime);
    }
}
