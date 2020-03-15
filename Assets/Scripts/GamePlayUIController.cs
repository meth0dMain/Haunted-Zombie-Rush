using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class GamePlayUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;

    private void Awake()
    {
        Assert.IsNotNull(scoreLabel);
    }

    private void Update()
    {
        var scoreAsInt = (int) GameManager.instance.score;
        scoreLabel.text = scoreAsInt.ToString();
    }
}
