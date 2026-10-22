using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private EnemyStats _stats;

    private void Start()
    {
        _id = _stats.Id;
        
        Debug.Log(_id);
    }
}
