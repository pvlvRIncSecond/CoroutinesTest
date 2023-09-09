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

        public float CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                ChangeText(value);
            }
        }

        public Coroutine Coroutine;
        public float WaitTime;

        private readonly SpriteConfig _config;

        private Indicator _indicator;
        private CoroutineState _state;
        private float _currentTime;

        public CoroutineIndicator(Indicator indicator, SpriteConfig config)
        {
            _config = config;
            _indicator = indicator;

            State = CoroutineState.Stoped;
        }

        private void ChangeImage(CoroutineState value)
        {
            switch (value)
            {
                case CoroutineState.Active:
                    _indicator.Image.sprite = _config.Active;
                    _indicator.TmpText.enabled = true;
                    break;

                case CoroutineState.Paused:
                    _indicator.Image.sprite = _config.Paused;
                    _indicator.TmpText.enabled = false;
                    break;

                case CoroutineState.Stoped:
                    _indicator.Image.sprite = _config.Stoped;
                    _indicator.TmpText.enabled = false;
                    break;
            }
        }

        private void ChangeText(float value) => 
            _indicator.TmpText.text = $"{(int)value}/{WaitTime}";
    }
}