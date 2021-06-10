using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KindaHot
{
    public interface IPublisher
    {
        void Subscribe(Action<bool> notifier);

        void Notify(bool bulletTime);

        void Unsubscribe(Action<bool> state);
    }
}