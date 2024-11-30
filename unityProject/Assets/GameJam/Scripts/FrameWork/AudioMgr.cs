using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
public class AudioMgr : SingletonMonoCG<AudioMgr>
{
    public Transform player;
    public Vector3 targetPos;
    public Vector3 dir;
    public const string path = "Audio"; // 修改为相对路径，不需要 Assets/Resources
    private Dictionary<string, AudioClip> sourceManagerDic = new Dictionary<string, AudioClip>();
    bool isPlaying = false;//确保每一次只播放一段音频
    AudioSource audioSource = null;
    Animator animator;
    public List<AudioClip> audioSources = new List<AudioClip>();
    private void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();
        player = GameObject.Find("Player").transform;
        LoadAllAudioClips();
    }

    private void LoadAllAudioClips()
    {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>(path);
        foreach (var clip in audioClips)
        {
            if (!sourceManagerDic.ContainsKey(clip.name))
            {
                sourceManagerDic.Add(clip.name, clip);
                audioSources.Add(clip);
            }
        }
    }

    private AudioClip GetAudioClip(string Clipname)
    {
        if (!sourceManagerDic.ContainsKey(Clipname))
        {
            // 如果没有，就返回 null
            Debug.LogWarning($"音频动画没有找到 '{Clipname}'");
            return null;
        }
        return sourceManagerDic[Clipname];
    }

    public void PlayAudioSource(string Clipname)
    {
        if (isPlaying) return;
        AudioClip clip = GetAudioClip(Clipname);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            isPlaying = true;
            StartCoroutine(WaitForSecondToEnd());
        }
    }
    public void stopVoice()
    {
        audioSource.Stop();
    }
    private IEnumerator WaitForSecondToEnd()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        isPlaying = false;
    }
    IEnumerator StopPose(AudioSource audioSource, float timer)
    {
        Debug.Log("这个是不是执行力两次");
        yield return new WaitForSeconds(timer);
        audioSource.Stop();
    }
}
