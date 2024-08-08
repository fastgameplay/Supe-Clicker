namespace ScriptableEvents.Reference{
    using System;
    using UnityEngine;
    using ScriptableEvents.Base;
    [Serializable]
    public struct EventReference
    {
        public Action Event {
            get{ return _type == ScriptableEventType.Internal ? _internalEvent : _externalEvent.Event ;}
            set{
                if(_type == ScriptableEventType.Internal){
                    _internalEvent = value;
                } else{
                    _externalEvent.Event = value;
                }
            }    
        }
        [SerializeField] private ScriptableEventType _type;

        [SerializeField] private SO_BaseEvent _externalEvent;
        private Action _internalEvent;
        
        public static EventReference operator +(EventReference eventRef, Action listener)
        {
            eventRef.Event += listener;
            return eventRef;
        }

        public static EventReference operator -(EventReference eventRef, Action listener)
        {
            eventRef.Event -= listener;

            return eventRef;
        }

        public void Invoke()
        {
            Event?.Invoke();
        }
    }
    [Serializable]
    public struct EventReference<T>
    {
        public Action<T> Event{
            get{ return _type == ScriptableEventType.Internal ? _internalEvent : _externalEvent.Event ;}
            set{
                if(_type == ScriptableEventType.Internal){
                    _internalEvent = value;
                } else{
                    _externalEvent.Event = value;
                }
            }
        }    
        [SerializeField] private ScriptableEventType _type;

        [SerializeField] private SO_BaseEvent<T> _externalEvent;
        private Action<T> _internalEvent;
        
        public static EventReference<T> operator +(EventReference<T> eventRef, Action<T> listener){
            eventRef.Event += listener;
            return eventRef;
        }

        public static EventReference<T> operator -(EventReference<T> eventRef, Action<T> listener){
            eventRef.Event -= listener;

            return eventRef;
        }

        public void Invoke(T arg1){
            Event?.Invoke(arg1);
        }

    }

    [Serializable]
    public struct EventReference<T, J>
    {
        public Action<T,J> Event{
            get{ return _type == ScriptableEventType.Internal ? _internalEvent : _externalEvent.Event ;}
            set{
                if(_type == ScriptableEventType.Internal){
                    _internalEvent = value;
                } else{
                    _externalEvent.Event = value;
                }
            }
        }    
        [SerializeField] private ScriptableEventType _type;

        [SerializeField] private SO_BaseEvent<T,J> _externalEvent;
        private Action<T,J> _internalEvent;
            public static EventReference<T,J> operator +(EventReference<T,J> eventRef, Action<T,J> listener){
            eventRef.Event += listener;
            return eventRef;
        }

        public static EventReference<T,J> operator -(EventReference<T,J> eventRef, Action<T,J> listener){
            eventRef.Event -= listener;

            return eventRef;
        }

        public void Invoke(T arg1, J arg2){
            Event?.Invoke(arg1, arg2);
        }
        
    }
}