namespace NextLevel_Bootcamp_FinalWork.Models
{
    public abstract class BaseResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
