namespace AquaProWeb.Common.Wrapper
{
    public interface IResponseWrapper<T>
    {
        bool IsSuccessful { get; set; }
        List<string> Messages { get; set; }
        T Data { get; set; }
        ResponseWrapper<T> Success(T data, string message = null);
        ResponseWrapper<T> Failure(string message);
        ResponseWrapper<T> Failures(List<string> messages);
    }

    public class ResponseWrapper<T> : IResponseWrapper<T>
    {
        // classe que embolica el resultat de una crida a la API. Si te exit, retorna les dades amb missatges (opcionals), 
        // sino te exit, retorna els missatges d'error

        public bool IsSuccessful { get; set; }
        public List<string> Messages { get; set; }
        public T Data { get; set; }

        public ResponseWrapper<T> Success(T data, string message = null)
        {
            IsSuccessful = true;
            Messages = [message];
            Data = data;

            return this;
        }

        public ResponseWrapper<T> Failure(string message)
        {
            IsSuccessful = false;
            Messages = [message];

            return this;
        }

        public ResponseWrapper<T> Failures(List<string> messages)
        {
            IsSuccessful = false;
            Messages = messages;

            return this;
        }
    }
}
