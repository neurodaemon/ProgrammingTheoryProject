using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RangerUnit : Unit
{
    // POLYMORPHISM
    protected override void Init()
    {
        m_MaxHP = 15;
        m_HP = m_MaxHP;
        m_BaseDamage = 2;
        m_RegenValue = 2;
        m_RegenSpeed = 2.0f;
        m_IsKnockedOut = false;
    }

    // POLYMORPHISM
    public override void MainActionOnTarget(Unit target)
    {
        AttackTarget(target); // ABSTRACTION
    }
}
