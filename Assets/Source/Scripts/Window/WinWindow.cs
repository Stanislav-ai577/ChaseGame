using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinWindow : MonoBehaviour, IEntryPointSetupTimer
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(Restart);
    }

    private void OpenWindow()
    { 
        _winWindow.SetActive(true);
    }
    
    private void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    public void SetupTimer(Timer timer)
    {
        timer.OnTimerEnd += OpenWindow;
    }
}
