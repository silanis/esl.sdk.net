using System;

namespace Silanis.ESL.SDK
{
    public class TextAnchor
    {
        private string anchorText;
        private int occurrence;
        private int character;
        private TextAnchorPosition position;
        private int xOffset, yOffset;
        private int width, height;

        public TextAnchor(){
            Position = TextAnchorPosition.TOPLEFT;
        }
        public string AnchorText
        {
            get
            {
                return anchorText;
            }
            set
            {
                anchorText = value;
            }
        }

        public int Occurrence
        {
            get
            {
                return occurrence;
            }
            set
            {
                occurrence = value;
            }
        }

        public int Character
        {
            get
            {
                return character;
            }
            set
            {
                character = value;
            }
        }

        public TextAnchorPosition Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public int XOffset
        {
            get
            {
                return xOffset;
            }
            set
            {
                xOffset = value;
            }
        }

        public int YOffset
        {
            get
            {
                return yOffset;
            }
            set
            {
                yOffset = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }
}

