//using Bgg.Net.Common.Infrastructure.IOC;
//using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
//using Bgg.Net.Common.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using Autofac;
//using Bgg.Net.Common.Infrastructure.Exceptions;

//namespace Bgg.Net.Common.Infrastructure.Xml
//{
//    public class BggDeserializer : IBggDeserializer
//    {
//        public List<BggBase> Deserialize(string xml)
//        {
//            if (string.IsNullOrWhiteSpace(xml))
//            {
//                return null;
//            }

//            var document = new XmlDocument();

//            document.LoadXml(xml);
//            var root = document.DocumentElement;

//            using (var scope = AutofacRegistrar.BuildContainer().BeginLifetimeScope())
//            {
//                switch (root.Name)
//                {
//                    case "items":
//                        return scope.Resolve<IThingDeserializer>().Deserialize(xml);
//                    case "forums":
//                        return new List<BggBase> { scope.Resolve<IForumListDeserializer>().Deserialize(xml) };                       
//                    default:
//                        throw new XmlDeserializationException($"Unable to deserialize object {root.Name}");
//                }
//            }
//        }
//    }
//}
