using System.Collections.Generic;

namespace Assets.Scripts.Architecture.Reactive
{
    public static class ConvertReactive
    {
        public static ReactiveList<T> ToReactiveList<T>(this List<T> list)
        {
            ReactiveList<T> reactiveList = new ReactiveList<T>(list);
            
            return reactiveList;
        }

    }
}
