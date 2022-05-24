using System.Collections.Generic;
using UnityEngine;

public class GoatMusicPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> goatSoundList = new();
    [SerializeField] private AudioSource audioPlayer;

    private int PickGoatSound()
    {
        return Random.Range(0, goatSoundList.Count);
    }

    public void PlayGoatSound()
    {
        var num = PickGoatSound();
        audioPlayer.clip = goatSoundList[num];
        audioPlayer.Play();
    }
}