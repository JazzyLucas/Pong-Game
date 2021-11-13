using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Uses the Vertical input axis as input for controlling up/down movement of a paddle.
/// </summary>
/// <remarks>
/// Should be attached to a pong ball.
/// </remarks>
public class BallStart : MonoBehaviour
{
    private Rigidbody ballrb;
    private float startForce = 4f;
    private float gameAcceleration = 0.0015f;

    private void Start()
    {
        // Initializations
        ballrb = this.GetComponent<Rigidbody>();
    }

    public void ResetBall()
    {
        IEnumerator coroutine = SmallDelayToLaunch();
        StartCoroutine(coroutine);
    }

    public void LaunchBall()
    {
        Vector3 ballLaunchDirection = new Vector3();

        // Determine where to launch based on Random
        int ballLaunchRand = Random.Range(0, 3);
        switch (ballLaunchRand)
        {
            case 0:
                GameManager.instance.didPlayerHitBall = false;
                ballLaunchDirection = Vector3.left + Vector3.up;
                break;
            case 1:
                GameManager.instance.didPlayerHitBall = false;
                ballLaunchDirection = Vector3.left - Vector3.up;
                break;
            case 2:
                GameManager.instance.didPlayerHitBall = true;
                ballLaunchDirection = Vector3.right + Vector3.up;
                break;
            case 3:
                GameManager.instance.didPlayerHitBall = true;
                ballLaunchDirection = Vector3.right - Vector3.up;
                break;
        }

        // Launch the ball
        ballrb.AddForce(ballLaunchDirection * startForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        ballrb.velocity += ballrb.velocity * gameAcceleration;
    }

    IEnumerator SmallDelayToLaunch()
    {
        ballrb.velocity = Vector3.zero;
        yield return new WaitForSecondsRealtime(0.5f);
        LaunchBall();
    }
}
