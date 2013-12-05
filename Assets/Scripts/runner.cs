using UnityEngine;
using System.Collections;

public class runner : MonoBehaviour
{
    public static float distanceTraveled;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(29f * Time.deltaTime, 0f, 0f);
        distanceTraveled = transform.localPosition.x;

    }
}
