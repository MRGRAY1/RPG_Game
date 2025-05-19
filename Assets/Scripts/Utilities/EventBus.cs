using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<EventCategory, Delegate> events = new Dictionary<EventCategory, Delegate>();

    public static void Subscribe<T>(EventCategory EventIndex, Action<T> listener)
    {
        if (!events.ContainsKey(EventIndex))
        {
            events[EventIndex] = null;
        }
        events[EventIndex] = (Action<T>)events[EventIndex] + listener;
    }

    public static void Unsubscribe<T>(EventCategory EventIndex, Action<T> listener)
    {
        if (events.ContainsKey(EventIndex))
        {
            events[EventIndex] = (Action<T>)events[EventIndex] - listener;

            if (events[EventIndex] == null)
            {
                events.Remove(EventIndex);
            }
        }
    }

    public static void Publish<T>(EventCategory EventIndex, T data)
    {
        if (events.ContainsKey(EventIndex))
        {
            ((Action<T>)events[EventIndex])?.Invoke(data);
            string eventText = "<color=green>EVENT: </color>";
            Logger.EventLog($"{eventText}{EventIndex}. Data: {data}");
        }
    }
}
