
using System.Collections.Generic;
using UnityEngine;

public class trajectoire : MonoBehaviour
{
    [Header("Trajectoire")]

    [SerializeField] float distanceMax = 10f;

    [Header("Source des valeurs")]

    [SerializeField] Stats stats;

    Vector3 positionDepart;

    SpriteRenderer rendu;

    Dictionary<string, string> DirOpp = new Dictionary<string, string>
    {
        ["Bas"] = "Haut",
        ["Haut"] = "Bas",
        ["Droite"] = "Gauche",
        ["Gauche"] = "Droite",
    };

    void Start()
    {
        
        if (stats == null)
            stats = GetComponent<Stats>();

        if (stats == null)
        {
            Debug.LogError("trajectoire : il manque le composant Stats.");

            enabled = false;

            return;
        }

        positionDepart = transform.position;

        rendu = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
     
        if (rendu != null)
            rendu.enabled = stats.active;

        if (!stats.active)
        {
            transform.position = positionDepart;

            return;
        }

        int x=0, y=0;

        if (stats.direction == "Gauche")       
        {
            x = -1;
        }
        else if (stats.direction == "Haut")     
        {
            y = 1;
        }
        else if (stats.direction == "Bas")     
        {
            y = -1;
        }
        else                                     
        {
            x = 1; 
        }

        Vector3 direction = new Vector3(x, y, 0);

        Vector2 deplacement = direction.normalized * stats.vitesse * Time.deltaTime;

        transform.position += new Vector3(deplacement.x, deplacement.y, 0f);

        Vector3 p = transform.position;   
        bool touche = false;              

        if (stats.direction == "Droite")       
            touche = p.x >= 5.4f && p.x <= 5.65f;
        else if (stats.direction == "Gauche")  
            touche = p.x >= 6.25f && p.x <= 6.5f;
        else if (stats.direction == "Bas")    
            touche = p.y >= -5.55f && p.y <= -5.3f;
        else if (stats.direction == "Haut")    
            touche = p.y >= -6.45f && p.y <= -6.2f;

        if (touche)
        {
            transform.position = positionDepart;
            stats.active = false;

          
            State heros = FindAnyObjectByType<State>();
       
            if (stats.direction != DirOpp[heros.direction])
            {

                heros.hp -= 1;
                Debug.Log("Touché ! Cœurs restants : " + heros.hp);
              
                if (heros.hp <= 0)
                {
                    heros.hp = 0;                        
                    heros.gameObject.SetActive(false);  
                    Time.timeScale = 0f;                
                    Debug.Log("GAME OVER");
                }
            }
            else
            {
                Debug.Log("Parried!");

                heros.score += 100;
             
                Debug.Log(heros.score);
            }
        }

       
        if (Vector3.Distance(positionDepart, transform.position) >= distanceMax)

        {
            transform.position = positionDepart;

            stats.active = false;
        }
    }
}
