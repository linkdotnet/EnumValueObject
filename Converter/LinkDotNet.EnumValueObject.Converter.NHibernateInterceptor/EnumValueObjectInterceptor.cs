using System;
using NHibernate;

namespace LinkDotNet.EnumValueObject.Converter.NHibernateInterceptor
{
    public class EnumValueObjectInterceptor : EmptyInterceptor
    {
        private ISession _session;

        public override void SetSession(ISession session)
        {
            base.SetSession(session);
            _session = session;
        }

        public override object Instantiate(string clazz, object id)
        {
            var classMetadata = _session.SessionFactory.GetAllClassMetadata()[clazz];
            var type = classMetadata.MappedClass;
            if (type.IsSubclassOf(typeof(EnumValueObject<>)))
            {
                var result = type.GetMethod("Create").Invoke(null, new[] {id}) as dynamic;
                if (result.IsFailure)
                {
                    throw new ArgumentException($"Could not create {type.FullName} from key {id}");
                }

                // Call the static Create method
                return result.Value;
            }

            return base.Instantiate(clazz, id);


        }
    }
}
