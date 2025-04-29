using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    [SerializeField] protected Transform barrelTip;
    [SerializeField] private float _minAngle = -80, _maxAngle = 80;
    [SerializeField] private Transform _fireArmSprite;
    public float MinAngle => _minAngle;
    public float MaxAngle => _maxAngle;

    public abstract void OnPointerDown(Vector2 touchPosition);
    public abstract void OnPointerUp(Vector2 touchPosition);

    protected void RotateTo(Vector2 touchPosition)
    {
        Vector2 direction = touchPosition - (Vector2)transform.position;
        float angle = Mathf.Clamp(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, _minAngle, _maxAngle);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected void PlayShootAnim() => _fireArmSprite.GetComponent<Animator>()?.SetTrigger("Shoot");
}
