using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (!player.IsDead)
            player.Die();
    }
}
