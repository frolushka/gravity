using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Vector2 pitch;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var go = new GameObject();
        var audioSource = go.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = audioClip;
        audioSource.pitch = Random.Range(pitch.x, pitch.y);
        audioSource.Play();
        Destroy(go, .7f);
    }
}
