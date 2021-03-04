using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealthPoint = 5;
    [SerializeField] int curHealth;

    private Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        curHealth = maxHealthPoint;
    }

    void OnEnable()
    {
        curHealth = maxHealthPoint;    
    }

    void OnParticleCollision(GameObject other)
    {
        OnHit();
    }

    void OnHit()
    {
        curHealth--;
        if(curHealth <= 0)
        {
            if (enemyScript)
            {
                enemyScript.onDied();
            }
            gameObject.SetActive(false);
        }
    }
}
