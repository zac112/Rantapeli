﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public float xAngle, yAngle;
    [SerializeField]
    GameObject[] points;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator coroutine = Valinta();
        StartCoroutine(coroutine);
    }
    IEnumerator Valinta()
    {
        Debug.Log("Heey");
        while (true)
        {
            //Nuolen pyöritys
            gameObject.transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), Space.Self);

            //Pelaajan valintojen managerointi
            if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
            {
                i = Mathf.Clamp(i+1, 0, points.Length-1);
                Debug.Log(i);
                gameObject.GetComponent<Transform>().position = points[i].GetComponent<Transform>().position;
            }
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                i = Mathf.Clamp(i - 1, 0, points.Length-1);
                Debug.Log(i);
                gameObject.GetComponent<Transform>().position = points[i].GetComponent<Transform>().position;
            }
            //Jos pelaaja painaa välilyöntiä, ladataan haluttu scene
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (i == 0)
                {
                    SceneManager.LoadScene(0);
                }
                if (i == 1)
                {
                    SceneManager.LoadScene(0);
                }
                if (i == 2)
                {
                    Application.Quit(0);
                }
            }
            yield return null;
        }
    }
}