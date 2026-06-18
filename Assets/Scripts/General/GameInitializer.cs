using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject gameEventManagerPrefab;

    private void Awake()
    {
        if (GameEventManager.Instance == null && gameEventManagerPrefab != null)
        {
            Instantiate(gameEventManagerPrefab);
        }
    }
}
