using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.HotelСhainDto
{
    public class HotelChainDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public List<HotelDto.HotelDetailDto> Hotel { get; set; }

    }
}
