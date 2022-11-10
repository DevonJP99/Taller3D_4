using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    int life = 100;
    float speed = 10;
    //[HideInInspector]

    public PlayerStaticVariable playerDetected;
    public UnityEvent<int, PlayerStaticVariable> OnReceiveDamage;

    public void ReceiveDamage(int damage_received, PlayerStaticVariable player = null)
    {
        OnReceiveDamage?.Invoke(damage_received, player);
        life -= damage_received;
        Debug.Log(life);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
