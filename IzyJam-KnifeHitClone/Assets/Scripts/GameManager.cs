using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public bool IsPlaying { get; private set; }
    private int _score;
    private int _currentStage = 1;

    [SerializeField] private Stage[] _stages;
    [SerializeField] private GameObject[] _targetPrefab;
    [SerializeField] private Transform _targetSpawnTransform;

    [SerializeField] private UiManager _uiManager;
    [SerializeField] private Player _player;

    private Target _currentTarget;
    [SerializeField] private MemorySystemData _data;

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _data = MemorySystem.LoadFile();
        if (_data == null)
            _data = new MemorySystemData();

        _uiManager.UpdateCoins(_data.coins);
    }

    public void SpawnLevel()
    {
        Stage stage = _stages[0];

        _currentTarget = Instantiate(_targetPrefab[0], _targetSpawnTransform.position, _targetSpawnTransform.rotation).GetComponent<Target>();

        _currentTarget._Init_(stage.rotationSpeed, stage.curve);
        _player._Init_(stage.numberOfKnifes);
        _uiManager._Init_(stage.numberOfKnifes);

        IsPlaying = true;
    }

    public void UpdateScore()
    {
        _score++;
        _uiManager.UpdateScore(_score);
    }

    public void GetCoin()
    {
        _data.coins++;
        _uiManager.UpdateCoins(_data.coins);
    }

    public void EndGame(bool p_won)
    {
        IsPlaying = false;

        if (p_won)
        {
            _currentStage++;
            _currentTarget.DestroyTarget();
            _uiManager.UpdateStage(_currentStage);
            SpawnLevel();
        }
        else
        {
            Debug.Log("Perdeu");

            _uiManager.ShowResults();

            if (_currentStage > _data.bestLevel)
                _data.bestLevel = _currentStage;

            if (_score > _data.bestScore)
                _data.bestScore = _score;

            MemorySystem.SaveFile(_data);
        }

    }

    public void Continue()
    {
        IsPlaying = true;

        _player.Continue();
        _uiManager.Continue();
    }

    public void ReloadGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
