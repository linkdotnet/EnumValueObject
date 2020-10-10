using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LinkDotNet.KanbanBoard.Domain
{
    public abstract class Simple<TSimple>
    where TSimple: Simple<TSimple>
    {
        private readonly string _key;

        protected Simple(string key)
        {
            _key = key;
        }

        public virtual string Key => _key;

        public static TSimple Create(string key)
        {
            var obj = All.SingleOrDefault(e => e.Key == key);
            return obj;
        }

        public static IReadOnlyCollection<TSimple> All => GetAll();

        private static IReadOnlyCollection<TSimple> GetAll()
        {
            var enumerationType = typeof(TSimple);

            return enumerationType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<TSimple>()
                .ToArray();
        }
    }

    public class SimpleImpl : Simple<SimpleImpl>
    {
        public static readonly SimpleImpl One = new SimpleImpl("Important");
        public static readonly SimpleImpl Two = new SimpleImpl("Urgent");
        public static readonly SimpleImpl Three = new SimpleImpl("ImportantAndUrgent");
        public static readonly SimpleImpl Four = new SimpleImpl("None");

        private SimpleImpl(string key) : base(key)
        {
        }
    }

    public class SimpleImpl2 : Simple<SimpleImpl2>
    {
        public static readonly SimpleImpl2 Test = new SimpleImpl2("Something");

        private SimpleImpl2(string key) : base(key)
        {
        }
    }
}