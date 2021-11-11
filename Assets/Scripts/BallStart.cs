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
    private float startForce = 5f;

    private void Start()
    {
        // Initializations
        ballrb = this.GetComponent<Rigidbody>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        Vector3 ballLaunchDirection = new Vector3();

        // Determine where to launch based on Random
        int ballLaunchRand = Random.Range(0, 3);
        switch (ballLaunchRand)
        {
            case 0:
                ballLaunchDirection = Vector3.left + Vector3.up;
                break;
            case 1:
                ballLaunchDirection = Vector3.left - Vector3.up;
                break;
            case 2:
                ballLaunchDirection = Vector3.right + Vector3.up;
                break;
            case 3:
                ballLaunchDirection = Vector3.right - Vector3.up;
                break;
        }

        // Launch the ball
        ballrb.AddForce(ballLaunchDirection * startForce, ForceMode.Impulse);
    }
}
