using UnityEngine;
using YG;

public class SkinShop : MonoBehaviour
{
    [SerializeField] private int _currentSkinIndex;
    [SerializeField] private Skin[] _skins;
    [SerializeField] private SkinShopUI _shopUI;
    [SerializeField] private Transform _skinShowerPoint;

    private void OnEnable()
    {
        _shopUI.NextSkinBtn.onClick.AddListener(ShowNextSkin);
        _shopUI.PervSkinBtn.onClick.AddListener(ShowPervSkin);
        _shopUI.BuyBtn.onClick.AddListener(BuySkin);
        YandexGame.GetDataEvent += SetSkinsData;
    }
    
    private void OnDisable()
    {
        _shopUI.NextSkinBtn.onClick.RemoveListener(ShowNextSkin);
        _shopUI.PervSkinBtn.onClick.RemoveListener(ShowPervSkin);
        _shopUI.BuyBtn.onClick.RemoveListener(BuySkin);
        YandexGame.GetDataEvent -= SetSkinsData;
    }

    private void Start()
    {
        ShowSkin(_currentSkinIndex);

        if (YandexGame.SDKEnabled)
        {
            for (int i = 0; i < _skins.Length; i++)
            {
                if (_skins[i].Id == YandexGame.savesData.SelectedSkinId)
                {
                    ChangeSkin(_skins[i]);
                }
            }
        }
    }

    private void SetSkinsData()
    {
        _skins = Resources.LoadAll<Skin>("/Skins");
        
        var purchasedSkinsId = YandexGame.savesData.PurchasedSkinsId;
        
        for (int j = 0; j < _skins.Length; j++)
        {
            for (int k = 0; k < purchasedSkinsId.Count; k++)
            {
                if (_skins[j].Id == purchasedSkinsId[k])
                {
                    _skins[j].IsBought = true;
                }
            }

            if (_skins[j].Id == YandexGame.savesData.SelectedSkinId)
            {
                ChangeSkin(_skins[j]);
            }
        }  
    }

    private void ShowNextSkin()
    {
        if (_currentSkinIndex + 1 == _skins.Length) return;
        ShowSkin(++_currentSkinIndex);
    }

    private void ShowPervSkin()
    {
        if (_currentSkinIndex - 1 == -1) return;
        ShowSkin(--_currentSkinIndex);
    }

    private void ShowSkin(int index)
    {
        _currentSkinIndex = index;
        Destroy(_skinShowerPoint.GetChild(0).gameObject);
        var spawnedSkin = Instantiate(_skins[_currentSkinIndex], _skinShowerPoint);
        spawnedSkin.gameObject.layer = LayerMask.NameToLayer("UI");
        
        _shopUI.ShowSkinInfo(_skins[_currentSkinIndex]);
    }
    
    private void BuySkin()
    {
        var skin = _skins[_currentSkinIndex];

        if (skin.IsBought)
        {
            YandexGame.savesData.SelectedSkinId = skin.Id;
            ChangeSkin(skin);
            return;
        }
        if (YandexGame.savesData.Coins < skin.Price) return;
        
        skin.IsBought = true;
        YandexGame.savesData.Coins -= skin.Price;
        YandexGame.savesData.SelectedSkinId = skin.Id;
        YandexGame.savesData.PurchasedSkinsId.Add(skin.Id);
    }

    private void ChangeSkin(Skin skin)
    {
        Destroy(Player.Instance.GetComponentInChildren<Skin>().gameObject);
        Instantiate(skin, Player.Instance.transform);
    }
}