using System;
using System.Collections.Generic;
using System.Text;

namespace ThoNohT.NohBoard.Extra
{
    public class JoystickButtonComboBoxItem
    {
        public int ID { get; set; }
        public string Text { get; set; }

        public JoystickButtonComboBoxItem(int ID, string Text) {
            this.ID = ID;
            this.Text = Text;
        }
    }
}
