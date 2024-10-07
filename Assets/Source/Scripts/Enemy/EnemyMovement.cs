using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour, IEntryPointSetupPlayer
{
    [SerializeField] private NavMeshAgent _enemy;
    [SerializeField] private Transform _playerTransform;


    private void OnValidate()
    {
        _enemy ??= GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_playerTransform == null)
            return;
        _enemy.destination = _playerTransform.position;
    }
    public void SetupPlayer(PlayerMovement playerTransform)
    {
        _playerTransform = playerTransform.transform;
    }
    
}
