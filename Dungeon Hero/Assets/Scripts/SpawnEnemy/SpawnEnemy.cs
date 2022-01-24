using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int numberEnemy = 10;
    public int currentEnemy = -1;

    [SerializeField]
    GameObject[] enemyType;
    GameObject[] enemies;

    int[] enemyRate = { };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountCurrentEnemies();
    }

    // spawn enemy with enemyRate
    public void Spawn()
    {
        currentEnemy = numberEnemy;
        if (numberEnemy == 0) {
            return;
        }
        enemies = new GameObject[numberEnemy];
        for (int i = 0; i < enemyType.Length; i++)
        {
            for (int j = 0; j < enemyType[i].GetComponent<EnemyController>().rateAppear; j++)
            {
                int[] newEnemyRate = new int[enemyRate.Length + 1];
                enemyRate.CopyTo(newEnemyRate, 0);
                newEnemyRate[enemyRate.Length] = i;
                enemyRate = newEnemyRate;
            }
        }
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

    public void LevelUp()
    {
        // more number of enemies
        numberEnemy += 1;

        // upgrade streng of enemies
        for (int i = 0; i < enemyType.Length; i++)
        {
            enemyType[i].GetComponent<EnemyController>().UpgradeStreng(100, 1, 0.1f);
        }

        // upgrade rate hard enemies
        //enemyRate.Concat(new int[] {MINOTAUR, MAGE, SADGUY, SKELETON, MELEESKELETON}).ToArray();
    }
}
