using ReactiveRx.ZAdv.Extensions;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ReactiveRx.ZAdv.SeqCombinators
{
    public class SequenceCombinators
    {
        public SequenceCombinators()
        {
            var mechanical = new BehaviorSubject<bool>(true);
            var electrical = new BehaviorSubject<bool>(true);
            var eletronic = new BehaviorSubject<bool>(true);

            mechanical.Inspect("mechanical");
            electrical.Inspect("electrical");
            eletronic.Inspect("eletronic");

            Observable.CombineLatest(mechanical, electrical, eletronic)
                .Select(values => values.All(x => x))
                .Inspect("all");

            mechanical.OnNext(false);

            Console.ReadKey();
        }
    }
}
