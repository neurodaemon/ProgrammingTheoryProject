using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class WarriorUnit : Unit
{
    // POLYMORPHISM
    protected override void Init()
    {
        m_MaxHP = 20;
        m_HP = m_MaxHP;
        m_BaseDamage = 3;
        m_RegenValue = 2;
        m_RegenSpeed = 3.0f;
        m_IsKnockedOut = false;
    }

    // POLYMORPHISM
    public override void MainActionOnTarget(Unit target)
    {
        AttackTarget(target); // ABSTRACTION
    }
}
