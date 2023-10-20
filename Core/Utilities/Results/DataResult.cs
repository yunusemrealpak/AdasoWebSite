namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success, (success ? "İşleminiz başarıyla tamamlandı." : "İşleminiz sırasında hata meydana geldi."))
        {
            Data = data;
        }



        public int DataCount { get; set; } = 0;
        public T Data { get; }
    }
}
