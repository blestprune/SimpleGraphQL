using DemoApp.GraphQL.Errors;

namespace DemoApp.GraphQL
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is AppException ex)
                return error.WithMessage(ex.Message);

            return error;
        }
    }
}
