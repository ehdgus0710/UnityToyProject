using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingSystem : Sington<MessagingSystem>
{

    public delegate bool MessageHandlerDelegate(BaseMessage message);

    private SerializableDictionary<string, List<MessageHandlerDelegate>> listenerDict = new SerializableDictionary<string, List<MessageHandlerDelegate>>();
    private Queue<BaseMessage> messageQueue = new Queue<BaseMessage>();

    private float maxQueueProcessingTime = 0.16667f;

    private void Update()
    {
        float timer = 0f;

        while (messageQueue.Count > 0)
        {
            if(maxQueueProcessingTime > 0.0f)
            {
                if (timer > maxQueueProcessingTime)
                    return;
            }

            BaseMessage msg = messageQueue.Dequeue();

            if (!TriggerMessage(msg))
                Debug.Log("Error when Processing message : " + msg.name);

            if (maxQueueProcessingTime > 0.0f)
                timer += Time.deltaTime;
        }

    }

    //private void OnDestroy()
    //{
    //    if(!ReferenceEquals(MessagingSystem.Instance,null))
    //        MessagingSystem.Instance.DetachListener(typeof(MyCustomMessage), this.HandleMyCustomMessage);
    //}


    public bool AttachListener(System.Type type, MessageHandlerDelegate handler)
    {
        if(type == null)
        {
            Debug.Log("MessagingSystem: AttachListener failed due to no message type specified");
            return false;
        }

        string msgName = type.Name;

        if(!listenerDict.ContainsKey(msgName))
            listenerDict.Add(msgName, new List<MessageHandlerDelegate>());

        List<MessageHandlerDelegate> listenerList = listenerDict[msgName];

        if (listenerList.Contains(handler))
            return false;

        listenerList.Add(handler);

        return true;
    }

    public bool DetachListener(System.Type type, MessageHandlerDelegate handler)
    {
        if (type == null)
        {
            Debug.Log("MessagingSystem: DetachListener failed due to no message type specified");
            return false;
        }

        string msgName = type.Name;

        if (!listenerDict.ContainsKey(msgName))
            return false;

        List<MessageHandlerDelegate> listenerList = listenerDict[msgName];

        if (!listenerList.Contains(handler))
            return false;

        listenerList.Remove(handler);

        return true;
    }

    public bool QueueMessage(BaseMessage msg)
    {
        if (!listenerDict.ContainsKey(msg.name))
            return false;

        messageQueue.Enqueue(msg);
        return true;
    }

    public bool TriggerMessage(BaseMessage msg)
    {
        string msgName = msg.name;

        if (!listenerDict.ContainsKey(msgName))
        {
            Debug.Log("MessagingSystem : Message \"" + msgName + "\" has no listeners!");
            return false;
        }

        List<MessageHandlerDelegate> listenerList = listenerDict[msgName];

        int indexCount = listenerList.Count;

        for(int i = 0; i < indexCount; ++i)
        {
            if (listenerList[i](msg))
                return true;
        }

        return true;
    }
}
