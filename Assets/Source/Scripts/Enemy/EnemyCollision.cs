using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth ??= GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth) && other.gameObject.TryGetComponent(out PlayerCollision playerCollision))
        {
            if (!playerCollision.IsTookBonus)
            {
                playerHealth.TakeDamage(1);
            }
            else
            {
                _enemyHealth.TakeDamage(1);
            }
        }
    }
}
