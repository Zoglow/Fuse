using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    // Start is called before the first frame update
    void Start() {
        foreach (Sound s in sounds) {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.loop = s.loop;
            s.audioSource.volume = s.volume;

        }
    }

    //// Update is called once per frame
    //void Update() {
        
    //}

    public void playSound(string name) {

        foreach (Sound s in sounds) {
            if (s.name == name) s.audioSource.Play();
        }
    }

    public void stopSound(string name) {

        foreach (Sound s in sounds) {
            if (s.name == name) s.audioSource.Stop();
        }
    }
}
