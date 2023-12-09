public class PlayerSkinchanger : Skinchanger
{
    public override void ChangeSkin(Skin skin)
    {
        Destroy(Player.Instance.GetComponentInChildren<Skin>().gameObject);
        Instantiate(skin, Player.Instance.transform);
    }
}