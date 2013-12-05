using UnityEngine;
using System.Collections;

public class runner : MonoBehaviour
{

    public static float distanceTraveled;
    public Vector3 boostVelocity, jumpVelocity;
    public Vector3 negVelocity;
    private Vector3 jumpSave;
    public float acceleration;
    public bool slowedRecently = false;
    private static int boosts;

    private bool touchingPlatform;

    public float gameOverY;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (touchingPlatform)
            {
                rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
                touchingPlatform = false;
            }
            else if (boosts > 0)
            {
                rigidbody.AddForce(boostVelocity, ForceMode.VelocityChange);
                boosts -= 1;
            }

            distanceTraveled = transform.localPosition.x;
        }


        if (Input.GetAxis("Horizontal") < 0)
        {

            rigidbody.AddForce(negVelocity, ForceMode.Force);
        }
        distanceTraveled = transform.localPosition.x;
        if (Input.GetAxis("Horizontal") > 0)
        {

            rigidbody.AddForce(-negVelocity, ForceMode.Force);
        }
        distanceTraveled = transform.localPosition.x;

        if (transform.localPosition.y < gameOverY)
        {
            GameEventManager.TriggerGameOver();
        }
    }


    IEnumerator Wait2()
    {
        print("12");
        yield return new WaitForSeconds(2);

    }

    void FixedUpdate()
    {
        if (touchingPlatform)
        {
            rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter()
    {
        touchingPlatform = true;
    }

    void OnCollisionExit()
    {
        touchingPlatform = false;
    }


    private Vector3 startPosition;

    void Start()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        startPosition = transform.localPosition;
        renderer.enabled = false;
        rigidbody.isKinematic = true;
        enabled = false;
    }

    private void GameStart()
    {
        boosts = 0;
        distanceTraveled = 0f;
        transform.localPosition = startPosition;
        renderer.enabled = true;
        rigidbody.isKinematic = false;
        enabled = true;
    }
    public static void AddBoost()
    {
        boosts += 1;
    }

    private void GameOver()
    {
        renderer.enabled = false;
        rigidbody.isKinematic = true;
        enabled = false;
    }
}