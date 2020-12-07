using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public bool IsPlaying { get; private set; }

    [SerializeField] private UiManager _uiManager;

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }


    public void StartGame()
    {
        IsPlaying = true;
    }

    public void EndGame(bool p_won)
    {
        IsPlaying = false;

        if (p_won)
            Debug.Log("Venceu");
        else
            Debug.Log("Perdeu");

        _uiManager.ShowResults(p_won);
    }

    public void ReloadGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
