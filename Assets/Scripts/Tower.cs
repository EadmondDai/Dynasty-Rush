using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int goldNeed;
    public int GoldNeed {get { return goldNeed; } }


    public Tower CreateTower(Tower prefab, Vector3 position)
    {

        var towObj = Instantiate(prefab, position, Quaternion.identity);
        return towObj;
    }
}
