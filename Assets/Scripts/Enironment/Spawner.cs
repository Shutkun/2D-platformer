using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private FirstAidKit _firstAidKit;
    [SerializeField] private Transform[] _spawnPoints;

    private List<int> _numbers = new List<int>();
    private int _spawnCount = 1;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        while (_spawnCount > 0)
        {
            int number = Random.Range(0, _spawnPoints.Length);

            if (_numbers.Contains(number) == false)
            {
                Transform position = _spawnPoints[number];
                FirstAidKit spawnObject = Instantiate(_firstAidKit, position);
                _numbers.Add(number);
                _spawnCount--;
            }
        }
    }
}
