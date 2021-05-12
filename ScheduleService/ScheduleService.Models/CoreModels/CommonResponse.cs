namespace ScheduleService.CoreModels
{
    public class CommonResponse<T>
    {
        public int statusCode { get; set; }
        public int timeStamp { get; set; }
        public string message { get; set; }
        public string debugInfo { get; set; }
        public object meta { get; set; }
        public T data { get; set; }
    }
}
