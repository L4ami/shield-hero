using UnityEngine; 

public class LanceurFleches : MonoBehaviour
{
    [SerializeField] Stats[] fleches;

    [SerializeField] float pauseMin = .5f;
    [SerializeField] float pauseMax = 1f;

    float chrono;

    [SerializeField] float tempsAvantTir = 1f;

    Stats flecheEnAttente;

    float chronoTir;

    void Start()
    {
        if (fleches == null || fleches.Length == 0)
        {
            fleches = FindObjectsByType<Stats>();
        }

        foreach (Stats fleche in fleches)
        {
            fleche.active = false;
        }

        chrono = Random.Range(pauseMin, pauseMax);
    }
    void Update()
    {
        if (fleches.Length == 0)
            return;

        if (flecheEnAttente != null)
        {
            chronoTir -= Time.deltaTime;
            if (chronoTir > 0f)
                return;

            flecheEnAttente.active = true;

            flecheEnAttente.gobelin.Play("goblin_idle_" + flecheEnAttente.direction.ToLower());

            flecheEnAttente = null;
            return;
        }

        foreach (Stats fleche in fleches)
        {
            if (fleche.active)
                return;
        }

        chrono -= Time.deltaTime;

        if (chrono > 0f)
            return;

        int numero = Random.Range(0, fleches.Length);

        flecheEnAttente = fleches[numero];
  
        flecheEnAttente.gobelin.Play("goblin_charge_" + flecheEnAttente.direction.ToLower());

        chronoTir = tempsAvantTir;

        chrono = Random.Range(pauseMin, pauseMax);
    }
}
