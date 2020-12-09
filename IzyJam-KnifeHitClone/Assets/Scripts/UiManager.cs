using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [Header("Canvas Groups")]
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _inGame;
    [SerializeField] private CanvasGroup _results;

    [Header("Main Menu")]
    [SerializeField] private TextMeshProUGUI _bestStage;
    [SerializeField] private TextMeshProUGUI _bestScore;

    [Header("Main Menu")]
    [SerializeField] private Slider _knifeCounter;
    [SerializeField] private TextMeshProUGUI _stageCounter;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _coins;

    [Header("Results")]
    [SerializeField] private TextMeshProUGUI _resultsStage;
    [SerializeField] private TextMeshProUGUI _resultsScore;

    private void Start()
    {
        _bestStage.text = string.Concat("Stage ", GameManager.Singleton.BestStage.ToString("00"));
        _bestScore.text = string.Concat("Score ", GameManager.Singleton.BestScore.ToString("00"));
    }

    public void _Init_(float p_numberOfKnifes)
    {
        _knifeCounter.maxValue = p_numberOfKnifes;
        _knifeCounter.value = p_numberOfKnifes;
        _knifeCounter.GetComponent<RectTransform>().sizeDelta = new Vector2(128, 128 * p_numberOfKnifes);
    }

    public void StartGame(Player p_player)
    {
        p_player.ThrowKnife += OnThrowKnife;

        ShowCanvasGroup(_inGame);
        HideCanvasGroup(_mainMenu);
    }

    public void UpdateScore(int p_score) => _score.text = p_score.ToString("00");
    public void UpdateStage(int p_stage) => _stageCounter.text = string.Concat("Stage ", p_stage.ToString("00"));
    public void UpdateCoins(int p_coins) => _coins.text = p_coins.ToString("000");

    public void ShowResults(int p_score, int p_stage)
    {
        _resultsStage.text = string.Concat("Stage ", p_stage.ToString("00"));
        _resultsScore.text = p_score.ToString("00");

        StartCoroutine(ShowResults(2));
    }

    public void Continue()
    {
        _knifeCounter.value++;

        ShowCanvasGroup(_inGame);
        HideCanvasGroup(_results);
    }

    private void OnThrowKnife() => _knifeCounter.value --;

    public void ShowCanvasGroup(CanvasGroup p_canvasGroup)
    {
        p_canvasGroup.alpha = 1.0f;
        p_canvasGroup.blocksRaycasts = true;
        p_canvasGroup.interactable = true;
    }
    
    public void HideCanvasGroup(CanvasGroup p_canvasGroup)
    {
        p_canvasGroup.alpha = 0.0f;
        p_canvasGroup.blocksRaycasts = false;
        p_canvasGroup.interactable = false;
    }

    private IEnumerator ShowResults(float p_delay)
    {
        yield return new WaitForSeconds(p_delay);

        ShowCanvasGroup(_results);
        HideCanvasGroup(_inGame); ;
    }
}