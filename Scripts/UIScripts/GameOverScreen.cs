using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gameOverGroup;
    [SerializeField] private Button _restartButtn;
    [SerializeField] private Button _exitButtn;
    [SerializeField] private PlayerLife _player;

    private void OnEnable()
    {
        _player.Died += OnDied;

        _restartButtn.onClick.AddListener(OnRestarrButtonClic);
        _exitButtn.onClick.AddListener(OnExitButtonClic);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;

        _restartButtn.onClick.RemoveListener(OnRestarrButtonClic);
        _exitButtn.onClick.RemoveListener(OnExitButtonClic);
    }

    private void Start()
    {
        _gameOverGroup.alpha = 0;
    }

    private void OnDied()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestarrButtonClic()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClic()
    {
        Application.Quit();
    }
}
