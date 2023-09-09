using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpriteButtonSwitch : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _startSprite;
    [SerializeField] private Sprite _stopSprite;

    private bool _isStart = true;
    
    private void Awake() => 
        _button.onClick.AddListener(Switch);

    private void OnDestroy() => 
        _button.onClick.RemoveListener(Switch);

    private void Switch()
    {
        _isStart = !_isStart;
        _buttonImage.sprite = _isStart ? _startSprite : _stopSprite;
    }
}
