using AquaProWeb.Common.Wrapper;
using FluentValidation;
using MediatR;

namespace AquaProWeb.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        //where TResponse : IResponseWrapper<int>, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //ArgumentNullException.ThrowIfNull(next);

            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validators
                    .Select(x => x.Validate(context))
                    .SelectMany(x => x.Errors)
                    .Where(x => x is not null)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                //var failures = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                if (failures.Count > 0)
                    return (dynamic)new ResponseWrapper<int>().Failures(failures);

                //return validationResult.IsValid ? await next() : (dynamic)new ResponseWrapper<int>().Failures(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            }

            return await next();
        }
    }
}
