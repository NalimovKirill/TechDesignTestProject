using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class AnimationManager : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private bool _isPlayingAnim = false;

    [HideInInspector]
    public UnityEvent Clicked = new UnityEvent();

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (_animator == null)
            return;

        if (!_isPlayingAnim)
        {
            if (_animator.parameterCount > 0)
            {
                _animator.SetBool("Clicked", true);
                _isPlayingAnim = true;
            }
            
        }
        else
        {
            _animator.SetBool("Clicked", false);
            _isPlayingAnim = false;
        }

        if (TryGetComponent<AudioSource>(out _audioSource))
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
            else
            {
                _audioSource.Play();
            }
        }

        if (transform.tag == "ActivateUI")
        {
            Clicked?.Invoke();
        }
        
    }
}
