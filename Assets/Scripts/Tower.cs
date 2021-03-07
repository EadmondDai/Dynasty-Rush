using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Tower : MonoBehaviour
{
    [SerializeField] int goldNeed;
    public int GoldNeed {get { return goldNeed; } }

    [SerializeField] float buildDelay = 2.0f;

    void Start()
    {
        StartCoroutine(Build());   
    }

    public Tower CreateTower(Tower prefab, Vector3 position)
    {
        var towObj = Instantiate(prefab, position, Quaternion.identity);
        return towObj;
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            transform.gameObject.SetActive(false);
            foreach(Transform grandChild in child)
            {
                transform.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandChild in child)
            {
                transform.gameObject.SetActive(true);
            }
        }
    }
}
