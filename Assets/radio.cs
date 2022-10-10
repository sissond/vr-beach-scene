using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class radio : MonoBehaviour
{
    [SerializeField] public AudioSource radioAudioSource;
    [SerializeField] Slider volumeSlider;
    public bool isPlaying = false;
    [SerializeField] public List<AudioClip> audioClips;
    public AudioClip currentClip;
    public int currentTrackListPos = 0;
    public int maxClipsListPos;

    // Start is called before the first frame update
    void Start()
    {
        currentClip = audioClips[currentTrackListPos];
        radioAudioSource.clip = currentClip;
        currentTrackListPos = 0;
        maxClipsListPos = audioClips.Count -1;
        Debug.Log(audioClips.Count);
    }

    public void ChangeVolume()
    {
        radioAudioSource.volume = volumeSlider.value;
    }

    public void TogglePlay()
    {
        if (isPlaying == false)
        {
            radioAudioSource.Play();
            isPlaying = true;
        }
        else
        {
            radioAudioSource.Stop();
            isPlaying = false;
        }
    }

    public void NextTrack()
    {
        if (currentTrackListPos < maxClipsListPos)
        {
            radioAudioSource.Stop();
            currentTrackListPos += 1;
            currentClip = audioClips[currentTrackListPos];
            radioAudioSource.clip = currentClip;
            radioAudioSource.Play();
        }
        else
        {
            radioAudioSource.Stop();
            currentTrackListPos = 0;
            currentClip = audioClips[currentTrackListPos];
            radioAudioSource.clip = currentClip;
            radioAudioSource.Play();
        }
    }

    //previous track
    public void PrevTrack()
    {
        if (currentTrackListPos > 0)
        {
            radioAudioSource.Stop();
            currentTrackListPos -= 1;
            currentClip = audioClips[currentTrackListPos];
            radioAudioSource.clip = currentClip;
            radioAudioSource.Play();
        }
        else
        {
            radioAudioSource.Stop();
            currentTrackListPos = maxClipsListPos;
            currentClip = audioClips[currentTrackListPos];
            radioAudioSource.clip = currentClip;
            radioAudioSource.Play();
        }
    }

}
