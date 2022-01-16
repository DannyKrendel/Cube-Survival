using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private WinZone _winZone;
    
    public event Action ShieldActivated;
    public event Action ShieldDeactivated;
    public event Action Died;
    
    public bool IsShieldActive { get; private set; }
    public bool IsDead { get; private set; }

    private IEnumerator Start()
    {
        _winZone = FindObjectOfType<WinZone>();
        yield return new WaitForSeconds(2);
        _navMeshAgent.SetDestination(_winZone.transform.position);
    }

    public void Respawn(Vector3 position)
    {
        IsDead = false;
        _navMeshAgent.Warp(position);
        _navMeshAgent.SetDestination(_winZone.transform.position);
    }

    public void Die()
    {
        if (!IsShieldActive)
        {
            IsDead = true;
            Died?.Invoke();
        }
    }

    public void ActivateShield()
    {
        if (IsShieldActive) return;
        IsShieldActive = true;
        ShieldActivated?.Invoke();
    }

    public void DeactivateShield()
    {
        if (!IsShieldActive) return;
        IsShieldActive = false;
        ShieldDeactivated?.Invoke();
    }
}
