namespace MSO.StimmApp.Messages
{
    public class AppStimmerButtonPressedMessage
    {
        public AppStimmerButtonPressedMessage(bool liked)
        {
            this.Liked = liked;
        }

        public bool Liked { get; set; }
    }
}
