using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currnetWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private Animator _animator;
    public int Money { get; private set; }
    public event UnityAction<int,int> HealthChanged;
    public event UnityAction<int> MoneuChenged;
    public event UnityAction WeaponChenged;
    public Weapon CurrentWeapon => _currnetWeapon;

    private void Start()
    {
        ChengedWeapon(_weapons[_currentWeaponNumber]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
        WeaponChenged?.Invoke();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currnetWeapon.Shoot(_shootPoint);
            _animator.SetBool("isShot", true);
        }
        else
        {
            _animator.SetBool("isShot", false);
        }
    }
    private void OnEnemyDie(int reward)
    {
        Money += reward;
    }

    public void ApplayDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneuChenged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneuChenged?.Invoke(Money);
    }

    public void NetxWeapon()
    {
        if(_currentWeaponNumber == _weapons.Count - 1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        ChengedWeapon(_weapons[_currentWeaponNumber]);
        WeaponChenged?.Invoke();
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        ChengedWeapon(_weapons[_currentWeaponNumber]);
        WeaponChenged?.Invoke();
    }

    private void ChengedWeapon(Weapon weapon)
    {
        _currnetWeapon = weapon;
    }
}
