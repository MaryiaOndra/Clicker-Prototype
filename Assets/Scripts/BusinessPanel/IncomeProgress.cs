using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ClickerPrototype.BusinessPanel
{
    public class IncomeProgress
    {
        public event Action IsTimeToIncome;

        private Slider _slider;
        private Coroutine _progressRoutine;
        private float _delay;
       
        public IncomeProgress(ref Slider slider, float delay)
        {
            _slider = slider;
            _delay = delay;
            _progressRoutine = _slider.StartCoroutine(ProgressRoutine(_delay, _slider));
            IsTimeToIncome += RestartRoutine;
        }

        private void RestartRoutine()
        {
            Debug.Log("IsTimeToIncome! RESTART ROUTINE");
            _progressRoutine = null;
            _progressRoutine = _slider.StartCoroutine(ProgressRoutine(_delay, _slider));
        }

        IEnumerator ProgressRoutine(float delay, Slider slider)
        {
            float timeRemaining = 0;
            while (timeRemaining < delay)
            {
                timeRemaining += Time.deltaTime;
                slider.value = timeRemaining / delay;
                //slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, Time.deltaTime * delay);
                yield return new WaitForEndOfFrame();
            }
            IsTimeToIncome?.Invoke();
        }
    }
}