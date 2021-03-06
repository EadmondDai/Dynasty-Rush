using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ObjPool : MonoBehaviour
{
    [SerializeField] GameObject enemyObj;
    [SerializeField] int numOfEnemyThisWave = 10;
    [Range(0.5f, 30)] [SerializeField] float spawnDelay = 1f;
    [Tooltip("Need to make sure always have enough enemy available")] [Range(1, 50)] [SerializeField] int maxObjNum = 8;

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

        return null;
    }

    IEnumerator createEnemy()
    {
        int curEnemyNum = 0;
        while (curEnemyNum < numOfEnemyThisWave)
        {
            
            GameObject newNemey = findEnemy();
            if (newNemey)
            {
                newNemey.SetActive(true);
                newNemey.transform.position = transform.position;
                curEnemyNum++;
            }
            
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
