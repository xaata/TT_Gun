using System.Collections;
using UnityEngine;

public class PhysicsWeapon : WeaponBase
{
    [SerializeField] private PhysicsProjectile _prefabs;
    [SerializeField] private float _maxPower = 15f;
    [SerializeField] private float _chargeRate = 10f;
    private float _currentPower;
    private Vector2 _cachedDir;

    public override void OnPointerDown(Vector2 touchPosition)
    {
        RotateTo(touchPosition);
        _currentPower = 0;
        StartCoroutine(Charge());
    }
    public override void OnPointerUp(Vector2 touchPosition)
    {
        RotateTo(touchPosition);
        _cachedDir = barrelTip.right;
        StopAllCoroutines();
        Shoot(_currentPower);
    }
    private IEnumerator Charge()
    {
        while (_currentPower < _maxPower)
        {
            _currentPower += _chargeRate * Time.deltaTime;
            yield return null;
        }
    }
    private void Shoot(float power)
    {
        PlayShootAnim();
        var p = Instantiate(_prefabs, barrelTip.position, Quaternion.LookRotation(Vector3.forward, _cachedDir) * Quaternion.Euler(0,0,90));
        p.Init(barrelTip.right, power);
    }
}
