using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinShopUI : MonoBehaviour
{
    public Button NextSkinBtn;
    public Button PervSkinBtn;
    public Button BuyBtn;
    [SerializeField] private TextMeshProUGUI _nameTMP;
    [SerializeField] private TextMeshProUGUI _priceTMP;

    private void OnEnable()
    {
        Actions.OnSkinBought += SetButtonText;
    }

    private void OnDisable()
    {
        Actions.OnSkinBought -= SetButtonText;
    }

    public void ShowSkinInfo(Skin skin)
    {
        _nameTMP.text = skin.Name;
        _priceTMP.text = skin.Price.ToString();
        SetButtonText(skin);
    }

    private void SetButtonText(Skin skin)
    {
        if (skin.IsBought)
            BuyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Использовать";
        else
            BuyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Купить";
    }
}