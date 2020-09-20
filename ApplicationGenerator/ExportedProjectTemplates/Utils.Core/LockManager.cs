﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class LockManager
    {
        internal static Dictionary<ManagedLockObject, string> LockObjects { get; private set; }
        public static event EventHandler<EventArgs<Exception>> OnLockThreadException;

        static LockManager()
        {
            LockObjects = new Dictionary<ManagedLockObject, string>();
        }

        public static IManagedLockObject CreateObject()
        {
            var lockObject = new ManagedLockObject();

            lockObject.OnThreadException += (sender, e) =>
            {
                OnLockThreadException?.Invoke(lockObject, e);
            };

            lock (LockObjects)
            {
                LockObjects.Add(lockObject, lockObject.GetStackText(10, 3));
            }

            return lockObject;
        }
    }
}
