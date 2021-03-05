using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))][DisallowMultipleComponent]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealthPoint = 5;
    [Tooltip("Ammount to increase the health when enemy dies")] [SerializeField] int difficultyFactor = 1;
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
            maxHealthPoint += difficultyFactor;
            gameObject.SetActive(false);
        }
    }
}
