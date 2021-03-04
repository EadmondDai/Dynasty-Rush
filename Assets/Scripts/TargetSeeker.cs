using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSeeker : MonoBehaviour
{
    public GameObject target;
    public float minDistanceToTarget = float.MaxValue;

    [SerializeField] GameObject cannon;
    [SerializeField] float shootingRange = 20f;
    [SerializeField] ParticleSystem bulletParticle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestObj = null;
        float minDistance = float.MaxValue;
        foreach(GameObject enemy in enemies)
        {
            if (!enemy.active) continue;
            if(!closestObj || Vector3.Distance(transform.position, enemy.transform.position) < minDistance)
            {
                closestObj = enemy;
                minDistance = Vector3.Distance(transform.position, enemy.transform.position);
            }
        }
        target = closestObj;
        minDistanceToTarget = minDistance;
    }

    void AimWeapon()
    {
        if (target && minDistanceToTarget <= shootingRange)
        {
            cannon.transform.LookAt(target.transform);
            ToggleAttack(true);
        }
        else
        {
            ToggleAttack(false);
        }
    }

    void ToggleAttack(bool enable)
    {
        var emissionSys = bulletParticle.emission;
        emissionSys.enabled = enable;
    }
}
