using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour, IProjectile
{
    protected Vector2 _direction;
    protected float _power;
    public virtual void Init(Vector2 dir, float power)
    {
        _direction = dir;
        _power = power;
    }
}
