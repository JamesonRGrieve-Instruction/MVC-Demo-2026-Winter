namespace ProjectName.Models.Exceptions
{

    public class CompositeException : Exception {
        public List<Exception> SubExceptions {get; set;} = new List<Exception>();

        public override string Message => $"{SubExceptions.Count} compiled exceptions, view SubExceptions for details.";

        public CompositeException(Exception exception) {
            SubExceptions.Add(exception);
        }
        public CompositeException() {}
    }
}


