using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DeviceSendMQTT
    {
        private byte _packedData; // Order sẽ chiếm 7 bits đầu, Status chiếm 1 bit cuối

        public byte Order
        {
            get => (byte)(_packedData & 0x7F); // Lấy 7 bits đầu
            set => _packedData = (byte)((_packedData & 0x80) | (value & 0x7F)); // Set 7 bits đầu, giữ bit cuối nguyên
        }

        public bool Status
        {
            get => (_packedData & 0x80) != 0; // Lấy bit cuối
            set
            {
                if (value)
                    _packedData |= 0x80; // Set bit cuối thành 1
                else
                    _packedData &= 0x7F; // Set bit cuối thành 0
            }
        }
    }
}
