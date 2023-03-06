using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WeaponIcon : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _player.WeaponChenged += OnChengetWeapon;
    }

    private void OnDisable()
    {
        _player.WeaponChenged -= OnChengetWeapon;
    }

    private void OnChengetWeapon()
    {
        _image.sprite = _player.CurrentWeapon.Icon;
    }
}
