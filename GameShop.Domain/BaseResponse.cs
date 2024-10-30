namespace GameShop.Domain 
{ 
    public class BaseResponse<T>:IBaseResponse<T>
	{
		public string Description { get; set; }	
		public T Data { get; set; }
		public string StatusCode { get; set; }
	}
	public interface IBaseResponse<T>
	{
		public T Data { get; set; }
	}
}
