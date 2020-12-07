using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Knife _knifePrefab;

    private Knife _myKnife;
    [SerializeField] private int _numberOfKnifes;

    private GameManager _gameManager;

    private void Awake() => SpawnKnifePrefab();
    
    private void Start() => _gameManager = GameManager.Singleton;
    
    private void Update()
    {
        if (!_gameManager.IsPlaying) return;

        if (Input.GetMouseButtonDown(0))
            _myKnife.Launch();
    }

    public void _Init_(int p_numberOfKnifes) => _numberOfKnifes = p_numberOfKnifes;
    private void SpawnKnifePrefab()
    {
        _myKnife = Instantiate(_knifePrefab, transform).GetComponent<Knife>();
        _myKnife.HitTarget += OnHitTarget;
        _myKnife.HitKnife += OnHitKnife;
    }

    private void OnHitTarget()
    {
        _myKnife.HitTarget -= OnHitTarget;
        _myKnife.HitKnife -= OnHitKnife;
        _numberOfKnifes--;
        if (_numberOfKnifes > 0)
            SpawnKnifePrefab();
        else
            _gameManager.EndGame(true);
    }

    private void OnHitKnife()
    {
        _myKnife = null;
        _gameManager.EndGame(false);
    }
}