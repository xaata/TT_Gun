using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsProjectile : ProjectileBase
{
    [SerializeField] private float _baseSpeed = 5f;
    private const float BASE_POWER = 1f;
    private Rigidbody2D _rb;

    void Awake() => _rb = GetComponent<Rigidbody2D>();

    public override void Init(Vector2 direction, float pwr)
    {
        base.Init(direction, pwr);
        _rb.linearVelocity = direction * (_baseSpeed * (BASE_POWER + _power));
    }
}
