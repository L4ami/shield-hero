using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] State StateSettings;

    [SerializeField] SpriteRenderer SpriteRend;

    void Start()
    {
 
        if (StateSettings == null)
            StateSettings = GetComponent<State>();

        if (SpriteRend == null)
            SpriteRend = GetComponent<SpriteRenderer>();
        if (animator == null)
            animator = GetComponent<Animator>();

        if (StateSettings == null || SpriteRend == null || animator==null)
        {
   
            Debug.LogError("One of hero's components is missing. (Animation script)");
            enabled = false;
            return;
        }
    }

    string currAnimation = "Bas";
 
    int TimePosition = 0;
    int tpadd = 1;

    private void Update()
    {
    
        if (StateSettings != null)
        {
            if (!string.IsNullOrEmpty(StateSettings.direction))
            {

                if (currAnimation != StateSettings.direction)
                {
               
                    currAnimation = StateSettings.direction;
                  
                    animator.Play("hero_idle_" + currAnimation.ToLower());
                }
            }
        }
    }
}
