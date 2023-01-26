using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table_Form
{
    public class DesignedLabel:Label
    {
        public DesignedLabel():base() {
            this.ForeColor = Form1.labelColor;
            this.Font = Form1.labelFont;
            
        }
        public DesignedLabel(System.Windows.Forms.Panel panel) : base()
        {
            panel.Controls.Add(this);
            this.ForeColor = Form1.labelColor;
            this.Font = Form1.labelFont;

        }
    }
}
