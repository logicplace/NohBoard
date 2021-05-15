/*
Copyright (C) 2016 by Eric Bataille <e.c.p.bataille@gmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace ThoNohT.NohBoard.Keyboard.Styles
{
    using System.Drawing;
    using System.Runtime.Serialization;

    /// <summary>
    /// The style for a key definition.
    /// </summary>
    [DataContract(Name = "DirectInputAxisStyle", Namespace = "")]
    public class DirectInputAxisStyle : ElementStyle
    {
        /// <summary>
        /// The <see cref="KeySubStyle"/> for this key when it is loose.
        /// </summary>
        [DataMember]
        public KeySubStyle Substyle { get; set; } = new KeySubStyle
        {
            Background = Color.FromArgb(100, 100, 100),
            Text = Color.FromArgb(0, 0, 0),
            Outline = Color.FromArgb(0, 255, 0),
            OutlineWidth = 1
        };

        /// <summary>
        /// Whether or not the Axis' backgound should be drawn
        /// </summary>
        [DataMember]
        public bool DrawAxisBackground { get; set; }

        /// <summary>
        /// Whether or not the "dot" of the axis should be drawn. If not, a circular black ball will be instead.
        /// </summary>
        [DataMember]
        public bool DrawDirectionalIcon { get; set; }

        /// <summary>
        /// The filename of the left background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundNeutralImageFileName { get; set; }

        /// <summary>
        /// The filename of the left background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundLeftImageFileName { get; set; }

        /// <summary>
        /// The filename of the right background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundRightImageFileName { get; set; }

        /// <summary>
        /// The filename of the top background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundTopImageFileName { get; set; }

        /// <summary>
        /// The filename of the bottom background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundBottomImageFileName { get; set; }

        /// <summary>
        /// The filename of the bottom left background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundBottomLeftImageFileName { get; set; }

        /// <summary>
        /// The filename of the bottom right background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundBottomRightImageFileName { get; set; }

        /// <summary>
        /// The filename of the top left background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundTopLeftImageFileName { get; set; }

        /// <summary>
        /// The filename of the top right background image, relative to the style's images folder.
        /// </summary>
        [DataMember]
        public string BackgroundTopRightImageFileName { get; set; }

        /// <summary>
        /// Returns a clone of this element style.
        /// </summary>
        /// <returns>The cloned element style.</returns>
        public override ElementStyle Clone()
        {
            return new KeyStyle
            {
                Loose = this.Substyle.Clone(),
                Pressed = this.Substyle.Clone()
            };
        }

        /// <summary>
        /// Checks whether the style has changes relative to the specified other style.
        /// </summary>
        /// <param name="other">The style to compare against.</param>
        /// <returns>True if the style has changes, false otherwise.</returns>
        public override bool IsChanged(ElementStyle other)
        {
            if (!(other is DirectInputAxisStyle ks)) return true;

            if (this.Substyle is null != ks.Substyle is null) return true;

            return (this.Substyle?.IsChanged(ks.Substyle) ?? false);
        }
    }
}