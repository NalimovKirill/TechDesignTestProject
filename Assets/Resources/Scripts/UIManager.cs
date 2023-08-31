using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private AnimationManager _clickedObject;

    private bool _isButtonaActive = false;

    private void OnEnable()
    {
        _clickedObject.Clicked.AddListener(ActivateButton);
    }
    private void OnDisable()
    {
        _clickedObject.Clicked.RemoveListener(ActivateButton);
    }

    private void ActivateButton()
    {
        if (!_isButtonaActive)
        {
            _button.SetActive(true);
            _isButtonaActive = true;
        }
        else
        {
            _button.SetActive(false);
            _isButtonaActive = false;
        }
        
    }

    public void GoToNextScene()
    {
        int currentScene;
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
