using System.Collections;
using System.Collections.Generic;
using _Main_Work.Dam.Data;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public BGSound backgroundMusic;
    public AudioClip introSound;

    public AudioClip UISound;
    // public float volumeFX = 0.7f;
    // public float volumeBG = 0.7f;


    [Header("Hero Sounds")] public AudioClip heroJumpSound;
    public AudioClip heroDieSound;
    public AudioClip heroAttackSound;
    public AudioClip heroMoveSound;

    [Space] [Header("Enemy Sounds")] public AudioClip enemyJump;
    public AudioClip musicSource;

    [Space] public AudioSource BGSpeaker;
    public AudioSource UISpeaker;
    public AudioSource heroSpeaker;
    public AudioSource enemySpeaker;

    public void SetFXVolume(Slider volumeFX)
    {
        enemySpeaker.volume = volumeFX.value;
        heroSpeaker.volume = volumeFX.value;
    }

    public void SetBGVolume(Slider volumeBG)
    {
        BGSpeaker.volume = volumeBG.value;
    }


    AudioClip GetBGSound(int temp)
    {
        AudioClip audioClip;
        switch (temp)
        {
            case 1:
                audioClip = backgroundMusic.level1;
                break;
            case 2:
                audioClip = backgroundMusic.level2;
                break;
            case 3:
                audioClip = backgroundMusic.level3;
                break;
            case 4:
                audioClip = backgroundMusic.level4;
                break;
            case 5:
                audioClip = backgroundMusic.level5;
                break;
            default:
                audioClip = backgroundMusic.level1;
                break;
        }

        return audioClip;
    }

    public void PlayBGSound(int clip)
    {
        BGSpeaker.clip = GetBGSound(clip);
        BGSpeaker.Play();
    }

    public void HeroPlay(AudioClip clip)
    {
        heroSpeaker.PlayOneShot(clip);
    }
}