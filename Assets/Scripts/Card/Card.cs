using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Card : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private CardInfo _cardInfo;

    private Image _image;

    public event Action<Card> CardOpened;
    public CardInfo CardInfo => _cardInfo;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OpenCard()
    {
        _image.sprite = _cardInfo.Picture;
        CardOpened?.Invoke(this);
    }
    

    public void CloseCard()
    {
        _image.sprite = _cardInfo.Back;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenCard();
    }
}