using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class TextSwitchOnClick : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _tmpText;
        [SerializeField] private Button _button;
        [SerializeField] private string _firstText;
        [SerializeField] private string _secondText;
    
        private bool _isFirst = true;
    
        private void Awake() => 
            _button.onClick.AddListener(Switch);

        private void OnDestroy() => 
            _button.onClick.RemoveListener(Switch);

        private void Switch()
        {
            _isFirst = !_isFirst;
            _tmpText.text = _isFirst ? _firstText : _secondText;
        }
    }
}
