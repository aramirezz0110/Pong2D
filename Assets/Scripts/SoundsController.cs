using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundsController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip raquetHitAudioClip;
    public AudioClip wallHitAudioClip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == GameTags.Player)
        {
            audioSource.clip = raquetHitAudioClip;
            audioSource.Play();
        }
        if(collision.gameObject.tag == GameTags.LeftWall || collision.gameObject.tag == GameTags.RightWall)
        {
            audioSource.clip = wallHitAudioClip;
            audioSource.Play();
        }
    }
}
