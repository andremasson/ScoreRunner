using UnityEngine;

public static class DebugX {

    static public bool debugMode;

    static DebugX()
    {
        debugMode = false;

#if UNITY_EDITOR
        debugMode = true;
        Debug.Log("Debug mode ON");
#endif
    }

    static public void Log(string msg)
    {
        if (debugMode)
        {
            Debug.Log(msg);
        }
    }
}
