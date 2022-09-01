using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour
{
    private Dictionary<string, Action> keys = new Dictionary<string, Action>();
    private KeywordRecognizer _keywordRecognizer;
    
    // TESTING
    private MeshRenderer _meshRenderer;
    private bool _spinningRight;
    
    // Audio
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] sounds;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();
        AddKeywords();
        StartKeywordRecognizer();
    }

    void AddKeywords()
    {
        keys.Add("red", Red);
        keys.Add("blue", Blue);
        keys.Add("green", Green);
        
        keys.Add("spin right", SpinRight);
        keys.Add("spin left", SpinLeft);

        keys.Add("burger", Burger);
        keys.Add("nudeln", Pasta);
        
        keys.Add("bezahlen", Bezahlen);
        keys.Add("Ich würde gerne bezahlen", Bezahlen);
    }

    void StartKeywordRecognizer()
    {
        _keywordRecognizer = new KeywordRecognizer(keys.Keys.ToArray(), ConfidenceLevel.Medium);
        _keywordRecognizer.OnPhraseRecognized += KeywordRecognized;
        _keywordRecognizer.Start();
    }

    void KeywordRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command: " + args.text);
        keys[args.text].Invoke();
    }

    void Red()
    {
        _meshRenderer.material.color = Color.red;
    }
    
    void Blue()
    {
        _meshRenderer.material.color = Color.blue;
    }
    
    void Green()
    {
        _meshRenderer.material.color = Color.green;
    }

    void Burger()
    {
        Debug.Log("Hier ist dein Burger, guten Appetit!");
        _audioSource.clip = sounds[0];
        _audioSource.Play();
        
    }
    void Pasta()
    {
        Debug.Log("Hier ist deine Pasta, guten Appetit!");
        _audioSource.clip = sounds[1];
        _audioSource.Play();
    }

    void Bezahlen()
    {
        _audioSource.clip = sounds[2];
        _audioSource.Play();
    }
    
    void SpinRight()
    {
        _spinningRight = true;
        StartCoroutine(RotateObject(1f));
    }

    void SpinLeft()
    {
        _spinningRight = false;
        StartCoroutine(RotateObject(1f));
    }

    IEnumerator RotateObject(float duration)
    {
        var startRotation = transform.eulerAngles.x;
        float endRotation;

        if (_spinningRight)
        {
            endRotation = startRotation - 360f;
        }
        else
        {
            endRotation = startRotation + 360f;
        }

        var timePassed = 0f;
        float yRotation;
        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            yRotation = Mathf.Lerp(startRotation, endRotation, timePassed / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
    }
}
