using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{

    private Dictionary<string, Dictionary<string, Vector3>> Sides = new Dictionary<string, Dictionary<string, Vector3>>()
    {
        ["Haut"] =
        {
            ["Position"] = new Vector3(0, 0, 0),
            ["Rotation"] = new Vector3(0, 0, 90f),
        },
        ["Bas"] =
        {
            ["Position"] = new Vector3(0, 0, 0),
            ["Rotation"] = new Vector3(0, 0, -90f),
        },
        ["Droite"] =
        {
            ["Position"] = new Vector3(3.125f, -5.95f, 0),
            ["Rotation"] = new Vector3(0, 0, 180f),
        },
        ["Gauche"] =
        {
            ["Position"] = new Vector3(9, -5.95f, 0),
            ["Rotation"] = new Vector3(0, 0, 0),
        },
    };
   [SerializeField] GameObject ArrowTemplate;
    void Start()
    {
        if (ArrowTemplate == null)
        {
            ArrowTemplate = GameObject.Find("fleche_feu");
        }


        if (ArrowTemplate != null)
        {
            foreach(var item in Sides.Keys)
            {
                SpawnerLoop(item);
            }
        }
        else
        {
            Debug.LogWarning("Arrow not found");
            enabled = false;
        }
    }

    IEnumerator SpawnerLoop(string Side)
    {
        do
        {
            yield return new WaitForSeconds(1f);
        } while (true);
    }


}






///////////////////
