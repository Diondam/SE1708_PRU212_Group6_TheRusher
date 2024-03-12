using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip UISound;
    // public float volumeFX = 0.7f;
    // public float volumeBG = 0.7f;


  

    [Header("Hero Sounds")] 
    public AudioClip heroJumpSound;
    public AudioClip heroDieSound;
    public AudioClip heroAttackSound;
    public AudioClip heroMoveSound;

    [Space] 
    [Header("Enemy Sounds")] 
    public AudioClip enemyJump;
    public AudioClip musicSource;

    [Space] 
    public AudioSource BGSpeaker;
    public AudioSource UISpeaker;
    public AudioSource heroSpeaker;
    public AudioSource enemySpeaker;
    
    public void SetFXVolume(Slider volumeFX)
    {
        enemySpeaker.volume = volumeFX.value;
        heroSpeaker.volume = volumeFX.value;
    }

    public void SetBGVolume( Slider volumeBG)
    {
        BGSpeaker.volume = volumeBG.value;
    }

    public void PlayBGSound()
    {
        BGSpeaker.clip = backgroundMusic;
        BGSpeaker.Play();
    }

    public void HeroPlay(AudioClip clip)
    {
        heroSpeaker.PlayOneShot(clip);
    }
   
}