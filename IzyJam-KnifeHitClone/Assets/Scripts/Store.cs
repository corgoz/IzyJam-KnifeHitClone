using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private Image[] _skinBtn;

    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _disabledColor;
    [SerializeField] private Button _unlockSkin;

    private GameManager _gameManager;

    public void _Init_(bool[] p_skins, KnifeSkin[] p_knifeSkins)
    {
        _gameManager = GameManager.Singleton;

        for (int i = 0; i < p_skins.Length; i++)
            if (p_skins[i])
                UnlockSkin(i, p_knifeSkins[i].icon);    

        SelectSkin(_gameManager.CurrentSkin);

        EnableUlockSkinBtn();
    }

    public void EnableUlockSkinBtn()
    {
        if (_gameManager.Coins < _gameManager.SkinCost || !_gameManager.HasSkinsToUnlock)
            _unlockSkin.interactable = false;
        else
            _unlockSkin.interactable = true;
    }

    public void SelectSkin(int p_index)
    {
        _skinBtn[_gameManager.CurrentSkin].color = _disabledColor;
        _skinBtn[p_index].color = _selectedColor;
        _gameManager.CurrentSkin = p_index;
    }

    public void UnlockSkin(int p_index, Sprite p_icon)
    {
        _skinBtn[p_index].GetComponent<Button>().interactable = true;
        _skinBtn[p_index].transform.GetChild(0).GetComponent<Image>().sprite = p_icon;
    }

    public void UnlockRandomSkin()
    {
        KnifeSkin skin = _gameManager.GetRandomUnlockedSkin();

        if(skin == null)
        {
            _unlockSkin.interactable = false;
            return;
        }

        SelectSkin(skin.index);
        _skinBtn[skin.index].GetComponent<Button>().interactable = true;
        _skinBtn[skin.index].transform.GetChild(0).GetComponent<Image>().sprite = skin.icon;

        EnableUlockSkinBtn();
    }
}