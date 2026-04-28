using Assets._Scripts.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets._Scripts.Observable
{
    public class UITextIncrement : MonoBehaviour
    {
        public TextMeshProUGUI counterTxt;

        private void OnEnable()
        {
            counterTxt.SetText(0.ToString());
            ObservableManager.Instance.OnCounterChanged += UpdateCounterText;
            ObservableManager.Instance.OnCounterChangedReturb += HowToCalculate;
        }

        private int HowToCalculate(int number1, int number2)
        {
            return number1 + number2;
        }

        private void UpdateCounterText(int newValue)
        {
            Debug.Log("Counter value updated: " + newValue);
            counterTxt.SetText(newValue.ToString());    
        }

        public void OnDisable()
        {
            ObservableManager.Instance.OnCounterChanged -= UpdateCounterText;
        }
    }
}
