using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour
{

    public Vector3 offset, rotationVelocity;
    public float recycleOffset, spawnChance;
    public ParticleSystem par1;
    public ParticleSystem par2;

    void Start()
    {
        GameEventManager.GameOver += GameOver;
        gameObject.active = false;
    }
    void OnTriggerEnter()
    {
        runner.AddBoost();
        par1.Play();
        par2.Play();
        gameObject.active = false;
    }

    public void SpawnIfAvailable(Vector3 position)
    {
        if (gameObject.active || spawnChance <= Random.Range(0f, 100f))
        {
            return;
        }
        transform.localPosition = position + offset;
        gameObject.active = true;
    }
    void Update()
    {
        if (transform.localPosition.x + recycleOffset < runner.distanceTraveled)
        {
            gameObject.active = false;
            return;
        }
        transform.Rotate(rotationVelocity * Time.deltaTime);
    }
    private void GameOver()
    {
        gameObject.active = false;
    }
}