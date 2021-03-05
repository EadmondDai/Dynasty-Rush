using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
    [SerializeField] GameObject enemyObj;
    [SerializeField] int numOfEnemyThisWave = 10;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] int maxObjNum = 8;

    private GameObject[] objPool;

    // Start is called before the first frame update
    void Start()
    {
        objPool = new GameObject[maxObjNum];
        for(int i = 0; i < maxObjNum; ++i)
        {
            objPool[i] = Instantiate(enemyObj, transform);
            objPool[i].SetActive(false);
        }

        StartCoroutine(createEnemy());
    }

    GameObject findEnemy()
    {
        for(int i = 0; i < maxObjNum; ++i)
        {
            if (!objPool[i].active)
            {
                return objPool[i];
            }
        }

        //GameObject newEnemy = Instantiate(enemyObj, transform);
        //newEnemy.SetActive(false);

        ////TODO Check if this could work.
        //int curLenght = objPool.Length;
        //objPool[++curLenght] = newEnemy;

        //return newEnemy;
        return null;
    }

    IEnumerator createEnemy()
    {
        // for(int i = 0; i < numOfEnemyThisWave; i++)
        //{
        int curEnemyNum = 0;
        while (curEnemyNum < numOfEnemyThisWave)
        {
            curEnemyNum++;
            GameObject newNemey = findEnemy();
            newNemey.SetActive(true);
            newNemey.transform.position = transform.position;
            
            yield return new WaitForSeconds(spawnDelay);
        }
        //}
    }
}
