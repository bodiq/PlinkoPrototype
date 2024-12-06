using System.Collections;
using System.Collections.Generic;
using Enums;
using Managers;
using UnityEngine;

public class BallSpawnZone : MonoBehaviour
{
    [SerializeField] private float minXOffset;
    [SerializeField] private float maxXOffset;

    private Vector3 GetRandomBallSpawnPos()
    {
        return new Vector3(Random.Range(minXOffset, maxXOffset), transform.position.y, transform.position.z);
    }

    private void SpawnNewBall(ColorTypes colorType)
    {
        var ball = ObjectPoolManager.Instance.GetBall(colorType);
        ball.transform.position = GetRandomBallSpawnPos();
        ball.gameObject.SetActive(true);
    }

    public void SpawnGreenBall()
    {
        SpawnNewBall(ColorTypes.Green);
    }
    
    public void SpawnYellowBall()
    {
        SpawnNewBall(ColorTypes.Yellow);
    }
    
    public void SpawnRedBall()
    {
        SpawnNewBall(ColorTypes.Red);
    }
}
