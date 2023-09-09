using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Indicators;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

namespace CodeBase.CoroutinesStuff
{
    public class CoroutineHandler : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private IndicatorsImageHolder _indicatorsImageHolder;
        [SerializeField] private SpriteConfig _config;

        private List<CoroutineIndicator> _coroutines = new List<CoroutineIndicator>();

        private event Action<int> OnIndicatorPaused;
        private Random _random = new Random();
        private bool _isStart = false;
        private int _currentCoroutineIndex;


        private void Awake()
        {
            foreach (Image indicator in _indicatorsImageHolder.Indicators)
                _coroutines.Add(new CoroutineIndicator(indicator, _config));
        }

        private void Start() =>
            _button.onClick.AddListener(StartStop);

        private void OnDestroy() =>
            _button.onClick.RemoveListener(StartStop);

        private void StartStop()
        {
            _isStart = !_isStart;
            if (_isStart)
            {
                StartNew();
                OnIndicatorPaused += StartNext;
            }
            else
            {
                StopAll();
                OnIndicatorPaused -= StartNext;
            }
        }

        private void StartNew()
        {
            _currentCoroutineIndex = _random.Next(0, _indicatorsImageHolder.Indicators.Count);
            _coroutines[_currentCoroutineIndex].Coroutine = StartCoroutine(WaitRandom(_currentCoroutineIndex));
        }

        private void StopAll()
        {
            foreach (CoroutineIndicator coroutine in _coroutines)
            {
                coroutine.State = CoroutineState.Stoped;
                if (coroutine.Coroutine != null)
                    StopCoroutine(coroutine.Coroutine);
            }
        }

        private IEnumerator WaitRandom(int index)
        {
            _coroutines[index].State = CoroutineState.Active;

            _coroutines[index].WaitTime = _random.Next(10, 21);
            _coroutines[index].CurrentTime = 0f;

            while (_coroutines[index].CurrentTime < _coroutines[index].WaitTime)
            {
                _coroutines[index].CurrentTime += Time.deltaTime;
                yield return null;
            }

            _coroutines[index].State = CoroutineState.Paused;
            OnIndicatorPaused?.Invoke(index);
        }

        private void StartNext(int prevIndex)
        {
            StopCoroutine(_coroutines[_currentCoroutineIndex].Coroutine);
            
            _currentCoroutineIndex = ++prevIndex % _indicatorsImageHolder.Indicators.Count;
            _coroutines[_currentCoroutineIndex].Coroutine = StartCoroutine(WaitRandom(_currentCoroutineIndex));
        }
    }
}