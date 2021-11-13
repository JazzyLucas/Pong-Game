using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Uses the Vertical input axis as input for controlling up/down movement of a paddle.
/// </summary>
/// <remarks>
/// Should be attached to a pong paddle.
/// </remarks>
public class PaddleControl : MonoBehaviour
{
    [SerializeField] GameObject topLimitBox;
    [SerializeField] GameObject bottomLimitBox;
    [Header("Leave null if this is player controlled.")]
    [SerializeField] GameObject pongBall;
    private GameObject paddle;

    // Internals
    private bool isAI;
    private float AISpeed = 0.1f;
    private float input, previousMouseY, topLimit, bottomLimit, yVelocityRef;

    void Start()
    {
        // Initializations
        paddle = this.gameObject;
        topLimit = topLimitBox.transform.position.y - 2;
        bottomLimit = bottomLimitBox.transform.position.y + 2;
        previousMouseY = Input.mousePosition.y;
        try
        {
            Debug.Log(this.name + " has found " + pongBall.name);
            isAI = true;
        }
        catch (System.Exception)
        {
            isAI = false;
        }
    }

    void Update()
    {
        if (isAI)
        {
            if (!GameManager.instance.didPlayerHitBall)
                return;
            float damp = Mathf.SmoothDamp(paddle.transform.position.y, pongBall.transform.position.y, ref yVelocityRef, AISpeed);
            paddle.transform.position = new Vector3(paddle.transform.position.x, damp, paddle.transform.position.z);
            float clampedValueAI = Mathf.Clamp(paddle.transform.position.y + input, bottomLimit, topLimit);
            paddle.transform.position = new Vector3(paddle.transform.position.x, clampedValueAI, paddle.transform.position.z);
            return;
        }

        // Getting Input
        float mouseYChange = (Input.mousePosition.y - previousMouseY) / 100;
        previousMouseY = Input.mousePosition.y;
        input = Input.GetAxis("Vertical") != 0 ? Input.GetAxis("Vertical") * Time.deltaTime * 30f : mouseYChange;

        // Moving the paddle
        float clampedValue = Mathf.Clamp(paddle.transform.position.y + input, bottomLimit, topLimit);
        paddle.transform.position = new Vector3(paddle.transform.position.x, clampedValue, paddle.transform.position.z);
    }
}
