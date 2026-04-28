using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace Assets._Scripts.Manager
{
    public delegate void OnCounterChanged(int newValue, float oldValie, string text); // IMP
    public delegate int OnCounterChangedReturnInt(int number1, int number2);
    public class ObservableManager : MonoBehaviour
    {
        private static ObservableManager instance;
        public static ObservableManager Instance // lazy loading singleton pattern
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<ObservableManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("ObservableManager");
                        instance = obj.AddComponent<ObservableManager>();
                    }
                }
                return instance;
            }
        }
     
        public Action<int> OnCounterChanged;
        public Action<int, float, string, float2> OnCounterChanged1;
        Func<int, int, int> d;
        public OnCounterChanged OnCounterChanged2;
        public OnCounterChangedReturnInt OnCounterChangedReturb;
        private int counter;
        public void IncrementCounter()
        {
            counter++;
            int result = OnCounterChangedReturb(counter, counter * 2);
            OnCounterChanged?.Invoke(counter);

        }
        public void DecrementCounter()
        {
            counter--;
            OnCounterChanged?.Invoke(counter);
            //OnCounterChanged1?.Invoke();
            //OnCounterChanged2?.Invoke(,)
        }
        public int GetCounterValue()
        {
            return counter;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                IncrementCounter();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                DecrementCounter();
            }
        }
    }
}
