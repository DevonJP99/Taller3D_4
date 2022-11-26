using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaAtackState : EnemyBaseState
{
    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        //posicionarme al lado del player
        //desactivar a player habilidades
        // activar panel de presionar botones
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        //hrow new System.NotImplementedException();
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {

    }
}
