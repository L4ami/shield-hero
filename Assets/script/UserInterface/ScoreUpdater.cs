using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] State heros;
    [SerializeField] TextMeshProUGUI UIText;

    void Start()
    {
        if (heros == null)
        {
            heros = FindAnyObjectByType<State>();
            
        }
        if (UIText == null)
        {
            UIText = GameObject.Find("TextTMP").GetComponent<TextMeshProUGUI>();
        }

        if (heros==null || UIText == null)
        {
            Debug.LogError("something's missing.", this);
            enabled = false;
            return;
        }
    }
    void Update()
    {
        if (UIText != null)
        {
            UIText.text = $"Score : {heros.score} pts";
        }
    }
}
