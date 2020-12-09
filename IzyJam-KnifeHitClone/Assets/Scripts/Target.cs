using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private Transform _coinsParent;
    [SerializeField] private Transform _knifeObstaclesParent;

    [SerializeField] private GameObject _explosionFX;

    private List<Rigidbody> _knifes;
    private List<GameObject> _coins;
    private List<GameObject> _knifeObstacles;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _knifes = new List<Rigidbody>();
        _coins = new List<GameObject>();
        _knifeObstacles = new List<GameObject>();

        for (int i = 0; i < _coinsParent.childCount; i++)
            _coins.Add(_coinsParent.GetChild(i).gameObject);

        for (int i = 0; i < _knifeObstaclesParent.childCount; i++)
            _knifeObstacles.Add(_knifeObstaclesParent.GetChild(i).gameObject);
    }

    private void FixedUpdate() => _transform.Rotate(Vector3.forward * _rotationSpeed * _curve.Evaluate(Time.time) * Time.fixedDeltaTime);
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
            _knifes.Add(other.GetComponent<Rigidbody>());
    }

    public void _Init_(float p_rotationSpeed, AnimationCurve p_curve)
    {
        _rotationSpeed = p_rotationSpeed;
        _curve = p_curve;

        int numberOfKnifesObstacle = Random.Range(0, _knifeObstacles.Count);
        while(numberOfKnifesObstacle > 0)
        {
            int index = Random.Range(0, _knifeObstacles.Count);
            _knifeObstacles[index].SetActive(true);
            _knifeObstacles.RemoveAt(index);
            numberOfKnifesObstacle--;
        }

        int numberOfCoins= Random.Range(0, _coins.Count);
        while (numberOfCoins > 0)
        {
            int index = Random.Range(0, _coins.Count);
            _coins[index].SetActive(true);
            _coins.RemoveAt(index);
            numberOfCoins--;
        }
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