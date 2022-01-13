using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnermy : MonoBehaviour
{
    public int numberEnemy = 10;
    public int currentEnemy;

    [SerializeField]
    GameObject[] enemyType;
    GameObject[] enemies;
    const int MINOTAUR = 0;
    const int MAGE = 1;
    const int SADGUY = 2;
    const int SKELETON = 3;
    const int MELEESKELETON = 4;
    int[] enemyRate = { MINOTAUR, MAGE, MAGE, SADGUY, SADGUY, SKELETON, SKELETON, SKELETON, SKELETON, MELEESKELETON, MELEESKELETON, MELEESKELETON, MELEESKELETON };


    // Start is called before the first frame update
    void Start()
    {
        currentEnemy = numberEnemy;
        enemies = new GameObject[numberEnemy];
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        CountCurrentEnemies();
    }

    // spawn enemy with enemyRate
    public void Spawn()
    {
        for (int i = 0; i < numberEnemy; i++)
        {
            int randomType = Random.Range(0, enemyRate.Length);
            float randomPositionX = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
            float randomPositionY = Random.Range(transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2);
            Vector2 position = new Vector2(randomPositionX, randomPositionY);
            enemies[i] = Instantiate(enemyType[enemyRate[randomType]], position, transform.rotation);
        }
    }

    private void CountCurrentEnemies()
    {
        int enemyKilled = -1;
        for (int i = 0; i < currentEnemy; i++)
        {
            if (enemies[i] == null)
            {
                enemyKilled = i;
            }
        }
        if (enemyKilled != -1)
        {
            for (int i = enemyKilled; i < currentEnemy - 1; i++)
            {
                enemies[i] = enemies[i + 1];
            }
            currentEnemy--;
        }
    }

    public void LevelUp() {
        // more number of enemies
        numberEnemy += 1;

        // upgrade streng of enemies
        for (int i = 0; i < enemyType.Length; i++) {
            enemyType[i].GetComponent<EnemyController>().UpgradeStreng();
        }

        // upgrade rate hard enemies
        enemyRate.Concat(new int[] {MINOTAUR, MAGE, SADGUY, SKELETON, MELEESKELETON}).ToArray();
    }
}
 