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

    public void ShowSkinInfo(Skin skin)
    {
        _nameTMP.text = skin.Name;
        _priceTMP.text = skin.Price.ToString();

        if (skin.IsBought)
            BuyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Использовать";
        else
            BuyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Купить";
    }
}