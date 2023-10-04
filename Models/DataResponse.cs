namespace NextLevel_Bootcamp_FinalWork.Models
{
    public class DataResponse<TData> : BaseResponse
    {
        public TData Data { get; set; }

        public DataResponse(TData data)
        {
            Data = data;
        }
    }
}
