using UnityEngine;

[CreateAssetMenu(fileName ="Stats", menuName = "Scriptble Object/Charactes Stats")]
public class CharactersStats : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private int _health;
    [SerializeField] private int _defence;

    [Header("Ausio Attack")]
    [SerializeField] private AudioClip _audioAttack;

    public int Health => _health;
    public int Defence => _defence;
    public AudioClip AudioAttack => _audioAttack;
}
