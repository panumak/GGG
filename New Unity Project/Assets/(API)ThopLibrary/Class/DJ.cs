using UnityEngine;
using System.Collections;
using System;
using MasterDJ;

namespace MasterDJ
{
    public class ControlVoulme : MonoBehaviour
    {
        public bool allMute = false;
        [Range(0.0f, 1.0f)]
        public float mastersV = 0.5f;
        public bool muteBGsound = false;
        [Range(0.0f, 1.0f)]
        public float BGsound = 0.5f;
        public bool muteTalk =false;
        [Range(0.0f, 1.0f)]
        public float talk = 0.5f;
        public bool muteButton =false;
        [Range(0.0f, 1.0f)]
        public float button = 0.5f;
        public bool muteEffect = false;
        [Range(0.0f, 1.0f)]
        public float effect = 0.5f;
        
        public void UpdateDJ()
        {
            if (DJ.isInstan())
            {
                DJ.audiosourec[0].volume = countV(BGsound);               
                DJ.audiosourec[1].volume = countV(talk);                
                DJ.audiosourec[2].volume = countV(button);              
                DJ.volumeEffect = countV(effect);
                if (!allMute)
                {
                    DJ.audiosourec[0].mute = muteBGsound;
                    DJ.audiosourec[1].mute = muteTalk;
                    DJ.audiosourec[2].mute = muteButton;
                    DJ.muteEffect = muteEffect;
                }
                else
                {
                    DJ.audiosourec[0].mute = allMute;
                    DJ.audiosourec[1].mute = allMute;
                    DJ.audiosourec[2].mute = allMute;
                    DJ.muteEffect = allMute;
                }
            }
        }
        float countV(float income)
        {
            float value = (mastersV / 2)*(income/2);
            return value;
        }
    }
  
}

[System.Serializable]
public class DJ : MonoBehaviour
{
    Transform background;
    Transform talk;
    Transform button;
    private static GameObject effect;   
    static poolingAudioSource audioPooling;

    public static AudioSource[] audiosourec = new AudioSource[3];
    public static float volumeEffect = 0.5f;
    public static bool muteEffect = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (background == null)
        {
            background = gameObject.transform.FindChild("BackgroundMuisc");
            audiosourec[0] = background.GetComponent<AudioSource>();
        }
        if (talk == null)
        {
            talk = gameObject.transform.FindChild("Talk");
            audiosourec[1] = talk.GetComponent<AudioSource>();
        }
        if (button == null)
        {
            button = gameObject.transform.FindChild("Button");
            audiosourec[2] = button.GetComponent<AudioSource>();
        }
        if (effect == null)
        {
            effect = gameObject.transform.FindChild("Effect").gameObject;
            audioPooling = effect.GetComponent<poolingAudioSource>();
            if(!audioPooling.GetComponent<AudioSource>())
            audioPooling.setPooling();

        }


    }
    private static DJ instan;   
    private AudioClip clip;
    private Action onFinish = null;
    private static void Fin(int type,AudioClip clip, Action onFinish = null,float timeIsPlay = 0f)
    {
        if (type == 0)
            DJ.PlayAudioBackground(clip, onFinish);
        else if (type == 1)
            DJ.PlayAudioTalk(clip, onFinish);
        else if (type == 2)
            DJ.PlayAudioButton(clip, onFinish);
        else if (type == 3)
            DJ.PlayAudioEffect(clip,timeIsPlay, onFinish);
    }

    public static void Instan(int type, AudioClip clip = null, Action onFinish = null,float timeIsPlay = 0f)
    {
        GameObject tmp = GameObject.Find("DJ");
        if (tmp == null)
            tmp = GameObject.Find("DJ(Clone)");
        if (tmp != null)
            instan = tmp.GetComponent<DJ>();

        if (instan == null)
        {
            if (GameObject.Find("DJ"))
                instan = GameObject.Find("DJ").GetComponent<DJ>();
            else
            {
                GameObject inst = Instantiate(Resources.Load("System/DJ", typeof(GameObject))) as GameObject;
                instan = inst.GetComponent<DJ>();
            }
        }
        Fin(type, clip, onFinish);
    }
    public static bool isInstan()
    {
        return instan;
    }

    public static void PlayAudioBackground(AudioClip clip, Action onFinish = null)
    {
        if (instan != null)
        {
            audiosourec[0].clip = clip;            
            audiosourec[0].Play();
            StaticCoroutine.instance.StartCoroutine(chackIsPlay(audiosourec[0], onFinish));
        }
        else
            Instan(0,clip, onFinish);
        
    }   
    public static void PlayAudioTalk(AudioClip clip, Action onFinish = null)
    {
        if (instan != null)
        {
            audiosourec[1].clip = clip;
            audiosourec[1].Play();
            StaticCoroutine.instance.StartCoroutine(chackIsPlay(audiosourec[1], onFinish));
        }
        else
            Instan(1, clip, onFinish);
    }
    public static void PlayAudioButton(AudioClip clip, Action onFinish = null)
    {
        if (instan != null)
        {
            audiosourec[2].clip = clip;
            audiosourec[2].Play();
            StaticCoroutine.instance.StartCoroutine(chackIsPlay(audiosourec[2], onFinish));
        }
        else
            Instan(2, clip, onFinish);
    }
    public static void PlayAudioEffect(AudioClip clip,float timeIsPlay = 0f, Action onFinish = null)
    {
        if (instan != null)
        {
            
                AudioSource tmp = audioPooling.getPool();
                tmp.volume = volumeEffect;
                tmp.clip = clip;
                tmp.mute = muteEffect;
                tmp.Play();

            if (timeIsPlay == 0f)
                StaticCoroutine.instance.StartCoroutine(chackIsPlay(tmp, onFinish));
            else
                StaticCoroutine.instance.StartCoroutine(timeIsPlays(tmp,timeIsPlay,onFinish));

        }
        else
            Instan(3, clip, onFinish, timeIsPlay);
    }   
 
    static IEnumerator chackIsPlay(AudioSource source, Action onFinish)
    {
        if (onFinish != null)
        {
            while (source.isPlaying)
            {
                yield return null;
            }
            onFinish();
        }
    }
    static IEnumerator timeIsPlays(AudioSource source, float timeIs,Action onFinsih)
    {
        yield return new WaitForSeconds(timeIs);
        source.Stop();
        if (onFinsih != null)
            onFinsih();
    }





}


