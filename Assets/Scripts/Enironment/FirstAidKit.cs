using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int _healPower = 30;

    public int Healing => _healPower;

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
