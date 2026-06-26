using System.Collections.Generic;
using UnityEngine;

public class SpawnerFirstAidKits : MonoBehaviour
{
    [SerializeField] private FirstAidKit _firstAidKit;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            int index = Random.Range(0, _spawnPoints.Count);

            Transform position = _spawnPoints[index];
            FirstAidKit spawnObject = Instantiate(_firstAidKit, position);

            _spawnPoints.RemoveAt(index);
        }
    }
}
