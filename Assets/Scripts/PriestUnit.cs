using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestUnit : Unit
{
    protected override void Init()
    {
        m_MaxHP = 12;
        m_HP = m_MaxHP;
        m_BaseDamage = 10;
        m_RegenValue = 4;
        m_RegenSpeed = 2.0f;
        m_IsKnockedOut = false;
    }

    public override void MainActionOnTarget(Unit target)
    {
        HealTarget(target);
    }
}
