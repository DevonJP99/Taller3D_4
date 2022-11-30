using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompradorStateManager : EnemyBaseStateMachine
{
    [SerializeField]
    Collider cart;

    public void ReceiveDamage(int damage_received, PlayerStaticVariable player)
    {
        //aniamtion destroy
        //OnReceiveDamage?.Invoke(damage_received, player);
        Destroy(gameObject);
        //unables ai, gravity
        //actives traigger or no collider
        // force
    }
}
