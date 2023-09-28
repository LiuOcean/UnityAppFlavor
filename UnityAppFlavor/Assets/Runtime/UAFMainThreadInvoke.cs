using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace UnityAppFlavor
{
    public class UAFMainThreadInvoke : MonoBehaviour
    {
        private static readonly Queue<Action> _QUEUE = new();

        private void Update()
        {
            while(_QUEUE.Count > 0)
            {
                _QUEUE.Dequeue()?.Invoke();
            }
        }

        public static void SwitchToMainThread(Action action) { _QUEUE.Enqueue(action); }
    }
}