using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationSystem : MonoBehaviour
{
    public static NotificationSystem Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            _instance = FindObjectOfType<NotificationSystem>();
            if (_instance != null)
                return _instance;
            _instance = Instantiate(Resources.Load<NotificationSystem>("NotificationSystem"));
            return _instance;
        }
    }
    
    private static NotificationSystem _instance;

    private void Awake()
    {
        if (Instance != this)
            Destroy(gameObject);
    }

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject panel;
    [SerializeField] private float fadeInDuration;
    [SerializeField] private float notificationDuration;
    [SerializeField] private float fadeOutDuration;

    private IEnumerator _notification;
    
    public void Notification(string message)
    {
        if (_notification != null) 
            StopCoroutine(_notification);
        _notification = Fade(message);
        StartCoroutine(_notification);
    }

    private IEnumerator Fade(string message)
    {
        var alpha = GetComponent<CanvasGroup>();
        text.text = message;
        var t = 0f;

        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            alpha.alpha = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            panel.transform.localScale =
                (new Vector3(Mathf.Lerp(0f, 1f, t / fadeInDuration), Mathf.Lerp(0f, 1f, t / fadeInDuration), 1f));
            yield return null;
        }

        yield return new WaitForSecondsRealtime(notificationDuration);

        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            alpha.alpha = Mathf.Lerp(1f, 0f, t / fadeOutDuration);
            panel.transform.localScale =
                (new Vector3(Mathf.Lerp(1f, 0f, t / fadeOutDuration), Mathf.Lerp(1f, 0f, t / fadeOutDuration), 1f));
            yield return null;
        }
    }
}
