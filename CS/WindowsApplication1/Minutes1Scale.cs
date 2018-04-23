// Developer Express Code Central Example:
// How to resize an appointment without snapping it to time cells
// 
// This example illustrates how to resize an appointment without snapping it to
// timecells.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2341

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler;

namespace Lane_Management
{
    public class Minutes1Scale : LessThanADayTimeScale
    {
        const int myScaleValue = 1;
        public Minutes1Scale()
            : base(myScaleValue)
        {
        }
        public Minutes1Scale(int ScaleValue)
            : base(ScaleValue)
        {
            
        }
         

        protected override string DefaultDisplayFormat
        {
            get { return "h:mm tt"; }
            //get { return "HH:mm"; }
        }

        protected override string DefaultMenuCaption
        {
            get
            {
                return "1Minutes";
            }
        }

    }
}
