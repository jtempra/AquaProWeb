namespace AquaProWeb.Common.Wrapper
{
    public class ResponseWrapper<T>
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
    }
}
