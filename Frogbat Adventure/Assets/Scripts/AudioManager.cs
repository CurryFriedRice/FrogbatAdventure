using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioType Type = AudioType.OneShot;
    //public List<AudioClip> AudioSources;
    private AudioSource Emitter;
    D_Settings Settings;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(Type == AudioType.Looping)
        {
            Emitter.loop = true;
            if (!Emitter.isPlaying) Emitter.Play();
        }
    }

    public void PlayEffect(AudioClip audio)
    {
        if (Settings == null) Settings = FindObjectOfType<D_Settings>();
        if (Settings != null)
        {
            if (Emitter == null) Emitter = GetComponent<AudioSource>();
            if (Emitter != null)
                switch (Type)
                {
                    case AudioType.OneShot: //Will Be used mostly to tie Audio with Animations 
                                            //Up to 12 Oneshots per Emitter
                        Emitter.loop = false;
                        Emitter.PlayOneShot(audio, Settings.Audio.Master * Settings.Audio.Effects);
                        break;
                    case AudioType.Looping: //If it's Looping then it'll set it to loop and play it
                        Emitter.loop = true;
                        if (!Emitter.isPlaying) Emitter.Play();
                        break;
                    default:
                        break;
                }
            else
            {
                Debug.LogWarning(name + " | This Audio Manager Has no Emitter");
            }
        }
        else Debug.LogWarning("There is no Audio Settings attached to this area");
    }
}
