using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Coroutine _bonusTick;
    
    [field: SerializeField] public bool IsTookBonus { get; private set; }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bonus bonus))
        {
            if (IsTookBonus)
                return;
            IsTookBonus = true;
            StartCoroutine(BonusTick(bonus.Time));
            bonus.DestroyBonus();
        }
    }

    private IEnumerator BonusTick(float time)
    {
        yield return new WaitForSeconds(time);
        IsTookBonus = false;
    }
}
