using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerUnit : Unit
{
    protected override void Init()
    {
        m_MaxHP = 15;
        m_HP = m_MaxHP;
        m_BaseDamage = 2;
        m_RegenValue = 2;
        m_RegenSpeed = 2.0f;
        m_IsKnockedOut = false;
    }

    public override void MainActionOnTarget(Unit target)
    {
        AttackTarget(target);
    }
}
