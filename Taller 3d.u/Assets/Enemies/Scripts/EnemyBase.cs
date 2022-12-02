using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour
{
    [Header("Collider")]
    public Collider self;
    

    [Header("Player info")]
    [Space]
    public string name_player_tag = "Cart Controller";
    public PlayerStaticVariable playerDetected;
    /*public UnityEvent<int, PlayerStaticVariable> OnReceiveDamage = new UnityEvent<int, PlayerStaticVariable>();
    */
   
}
