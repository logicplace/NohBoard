
namespace ThoNohT.NohBoard.Keyboard.Styles
{
    using System.Drawing;
    using System.Runtime.Serialization;
    using ThoNohT.NohBoard.Extra;

    [DataContract(Name = "DirectInputDpadStyle", Namespace = "")]
    public class DirectInputDpadStyle : ElementStyle
    {
        /// <summary>
        /// The <see cref="KeySubStyle"/> for this key when it is loose.
        /// </summary>
        [DataMember]
        public KeySubStyle SubStyle { get; set; } = new KeySubStyle {
            Background = Color.FromArgb(0, 0, 100),
            Text = Color.FromArgb(0, 0, 0),
            Outline = Color.FromArgb(0, 255, 0),
            OutlineWidth = 1
        };

        /// <summary>
        /// The color of the axis placeholder
        /// </summary>
        [DataMember]
        public SerializableColor ForegroundColor { get; set; }

        /// <summary>
        /// Whether or not the Axis' backgound should be drawn
        /// </summary>
        [DataMember]
        public bool DrawDpadBackground { get; set; }

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
        public override ElementStyle Clone() {
            return new DirectInputDpadStyle {
                SubStyle = this.SubStyle?.Clone(),
                ForegroundColor = this.ForegroundColor,
                DrawDpadBackground = this.DrawDpadBackground,
                BackgroundNeutralImageFileName = this.BackgroundNeutralImageFileName,
                BackgroundBottomImageFileName = this.BackgroundBottomImageFileName,
                BackgroundTopImageFileName = this.BackgroundTopImageFileName,
                BackgroundLeftImageFileName = this.BackgroundLeftImageFileName,
                BackgroundRightImageFileName = this.BackgroundRightImageFileName,
                BackgroundBottomLeftImageFileName = this.BackgroundBottomLeftImageFileName,
                BackgroundBottomRightImageFileName = this.BackgroundBottomRightImageFileName,
                BackgroundTopLeftImageFileName = this.BackgroundTopLeftImageFileName,
                BackgroundTopRightImageFileName = this.BackgroundTopRightImageFileName
            };
        }

        /// <summary>
        /// Checks whether the style has changes relative to the specified other style.
        /// </summary>
        /// <param name="other">The style to compare against.</param>
        /// <returns>True if the style has changes, false otherwise.</returns>
        public override bool IsChanged(ElementStyle other) {
            if (!(other is DirectInputDpadStyle ks)) return true;

            if (this.SubStyle is null != ks.SubStyle is null) return true;

            return (this.SubStyle?.IsChanged(ks.SubStyle) ?? false);
        }
    }
}
