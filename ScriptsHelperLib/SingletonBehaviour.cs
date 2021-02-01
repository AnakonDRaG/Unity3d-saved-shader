using UnityEngine;

namespace Scripts.Helper
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static bool IsAwake => _instance != null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T) FindObjectOfType(typeof(T));
                    if (_instance == null)
                    {
                        var goName = typeof(T).ToString();

                        var go = GameObject.Find(goName);
                        if (go == null)
                        {
                            go = new GameObject();
                            go.name = goName;
                        }

                        _instance = go.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        public virtual void OnApplicationQuit()
        {
            _instance = null;
        }

        protected void SetParent(string parentGOName)
        {
            if (parentGOName != null)
            {
                var parentGO = GameObject.Find(parentGOName);
                if (parentGO == null)
                {
                    parentGO = new GameObject();
                    parentGO.name = parentGOName;
                }

                transform.parent = parentGO.transform;
            }
        }
    }
}