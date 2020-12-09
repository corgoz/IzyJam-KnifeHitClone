using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public bool IsPlaying { get; private set; }

    public int BestScore => _data.bestScore;
    public int BestStage => _data.bestStage;
    public int CurrentSkin { 
        get { return _data.currentSkin; }
        set { 
            _data.currentSkin = value;
            MemorySystem.SaveFile(_data);
        }
    }
    public int Coins => _data.coins;
    public bool HasSkinsToUnlock => _unlockedSkins.Count > 0;

    private int _score;
    private int _currentStage = 1;
    public readonly int SkinCost = 50;

    [Header("Stage Settings")]
    [SerializeField] private Stage[] _stages;
    [SerializeField] private GameObject[] _targetPrefab;
    [SerializeField] private Transform _targetSpawnTransform;
    [SerializeField] private KnifeSkin[] _skins;

    [Header("External Components")]
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private Player _player;
    [SerializeField] private Store _store;


    private Target _currentTarget;
    private MemorySystemData _data;
    private List<KnifeSkin> _unlockedSkins;

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        _data = MemorySystem.LoadFile();
        if (_data == null)
            _data = new MemorySystemData(_skins.Length);

        _uiManager.UpdateCoins(_data.coins);

        _unlockedSkins = new List<KnifeSkin>();
        for (int i = 0; i < _skins.Length; i++)
        {
            _skins[i].index = i;
            if (!_data.skins[i])
                _unlockedSkins.Add(_skins[i]);
        }

        _store._Init_(_data.skins, _skins);

        Advertisement.Initialize("3932635", true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MemorySystem.DeleteFile();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _data.coins += 50;
            _uiManager.UpdateCoins(_data.coins);
        }
    }

    public void ToggleHapticFeedBack()
    {
        _data.isHapticOn = !_data.isHapticOn;
        MemorySystem.SaveFile(_data);
    }

    public void SpawnLevel()
    {
        Stage stage = _stages[Random.Range(0, _stages.Length)];

        _currentTarget = Instantiate(_targetPrefab[0], _targetSpawnTransform.position, _targetSpawnTransform.rotation).GetComponent<Target>();

        _currentTarget._Init_(stage.rotationSpeed, stage.curve);
        _player._Init_(stage.numberOfKnifes, _skins[_data.currentSkin].gfx);
        _uiManager._Init_(stage.numberOfKnifes);

        IsPlaying = true;
    }

    public void IncrementScore()
    {
        _score++;
        _uiManager.UpdateScore(_score);
    }

    public void GetCoin(int p_amount)
    {
        _data.coins += p_amount;
        _uiManager.UpdateCoins(_data.coins);
        _store.EnableUlockSkinBtn();
    }

    public void EndStage(bool p_won)
    {
        IsPlaying = false;

        if (p_won)
        {
            _currentStage++;
            _currentTarget.DestroyTarget();
            _uiManager.UpdateStage(_currentStage);
            Invoke("SpawnLevel", 3.0f);

            if (_data.isHapticOn)
                Handheld.Vibrate();
        }
        else
            _uiManager.ShowResults(_score, _currentStage);
    }

    public void Continue()
    {
        IsPlaying = true;

        _player.Continue();
        _uiManager.Continue();
    }

    public void ReloadGame()
    {
        if (_currentStage > _data.bestStage)
                _data.bestStage = _currentStage;

        if (_score > _data.bestScore)
            _data.bestScore = _score;

        MemorySystem.SaveFile(_data);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public KnifeSkin GetRandomUnlockedSkin()
    {
        if (_unlockedSkins.Count <= 0) return null;

        KnifeSkin skin = _unlockedSkins[Random.Range(0, _unlockedSkins.Count)];
        _unlockedSkins.Remove(skin);

        _data.skins[skin.index] = true;
        _data.coins -= SkinCost;
        _uiManager.UpdateCoins(_data.coins);

        MemorySystem.SaveFile(_data);

        return skin;
    }
}