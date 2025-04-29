using UnityEngine;

public class BouncingWeapon : WeaponBase
{
    [SerializeField] private BouncingProjectile _prefab;
    private Vector2 _cachedDir;
    public override void OnPointerDown(Vector2 touchPosition)
    {
        RotateTo(touchPosition);       
    }

    public override void OnPointerUp(Vector2 touchPosition)
    {
        RotateTo(touchPosition);
        _cachedDir = barrelTip.right;
        Shoot(1f);
    }

    private void Shoot(float power)
    {
        PlayShootAnim();
        var p = Instantiate(_prefab, barrelTip.position, Quaternion.LookRotation(Vector3.forward, _cachedDir ));
        p.Init(_cachedDir, power);
    }
}
