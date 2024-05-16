using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Estrutural.Adapter
{
    public class GeradorXML
    {
        public String GeraXML(object o)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
            StringWriter writer = new StringWriter();

            xmlSerializer.Serialize(writer, o);

            return writer.ToString();
        }
    }
}
