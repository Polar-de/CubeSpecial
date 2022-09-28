using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject tabletFull;
    [SerializeField] private GameObject tabletEmpty;
    [SerializeField] private Image darken;

    private Color _color1 = new Color(0, 0, 0, 0);
    private Color _color2 = new Color(0, 0, 0, 1);

    public string InteractionPrompt => interactionPrompt;
    public bool Interact(PlayerInteraction playerInteraction)
    {
        if (tabletFull.activeSelf)
        {
            StartCoroutine(Darken(_color1, _color2, 1f));
            tabletFull.SetActive(false);
            tabletEmpty.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Darken(Color a, Color b, float duration)
    {
        float timeElapsed = 0f;
        while (duration > timeElapsed)
        {
            float t = timeElapsed / duration;
            darken.material.color = Color.Lerp(a, b, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(duration);
        
        timeElapsed = 0f;
        while (duration > timeElapsed)
        {
            float t = timeElapsed / duration;
            darken.material.color = Color.Lerp(b, a, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
