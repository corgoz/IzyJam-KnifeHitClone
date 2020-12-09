using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action ThrowKnife = delegate { };

    [SerializeField] private Knife _knifePrefab;

    private Knife _myKnife;
    private GameObject _knifeSkin;
    private int _numberOfKnifes;
    private bool _isThrowingKnife;

    private GameManager _gameManager;
    
    private void Start() => _gameManager = GameManager.Singleton;
    
    private void Update()
    {
        if (!_gameManager.IsPlaying) return;

        if (Input.GetMouseButtonDown(0) & !_isThrowingKnife) 
        {
            _myKnife.Throw();
            ThrowKnife();
            _isThrowingKnife = true;
        }
    }

    public void _Init_(int p_numberOfKnifes, GameObject p_knifeSkin)
    {
        _numberOfKnifes = p_numberOfKnifes;
        _knifeSkin = p_knifeSkin;
        SpawnKnifePrefab();
    } 
    
    public void Continue() => SpawnKnifePrefab();
    
    private void SpawnKnifePrefab()
    {
        _isThrowingKnife = false;
        _myKnife = Instantiate(_knifePrefab, transform).GetComponent<Knife>();
        _myKnife.HitTarget += OnHitTarget;
        _myKnife.HitKnife += OnHitKnife;

        Instantiate(_knifeSkin, _myKnife.GfxTransfom);
    }

    private void OnHitTarget()
    {
        _myKnife.HitTarget -= OnHitTarget;
        _myKnife.HitKnife -= OnHitKnife;
        _numberOfKnifes--;

        _gameManager.IncrementScore();

        if (_numberOfKnifes > 0)
            SpawnKnifePrefab();
        else
            _gameManager.EndStage(true);
    }

    private void OnHitKnife()
    {
        _myKnife = null;
        _gameManager.EndStage(false);
    }
}