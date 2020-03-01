﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{
    [SerializeField]
    private float minLifeTime, maxLifeTime;
    [SerializeField]
    private GameObject death = null;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitAndDie");
    }

    private IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(Random.Range(minLifeTime, maxLifeTime));
        Object.Destroy(gameObject);
        Instantiate(death, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);

    }
}
