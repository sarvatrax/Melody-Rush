using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioClip[] backgroundSongs;
    public AudioSource musicSource;

    void Awake()
    {
        backgroundSongs = Resources.LoadAll<AudioClip>("Songs");

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
    }

    void Start()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }
    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }

    public void StopSound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Stop();
        }
    }
    public void PlayRandomSong()
    {
        if (backgroundSongs.Length == 0) return;

        int randomIndex = Random.Range(0, backgroundSongs.Length);
        musicSource.clip = backgroundSongs[randomIndex];
        musicSource.Play();
    }

    public void StopSong()
    {
        musicSource.Stop();
    }
}
