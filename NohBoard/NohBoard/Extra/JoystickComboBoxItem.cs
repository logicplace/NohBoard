using System;
using System.Collections.Generic;
using System.Text;

namespace ThoNohT.NohBoard.Extra
{
    public class JoystickComboBoxItem
    {
        public string ID { get; set; }
        public string Text { get; set; }

        public JoystickComboBoxItem(string ID, string Text) {
            this.ID = ID;
            this.Text = Text;
        }
    }
}
