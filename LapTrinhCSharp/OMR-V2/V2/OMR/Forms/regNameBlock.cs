using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMR.Forms
{
    public class regNameBlock
    {
        public regNameBlock(int digits, bool requireWritten, System.Drawing.PointF loc)
        {
            location = loc;
            Digits = digits;
            RequireWritten = requireWritten;
        }

        System.Drawing.PointF location;
        bool RequireWritten;
        int Digits = 0;
    }
}
