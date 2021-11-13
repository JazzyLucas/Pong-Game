using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollider : MonoBehaviour
{
    [Header("Must have a collider attached with onTrigger on.")]
    [SerializeField] private bool isEnemy = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameManager.instance.IncrementScore(this.isEnemy);
        }
    }
}
