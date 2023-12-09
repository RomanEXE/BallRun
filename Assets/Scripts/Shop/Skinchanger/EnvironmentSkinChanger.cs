using UnityEngine;

public class EnvironmentSkinChanger : Skinchanger
{
    [SerializeField] private GameObject _environmentPrefab;
    
    public override void ChangeSkin(Skin skin)
    {
        Instantiate(skin, _environmentPrefab.transform);
    }
}