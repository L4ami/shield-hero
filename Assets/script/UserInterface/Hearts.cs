using UnityEngine;

public class Hearts : MonoBehaviour
{
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private GameObject hero;
    [SerializeField] private State state;

    private SpriteRenderer heart1Renderer;
    private SpriteRenderer heart2Renderer;
    private SpriteRenderer heart3Renderer;

    void Start()
    {
        if (heart1 == null) heart1 = GameObject.Find("Heart1");
        if (heart2 == null) heart2 = GameObject.Find("Heart2");
        if (heart3 == null) heart3 = GameObject.Find("Heart3");
        if (hero == null) hero = GameObject.Find("heros_garde_0");

        if (hero != null && state == null)
        {
            state = hero.GetComponent<State>();
        }

        if (heart1 == null || heart2 == null || heart3 == null || state == null)
        {
            Debug.LogError("One of the components/objects is missing. (Hearts.cs)", this);
            enabled = false;
            return;
        }

        heart1Renderer = heart1.GetComponent<SpriteRenderer>();
        heart2Renderer = heart2.GetComponent<SpriteRenderer>();
        heart3Renderer = heart3.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateHeartColors();
    }

    private void UpdateHeartColors()
    {
        int currentHp = state.hp;

        heart1Renderer.color = currentHp >= 1 ? Color.green : Color.black;
        heart2Renderer.color = currentHp >= 2 ? Color.green : Color.black;
        heart3Renderer.color = currentHp >= 3 ? Color.green : Color.black;
    }
}