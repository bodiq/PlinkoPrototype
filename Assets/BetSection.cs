using UnityEngine;
using UnityEngine.UI;

public class BetSection : MonoBehaviour
{
    [SerializeField] private Button greenButton;
    [SerializeField] private Button yellowButton;
    [SerializeField] private Button redButton;

    private void OnEnable()
    {
        greenButton.onClick.AddListener(TableManager.Instance.BallSpawnZone.SpawnGreenBall);
        yellowButton.onClick.AddListener(TableManager.Instance.BallSpawnZone.SpawnYellowBall);
        redButton.onClick.AddListener(TableManager.Instance.BallSpawnZone.SpawnRedBall);
    }

    private void OnDisable()
    {
        greenButton.onClick.RemoveListener(TableManager.Instance.BallSpawnZone.SpawnGreenBall);
        yellowButton.onClick.RemoveListener(TableManager.Instance.BallSpawnZone.SpawnYellowBall);
        redButton.onClick.RemoveListener(TableManager.Instance.BallSpawnZone.SpawnRedBall);
    }
}
