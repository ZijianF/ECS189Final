using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace KindaHot
{
    public class Publisher : IPublisher
    {
        private List<Action<bool>> Collections = new List<Action<bool>>();

        public void Unsubscribe(Action<bool> notifier)
        {
            this.Collections.Remove(notifier);
        }

        public void Subscribe(Action<bool> notifier)
        {
            this.Collections.Add(notifier);
        }

        public void Notify(bool isOn)
        {
            foreach (var temp in this.Collections)
            {
                temp(isOn);
            }
        }
    
    }

}
