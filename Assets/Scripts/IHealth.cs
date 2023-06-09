using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    int Damage { get; }
    void TakeDamage(int damage);
    void Heal(int health);
}

