using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isByed = false;

    [SerializeField] protected Bullet Bullet;

    public string Lable => _lable;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsByed => _isByed;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isByed = true;
    }
}
