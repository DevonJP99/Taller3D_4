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
    public UnityEvent<int, Player> OnReceiveDamage;

        public void ReceiveDamage(int damage_received, Player player = null)
        {
            OnReceiveDamage?.Invoke(damage_received, player);
            life -= damage_received;
        }
}
