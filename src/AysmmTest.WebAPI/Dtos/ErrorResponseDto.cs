using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AysmmTest.WebAPI.Dtos
{
    [XmlRoot("Error")]
    public class ErrorResponseDto
    {
        public string Message { get; set; }
    }
}
