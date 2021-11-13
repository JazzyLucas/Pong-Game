using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTrigger : MonoBehaviour
{
    [SerializeField] private bool isAi = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameManager.instance.didPlayerHitBall = !isAi;
        }
    }
}
