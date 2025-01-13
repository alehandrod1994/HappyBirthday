using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyBirthday.BL.Model
{
    public abstract class LayoutCalculator
    {
        private static int _controlPanelHeight = 50;

        public static Point GetCenterLocation(Size mainPanelSize, Size formSize, int topPanelHeight, int bottomPanelHeight)
        {
            int y = topPanelHeight + (formSize.Height - topPanelHeight - bottomPanelHeight - mainPanelSize.Height - _controlPanelHeight) / 2;
            int x = (formSize.Width - mainPanelSize.Width) / 2;
            return new Point(x, y);
        }

        public static Point GetHorizontalCenterNavigation(int navigationPanelWidth, int formWidth)
        {
            int x = (formWidth - navigationPanelWidth) / 2;
            return new Point (x, 0);
        }
    }
}
