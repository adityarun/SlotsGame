using UnityEngine;

namespace DevCommon
{
    /// <summary>
    /// Inherit this class from any unity component class to make that class Singleton
    /// isPersistent - true to make the gameobject not destroyable through out the game
    /// </summary>
    /// <typeparam name="T">The Child Component</typeparam>
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        static bool IsQuiting = false;
        static T instance;
        public static T Instance
        {
            get
            {
                if (IsQuiting)
                {
                    return null;
                }

                if (!instance)
                {
                    instance = FindObjectOfType<T>();
                    if (!instance)
                    {
                        GameObject obj = new GameObject
                        {
                            name = typeof(T).Name
                        };
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        public bool IsPersistent = false;

        string instanceName = typeof(T).Name;

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Debug.Log(instanceName + " Instance Missing. Creating new Instance of " + instanceName + ".");
                instance = this as T;
                Debug.Log(instanceName + " Instance created successfully!:).");
            }
            else if (Instance != this)
            {
                Debug.Log(instanceName + " already exists!...");
                if (this.gameObject)
                    Destroy(this.gameObject);
                return;
            }

            if (IsPersistent)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        protected virtual void OnApplicationQuit()
        {
            IsQuiting = true;
        }
    }
}
