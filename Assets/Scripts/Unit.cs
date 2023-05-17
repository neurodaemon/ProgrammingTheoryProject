using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected int m_HP;
    protected int m_MaxHP;
    protected int m_BaseDamage;
    protected int m_RegenValue;
    protected float m_RegenSpeed;
    protected bool m_IsKnockedOut;
    protected TextMeshProUGUI m_HPDisplay;

    // ENCAPSULATION though unused
    public int HP { get { return m_HP; } }
    public int MaxHP { get { return m_MaxHP; } }
    public bool isKnockedOut { get { return m_IsKnockedOut; } }

    // Start is called before the first frame update
    void Start()
    {
        Init(); // ABSTRACTION
        InvokeRepeating("RegenerateHP", m_RegenSpeed, m_RegenSpeed);
        m_HPDisplay = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsKnockedOut && m_HP == m_MaxHP)
        {
            WakeUp(); // ABSTRACTION
        }

        m_HPDisplay.text = $"HP: {m_HP}/{m_MaxHP}";
    }

    protected virtual void Init()
    {
        m_MaxHP = 10;
        m_HP = m_MaxHP;
        m_BaseDamage = 1;
        m_RegenValue = 1;
        m_RegenSpeed = 2.0f;
        m_IsKnockedOut = false;
    }

    protected virtual void RegenerateHP()
    {
        if (m_HP < m_MaxHP)
        {
            m_HP += m_RegenValue;
        }
        if (m_HP > m_MaxHP)
        {
            m_HP = m_MaxHP;
        }
    }

    public virtual void WakeUp()
    {
        m_IsKnockedOut = false;
    }

    public abstract void MainActionOnTarget(Unit target);

    public virtual void AttackTarget(Unit target)
    {
        if(!m_IsKnockedOut && target != null)
        {
            target.TakeDamage(m_BaseDamage);
        }
    }

    protected virtual void HealTarget(Unit target)
    {
        if (!m_IsKnockedOut && target != null)
        {
            target.HealDamage(m_BaseDamage);
        }
    }

    public virtual void TakeDamage(int amount)
    {
        m_HP -= amount;
        if (m_HP <= 0)
        {
            m_IsKnockedOut = true;
        }
    }

    protected virtual void HealDamage(int amount)
    {
        m_HP += amount;
        if (m_HP > m_MaxHP)
        {
            m_HP = m_MaxHP;
        }
    }
}
