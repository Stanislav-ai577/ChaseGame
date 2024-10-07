using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("Timer start point"), SerializeField]
    private RectTransform _canvas;
    
    [Header("Start point player"), SerializeField]
    private Transform _playerStartPoint;
    
    [Header("Start point player"), SerializeField]
    private List<Transform> _enemyStartPoint;

    [Header("Resources load")]
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private Timer _timer;
    [SerializeField] private WinWindow _winWindow;
    [SerializeField] private FailWindow _failWindow;

    private PlayerMovement _playerInstance;
    private EnemyMovement _enemyInstance;
    private Timer _timerInstance;
    
    private readonly List<IEntryPointSetupPlayer> _setupPlayer = new List<IEntryPointSetupPlayer>();
    private readonly List<IEntryPointSetupTimer> _setupTimer = new List<IEntryPointSetupTimer>();

    private void Awake()
    {
        _player = Resources.Load<PlayerMovement>("Prefabs/Player");
        _enemy = Resources.Load<EnemyMovement>("Prefabs/Enemy");
        _timer = Resources.Load<Timer>("Prefabs/Timer");
        _winWindow = Resources.Load<WinWindow>("Prefabs/WinWindow");
        _failWindow = Resources.Load<FailWindow>("Prefabs/FailWindow");
    }

    private void Start()
    {
        CreatedUI();
        CreatedPlayer();
        CreatedEnemy();
        Setup();
    }

    private void CreatedUI()
    {
        _timerInstance = Instantiate(_timer, _timer.transform.position, Quaternion.identity, _canvas.transform);
        _timerInstance.GetComponent<RectTransform>().localPosition = _timer.transform.position;
        
       WinWindow winWindowInstance = Instantiate(_winWindow, _winWindow.transform.position, Quaternion.identity, _canvas);
       winWindowInstance.GetComponent<RectTransform>().localPosition = _winWindow.transform.position;
        _setupTimer.Add(winWindowInstance); 
        
        FailWindow failWindowInstance = Instantiate(_failWindow, _failWindow.transform.position, Quaternion.identity, _canvas);
        failWindowInstance.GetComponent<RectTransform>().localPosition = _failWindow.transform.position;
        _setupPlayer.Add(failWindowInstance);
    }
    
    private void CreatedPlayer()
    {
       _playerInstance = Instantiate(_player, _playerStartPoint.transform.position, Quaternion.identity, _playerStartPoint.transform);
    }

    private void CreatedEnemy()
    {
        foreach (Transform point in _enemyStartPoint)
        {
            IEntryPointSetupPlayer enemy = Instantiate(_enemy, point.position, Quaternion.identity, point.transform);
            _setupPlayer.Add(enemy);
        }
    } 

    private void Setup()
    {
        foreach (IEntryPointSetupPlayer setupPlayer in _setupPlayer)
        {
            setupPlayer.SetupPlayer(_playerInstance);
        }

        foreach (IEntryPointSetupTimer setupTimer in _setupTimer)
        {
            setupTimer.SetupTimer(_timerInstance);
        }
    }
}
