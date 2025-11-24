using System;

namespace Observer
{
    public static class TargetCalls
    {
        public static event Action OnTargetHit;
        public static event Action OnTargetMiss;

        public static void TargetHit() => OnTargetHit?.Invoke();
        public static void TargetMiss() => OnTargetMiss?.Invoke();
    }
}