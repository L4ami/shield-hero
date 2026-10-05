
using UnityEngine;


public class Keybinds : MonoBehaviour
{
  
    [SerializeField] State StateSettings;

  
    void Start()
    {
        
        if (StateSettings == null)
            StateSettings = GetComponent<State>();

       
        if (StateSettings == null)
        {
            
            Debug.LogError("il manque le composant State.");
           
            enabled = false;
         
            return;
        }
    }
  
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            SwitchDirection("Haut");
        }
        
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SwitchDirection("Bas");
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchDirection("Gauche");
        }
        
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchDirection("Droite");
        }
    }

    
    void SwitchDirection(string direction)
    {
        
        if (string.IsNullOrEmpty(direction))
        {
            return;
        }
       
        StateSettings.direction = direction;
        
    }
}
