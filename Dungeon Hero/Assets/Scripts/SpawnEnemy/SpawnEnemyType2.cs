using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyType2 : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;
    bool isSummon = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            if (!isSummon)
            {
                int randomEnemy = Random.Range(0, enemies.Length);
                Instantiate(enemies[randomEnemy], transform.position, transform.rotation);
                isSummon = true;
            }
        }
    }
}
