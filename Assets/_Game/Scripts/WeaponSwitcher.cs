using TMPro;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private WeaponBase[] _weapons;
    [SerializeField] private TMP_Text _weaponSwitchButtonText;
    private int _weaponIndex;

    private void Start()
    {
        Activate(0);
    }
    public void Toggle()
    {
        Activate(1 - _weaponIndex);
    }
    private void Activate(int index)
    {
        _weaponIndex = index;
        InputHandler.CurrentWeapon = _weapons[index];
        if (_weaponIndex == 0)
            _weaponSwitchButtonText.text = "Switch to type 2";
        else
            _weaponSwitchButtonText.text = "Switch to type 1";
    }
}
