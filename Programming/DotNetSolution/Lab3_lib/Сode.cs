using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_lib
{
    public class Channel
    {
        public static double ChannelDelay(int src_seg, int src_ws, 
                                            int dst_seg, int dst_ws, 
                                            int seg_num,
                                            int msg_len,
                                            double seg_len, double meter_delay, double chunk_delay) {

            // Current segment is intermidiate
            if (src_seg != seg_num && dst_seg != seg_num) {
                return seg_len * meter_delay * msg_len * 8;
            }
            // Segment with server
            else if (src_seg == seg_num && dst_seg == seg_num) {
                return Math.Abs(src_ws - dst_ws) * chunk_delay * msg_len * 8;
            }
            // message from current segment
            else if (src_seg == seg_num) {
                return src_ws * chunk_delay * msg_len * 8;
            }
            // message to current segment
            else {
                return dst_ws * chunk_delay * msg_len * 8;
            }
        }
    }
}
