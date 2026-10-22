using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Data/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private int _maxHP;
    [SerializeField] private float _detectRange;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _speed;
    [SerializeField] private int _attackValue;
    
    public int Id => _id;
    public string Name => _name;
    public int MaxHP => _maxHP;
    public float DetectRange => _detectRange;
    public float AttackRange => _attackRange;
    public float Speed => _speed;
    public int AttackValue => _attackValue;
    
}
