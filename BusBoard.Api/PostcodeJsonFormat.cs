namespace BusBoard.Api
{
    public class PostcodeJsonFormat
    {
        public PostcodeLongLat result;

        public PostcodeJsonFormat(PostcodeLongLat result)
        {
            this.result = result;
        }
    }
}