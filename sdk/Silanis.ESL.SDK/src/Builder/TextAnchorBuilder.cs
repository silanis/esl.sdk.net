namespace Silanis.ESL.SDK
{
    public class TextAnchorBuilder
    {
        private string anchorText;
        private int occurrence;
        private int character;
        private TextAnchorPosition position;
        private int xOffset, yOffset;
        private int width, height;

        private TextAnchorBuilder( string anchorText ) {
            this.anchorText = anchorText;
        }

        public static TextAnchorBuilder NewTextAnchor( string anchorText ) {
            return new TextAnchorBuilder( anchorText );
        }

        public TextAnchorBuilder WithOccurrence( int occurrence ) {
            this.occurrence = occurrence;
            return this;
        }

        public TextAnchorBuilder WithCharacter( int character ) {
            this.character = character;
            return this;
        }

        public TextAnchorBuilder AtPosition( TextAnchorPosition position ) {
            this.position = position;
            return this;
        }

        public TextAnchorBuilder WithOffset( int x, int y ) {
            xOffset = x;
            yOffset = y;
            return this;
        }

        public TextAnchorBuilder WithSize( int width, int height ) {
            this.width = width;
            this.height = height;
            return this;
        }

        public TextAnchor Build() {
            var result = new TextAnchor();
            result.AnchorText = anchorText;
            result.Occurrence = occurrence;
            result.Character = character;
            result.Position = position;
            result.XOffset = xOffset;
            result.YOffset = yOffset;
            result.Width = width;
            result.Height = height;

            return result;
        }
    }
}

