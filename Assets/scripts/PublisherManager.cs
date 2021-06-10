using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using KindaHot;

public class PublisherManager : MonoBehaviour
{
    private IPublisher AllObjectsPublisher = new Publisher();

    public void BulletTimeInitiator(bool isOn) {
        AllObjectsPublisher.Notify(isOn);
    }   

    public void Subscribe(Action<bool> callback) 
    {
        AllObjectsPublisher.Subscribe(callback);
    } 

    public void Unsubscribe(Action<bool> callback)
    {
        AllObjectsPublisher.Unsubscribe(callback);
    }
}
