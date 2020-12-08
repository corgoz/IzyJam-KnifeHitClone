using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private GameObject _explosionFX;


    private List<Rigidbody> _knifes;
    private Transform _transform;
    private void Start()
    {
        _transform = transform;
        _knifes = new List<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.forward * _rotationSpeed * _curve.Evaluate(Time.time) *  Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
            _knifes.Add(other.GetComponent<Rigidbody>());
    }

    public void _Init_(float p_rotationSpeed, AnimationCurve p_curve)
    {
        _rotationSpeed = p_rotationSpeed;
        _curve = p_curve;
    }

    public void DestroyTarget()
    {
        Instantiate(_explosionFX, _transform.position, _explosionFX.transform.rotation);

        foreach(Rigidbody rb in _knifes)
        {
            Transform knifeTransform = rb.transform;
            knifeTransform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;

            rb.AddForce(-knifeTransform.up * 2.5f, ForceMode.Impulse);
            rb.AddTorque(knifeTransform.forward * Random.Range(-0.5f, 0.5f), ForceMode.Impulse);
            Destroy(rb.gameObject, 2.0f);
        }
        Destroy(gameObject);
    }
}
