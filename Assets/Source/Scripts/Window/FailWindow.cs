using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailWindow : MonoBehaviour, IEntryPointSetupPlayer
{
    [SerializeField] private GameObject _failWindow;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(Restart);
    }

    private void OpenFailWindow()
    {
        _failWindow.SetActive(true);
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void SetupPlayer(PlayerMovement playerTransform)
    {
        playerTransform.GetComponent<PlayerHealth>().OnDie += OpenFailWindow;
    }
}
