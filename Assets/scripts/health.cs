﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int healthPoints;
    public float checkRadius;
    public Transform checker;
    public LayerMask EnemyLayer;
    public GameObject heartImage;
    public GameObject deathText;

    void getDamage(){
        heartImage.GetComponent<ShowHP>().HP--;
        healthPoints--;
        if(healthPoints <= 0){
            die();
        }
    }

    void die(){
        deathText.SetActive(true);
        Debug.Log("Lmao kuolit senkin tyhmyri!");
        Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" ){
            if(Physics2D.OverlapCircle(checker.position, checkRadius, EnemyLayer)){
                Debug.Log("Epic");
                Destroy(other.gameObject);
            }
            else{
                getDamage();
            }
        }
        if(other.gameObject.tag == "Hazard"){
            getDamage();
        }
    }
}
