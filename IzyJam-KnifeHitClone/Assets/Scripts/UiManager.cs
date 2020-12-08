using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _inGame;
    [SerializeField] private CanvasGroup _results;

    [SerializeField] private TextMeshProUGUI _resultsTitle;
    [SerializeField] private TextMeshProUGUI _resultsBtn;

    [SerializeField] private Slider _knifeCounter;
    [SerializeField] private TextMeshProUGUI _stageCounter;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _coins;

    public void _Init_(float p_numberOfKnifes)
    {
        _knifeCounter.maxValue = p_numberOfKnifes;
        _knifeCounter.value = p_numberOfKnifes;      
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

    public void ShowResults() => StartCoroutine(ShowResults(2));

    public void Continue()
    {
        _knifeCounter.value++;

        ShowCanvasGroup(_inGame);
        HideCanvasGroup(_results);
    }

    private void OnThrowKnife() => _knifeCounter.value --;

    private void ShowCanvasGroup(CanvasGroup p_canvasGroup)
    {
        p_canvasGroup.alpha = 1.0f;
        p_canvasGroup.blocksRaycasts = true;
        p_canvasGroup.interactable = true;
    }
    
    private void HideCanvasGroup(CanvasGroup p_canvasGroup)
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