using UnityEngine;

namespace Configs
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Спробуємо знайти екземпляр у сцені
                    _instance = FindObjectOfType<T>();

                    // Якщо не знайдено, створимо новий об'єкт
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name);
                        _instance = singletonObject.AddComponent<T>();
                        Debug.LogWarning($"[MonoSingleton] Instance of {typeof(T)} created dynamically.");
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}