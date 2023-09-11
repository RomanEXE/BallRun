using System;

public static class Actions
{
    public static Action OnGameEnd;
    public static Action OnCoinCollected;
    public static Action<Skin> OnSkinBought;
    public static Action OnPinDrop;
}