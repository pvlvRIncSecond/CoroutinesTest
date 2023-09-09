using CodeBase.Indicators;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.CoroutinesStuff
{
    public class CoroutineIndicator
    {
        public CoroutineState State
        {
            get { return _state; }
            set
            {
                _state = value;
                ChangeImage(value);
            }
        }


        public Coroutine Coroutine;
        public float WaitTime;
        public float CurrentTime;

        private readonly SpriteConfig _config;
        private CoroutineState _state;
        private Image _image;

        public CoroutineIndicator(Image indicatorImage, SpriteConfig config)
        {
            _config = config;
            _image = indicatorImage;
        
            State = CoroutineState.Stoped;
        }

        private void ChangeImage(CoroutineState value)
        {
            switch (value)
            {
                case CoroutineState.Active:
                    _image.sprite = _config.Active;
                    break;
            
                case CoroutineState.Paused:
                    _image.sprite = _config.Paused;
                    break;
            
                case CoroutineState.Stoped:
                    _image.sprite = _config.Stoped;
                    break;
            }
        }
    }
}