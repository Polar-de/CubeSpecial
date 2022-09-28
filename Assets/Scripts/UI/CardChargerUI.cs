using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardChargerUI : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private GameData _gameData;

    [Header("UiPanels")] 
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject waitingUI;
    [SerializeField] private GameObject balanceUI;
    [SerializeField] private GameObject successUI;
    [SerializeField] private Vector3 cashPos;

    [Header("TPM")] 
    [SerializeField] private TextMeshProUGUI currentBalance;
    [SerializeField] private TextMeshProUGUI chargeAmount;
    [SerializeField] private TextMeshProUGUI newBalance;

    [Header("Button")] 
    [SerializeField] private Button acceptBtn;
    [SerializeField] private Button closeBtn;
    private bool _btnListenerActive;

    private RaycastHit _smartCard;
    private Vector3 _smartCardPos;
    private Vector3 _smartCardPosNew;

    [Header("Cash")] 
    [SerializeField] private GameObject cash1;
    [SerializeField] private GameObject cash2;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    void Update()
    {
        if (cam.enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                    HandleHit(hit);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Charge();
        }
        
        HandleBalance();
    }

    private void ShowCash()
    {
        switch (_gameData.Cash)
        {
            case 20:
                cash1.SetActive(true);
                cash2.SetActive(true);
                break;
            case 10:
                cash1.SetActive(true);
                cash2.SetActive(false);
                break;
            case 0:
                cash1.SetActive(false);
                cash2.SetActive(false);
                break;
        }
    }

    private void HideCash()
    {
        cash1.SetActive(false);
        cash2.SetActive(false);
    }
    
    private void HandleHit(RaycastHit hit)
    {
        if (hit.transform.name == "SmartCard")
        {
            _smartCard = hit;
            _smartCardPos = hit.transform.localPosition;
            _smartCardPosNew = new Vector3(_smartCardPos.x - 1f, _smartCardPos.y, _smartCardPos.z);
            
            mainUI.SetActive(false);
            waitingUI.SetActive(true);
            StartCoroutine(Animation(hit, _smartCardPos, _smartCardPosNew));
            StartCoroutine(ChangeUI(waitingUI, balanceUI, 1.5f));
            StartCoroutine(AddListener(2f));
            
            ShowCash();
        }

        if (hit.transform.name == "geldschein" && balanceUI.activeSelf)
        {
            closeBtn.onClick.RemoveListener(GiveCardBack);
            var pos = hit.transform.localPosition;
            StartCoroutine(Animation(hit, pos, cashPos));
            if (_gameData.Cash > 0)
            {
                _gameData.ChargeAmount += 10f;
                _gameData.Cash -= 10;
            }
        }
    }

    private void HandleBalance()
    {
        _gameData.NewBalance = _gameData.MoneyOnCard + _gameData.ChargeAmount;
        if (balanceUI.activeSelf)
        {
            currentBalance.SetText($"{_gameData.MoneyOnCard},00€");
            chargeAmount.SetText($"{_gameData.ChargeAmount},00€");
            newBalance.SetText($"{_gameData.NewBalance},00€");
        }
    }

    private void Charge()
    {
        HideCash();
        acceptBtn.onClick.RemoveListener(Charge);
        _gameData.Cash -= _gameData.ChargeAmount;
        _gameData.MoneyOnCard = _gameData.NewBalance;
        _gameData.NewBalance = 0f;
        _gameData.ChargeAmount = 0f;
        StartCoroutine(Animation(_smartCard, _smartCardPosNew, _smartCardPos));
        StartCoroutine(ChangeUI(balanceUI, successUI, 0.2f));
        StartCoroutine(ChangeUI(successUI, mainUI, 1f));
        _gameData.questID = 1;
    }

    private void GiveCardBack()
    {
        HideCash();
        closeBtn.onClick.RemoveListener(GiveCardBack);
        StartCoroutine(Animation(_smartCard, _smartCardPosNew, _smartCardPos));
        StartCoroutine(ChangeUI(balanceUI, mainUI, 0.2f));
    }

    private IEnumerator ChangeUI(GameObject closeUI, GameObject openUI, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        closeUI.SetActive(false);
        openUI.SetActive(true);
    }

    private IEnumerator AddListener(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        acceptBtn.onClick.AddListener(Charge);
        closeBtn.onClick.AddListener(GiveCardBack);
    }

    private IEnumerator Animation(RaycastHit hit, Vector3 from, Vector3 to)
    {
        float timeElapsed = 0f;
        var duration = 1.5f;
        while (duration > timeElapsed)
        {
            float t = timeElapsed / duration;
            hit.transform.localPosition = Vector3.Lerp(from, to, t);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
