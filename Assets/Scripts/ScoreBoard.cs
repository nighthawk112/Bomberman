using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public static int scoreValue = 0;
    Text Score;

    private void Start()
    {
        Score = GetComponent<Text>();
    }

    private void Update()
    {
        Score.text = "Score: " + scoreValue;
    }
}
