using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    int life = 100;
    //float speed = 10;

    //[HideInInspector]
    public string name_player_tag = "Cart Controller";

    public PlayerStaticVariable playerDetected;
    public UnityEvent<int, PlayerStaticVariable> OnReceiveDamage = new UnityEvent<int, PlayerStaticVariable>();

    public void ReceiveDamage(int damage_received, PlayerStaticVariable player)
    {
        life -= damage_received;
        //Debug.Log(life);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        //Debug.Log(damage_received);
        //Debug.Log(player);
        OnReceiveDamage?.Invoke(damage_received, player);
    }
}
