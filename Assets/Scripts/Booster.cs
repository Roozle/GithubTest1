using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour
{

    public Vector3 offset, rotationVelocity;
    public float recycleOffset, spawnChance;

    void Start()
    {
        GameEventManager.GameOver += GameOver;
        gameObject.SetActive(false);
    }

    public void SpawnIfAvailable(Vector3 position)
    {
        if (gameObject.activeSelf || spawnChance <= Random.Range(0f, 100f))
        {
            return;
        }
        transform.localPosition = position + offset;
        gameObject.SetActive(true);
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
    }
}