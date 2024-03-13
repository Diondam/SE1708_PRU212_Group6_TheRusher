using UnityEngine;

[CreateAssetMenu(fileName = "SoundData", menuName = "MyScriptableObject", order = 51)]
public class SoundData : ScriptableObject
{
    public AudioClip IdleSound;
    public AudioClip DieSound;
    public AudioClip AttackSound;
    public AudioClip MoveSound;

}