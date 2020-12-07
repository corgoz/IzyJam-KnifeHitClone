using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _inGame;
    [SerializeField] private CanvasGroup _results;

    [SerializeField] private TextMeshProUGUI _resultsTitle;
    [SerializeField] private TextMeshProUGUI _resultsBtn;

    public void StartGame()
    {
        ShowCanvasGroup(_inGame);
        HideCanvasGroup(_mainMenu);
    }

    public void ShowResults(bool p_won)
    {
       /* if (p_won)
        {
            _resultsTitle.text = "Level Complete";
            _resultsBtn.text = "Next Level";
        }
        else
        {
            _resultsTitle.text = "Level Fail";
            _resultsBtn.text = "Retry Level";
        }*/

        ShowCanvasGroup(_results);
        HideCanvasGroup(_inGame);
    }

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
}