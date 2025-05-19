using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logger
{
    public static void Log(string message, int type = 1, Object context = null)
    {
        if (GameManager.Debugging)
        {
            switch (type)
            {
                case 1:
                    Debug.Log(message, context);
                    break;
                case 2:
                    Debug.LogWarning(message, context);
                    break;
                case 3:
                    Debug.LogError(message, context);
                    break;
            }
        }
    }
    public static void EventLog(string message, int type = 1, Object context = null)
    {
        switch (type)
        {
            case 1:
                Debug.Log(message, context);
                break;
            case 2:
                Debug.LogWarning(message, context);
                break;
            case 3:
                Debug.LogError(message, context);
                break;
        }
    }
}
