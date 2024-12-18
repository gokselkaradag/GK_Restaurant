using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalRWebUI.Dtos.FeatureDtos
{
    public class GetFeatureDto
    {
        public int FeatureID { get; set; }
        public string TitleOne { get; set; }
        public string DescriptionOne { get; set; }
        public string TitleTwo { get; set; }
        public string DescriptionTwo { get; set; }
        public string TitleThree { get; set; }
        public string DescriptionThree { get; set; }
    }
}
