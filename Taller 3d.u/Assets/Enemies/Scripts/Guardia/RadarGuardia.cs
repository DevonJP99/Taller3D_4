using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarGuardia : MonoBehaviour
{
    public GuardiaPasiveState pasiva;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyBase enem = other.GetComponent<EnemyBase>();
            enem.OnReceiveDamage.AddListener(pasiva.SwitchingState);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBase enem = other.GetComponent<EnemyBase>();
            enem.OnReceiveDamage.RemoveListener(pasiva.SwitchingState);
        }
    }
}
