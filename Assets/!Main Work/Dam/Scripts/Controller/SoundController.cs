using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip UISound;
    public float volumeFX = 0.5f;
    public float volumeBG = 0.5f;


  

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
    
    public void SetFXVolume()
    {
        enemySpeaker.volume = volumeFX;
        heroSpeaker.volume = volumeFX;
    }

    public void SetBGVolume()
    {
        BGSpeaker.volume = volumeBG;
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