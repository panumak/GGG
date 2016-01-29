using UnityEngine;
using System.Collections.Generic;

public class poolingAudioSource : MonoBehaviour
{
    private List<AudioSource> componemtS = new List<AudioSource>();
    private int count;
    private GameObject main;

    public float volume = 0.5f;

    public void setPooling(int count = 3)
    {
        this.count = count;
        main = this.gameObject;
        for (int i = 0; i < count; i++)
        {
            AudioSource tmp = main.AddComponent<AudioSource>();
            componemtS.Add(tmp);
        }
    }
    public AudioSource getPool()
    {
        for (int i = 0; i < componemtS.Count; i++)
            if (!componemtS[i].isPlaying)
            {
                componemtS[i].volume = volume;
                return componemtS[i];
            }

        AudioSource tmp = main.AddComponent<AudioSource>();
        tmp.volume = volume;
        componemtS.Add(tmp);
        count++;
        return tmp;

    }

}
