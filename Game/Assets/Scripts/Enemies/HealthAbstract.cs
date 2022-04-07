using UnityEngine;

public abstract class HealthAbstract : MonoBehaviour
{
    public virtual void ApplyDamage(float amount) { }
    public virtual void Death() { Destroy(gameObject); }

}
